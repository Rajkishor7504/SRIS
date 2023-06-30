using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.liveLiHoodMasters.Commands.UpdateliveLiHoodMasterItem
{
   public class UpdateliveLiHoodMasterCommand : IRequest<int>
    {
        public int livelihoodid { get; set; }
        public string livelihoodname { get; set; }
        public string description { get; set; }
    }
    public class UpdateliveLiHoodMasterCommandHandler : IRequestHandler<UpdateliveLiHoodMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateliveLiHoodMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _context = context;
        }
        public async Task<int> Handle(UpdateliveLiHoodMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_livelihood.FindAsync(request.livelihoodid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(LiveliHood), request.livelihoodname);
                }
                count = _context.m_master_livelihood.Where(x => x.livelihoodname == request.livelihoodname && x.livelihoodid != request.livelihoodid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.livelihoodid != 0)
                    {
                        entity.updatedon = _dateTime.Now;
                        entity.updatedby = 1;
                        entity.livelihoodname = request.livelihoodname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.livelihoodname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 2;
                        }
                        else
                        {
                            retval = 403;


                        }
                    }
                }
                else
                {
                    retval = 3;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }
    }

}
