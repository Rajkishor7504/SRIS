using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OccupancyStatusMasters.Commands.UpdateOccupancyStatusMasterItem
{
    public class UpdateOccupancyStatusMasterCommand : IRequest<int>
    {
        public int id { get; set; }
        public string occupancyStatusName { get; set; }     
        public string description { get; set; }
        public class UpdateOccupancyStatusMasterCommandHandler : IRequestHandler<UpdateOccupancyStatusMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateOccupancyStatusMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateOccupancyStatusMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_occupancyStatus.FindAsync(request.id);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(OccupancyStatusMaster), request.occupancyStatusName);
                    }
                    count = _context.m_master_occupancyStatus.Where(x => x.occupancyStatusName == request.occupancyStatusName && x.id != request.id && x.deletedflag == false).Count();
                    if (count == 0)
                    //count = _context.m_master_documentType.Where(x => x.documentType == request.documentType).Count();
                    //if (count == 0)
                    {
                        if (request.id != 0)
                        {
                            entity.occupancyStatusName = request.occupancyStatusName;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.occupancyStatusName);
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

}
