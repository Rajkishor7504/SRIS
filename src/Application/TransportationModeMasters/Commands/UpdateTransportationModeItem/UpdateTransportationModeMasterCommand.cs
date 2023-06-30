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

namespace SRIS.Application.TransportationModeMasters.Commands.UpdateTransportationModeItem
{
    public class UpdateTransportationModeMasterCommand : IRequest<int>
    {
        public int modeid { get; set; }
        public string modename { get; set; }
        public string description { get; set; }
        public class UpdateTransportationModeMasterCommandHandler : IRequestHandler<UpdateTransportationModeMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateTransportationModeMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateTransportationModeMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_transportationmode.FindAsync(request.modeid);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(TransportationMode), request.modename);
                    }
                    count = _context.m_master_transportationmode.Where(x => x.modename == request.modename && x.modeid != request.modeid && x.deletedflag == false).Count();
                    if (count == 0)

                    {
                        if (request.modeid != 0)
                        {
                            entity.modename = request.modename;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.modename);
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