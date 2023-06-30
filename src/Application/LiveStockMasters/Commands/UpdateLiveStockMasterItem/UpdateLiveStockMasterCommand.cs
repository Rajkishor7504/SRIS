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

namespace SRIS.Application.LiveStockMasters.Commands.UpdateLiveStockMasterItem
{
    public class UpdateLiveStockMasterCommand : IRequest<int>
    {
        public int livestockid { get; set; }
        public string livestockname { get; set; }
        public string description { get; set; }
    }
    public class UpdateEthnicityMasterCommandHandler : IRequestHandler<UpdateLiveStockMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEthnicityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateLiveStockMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_livestock.FindAsync(request.livestockid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(LiveStock), request.livestockname);
                }
                count = _context.m_master_livestock.Where(x => x.livestockname == request.livestockname && x.livestockid != request.livestockid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.livestockid != 0)
                    {
                        entity.livestockname = request.livestockname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.livestockname);
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
