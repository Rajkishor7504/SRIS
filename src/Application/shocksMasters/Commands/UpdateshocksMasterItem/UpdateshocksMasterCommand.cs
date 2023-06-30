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

namespace SRIS.Application.shocksMasters.Commands.UpdateshocksMasterItem
{
   public class UpdateshocksMasterCommand : IRequest<int>
    {
        public int shockid { get; set; }
        public string shockname { get; set; }
        public string description { get; set; }
    }
    public class UpdateshocksMasterCommandHandler : IRequestHandler<UpdateshocksMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateshocksMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _context = context;
        }
        public async Task<int> Handle(UpdateshocksMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_shocks.FindAsync(request.shockid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Shocks), request.shockname);
                }
                count = _context.m_master_shocks.Where(x => x.shockname == request.shockname && x.shockid != request.shockid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.shockid != 0)
                    {
                        entity.updatedon = _dateTime.Now;
                        entity.updatedby = 1;
                        entity.shockname = request.shockname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.shockname);
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