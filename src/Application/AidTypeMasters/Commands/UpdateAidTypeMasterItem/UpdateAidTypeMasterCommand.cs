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

namespace SRIS.Application.AidTypeMasters.Commands.UpdateAidTypeMasterItem
{
    public class UpdateAidTypeMasterCommand : IRequest<int>
    {
        public int aidid { get; set; }
        public string aidname { get; set; }
        public string description { get; set; }
        public class UpdateAidTypeMasterCommandHandler : IRequestHandler<UpdateAidTypeMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateAidTypeMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateAidTypeMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_hhr_aid.FindAsync(request.aidid);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(AidType), request.aidname);
                    }
                    count = _context.m_hhr_aid.Where(x => x.aidname == request.aidname && x.aidid != request.aidid && x.deletedflag == false).Count();
                    if (count == 0)
                   
                    {
                        if (request.aidid != 0)
                        {
                            entity.aidname = request.aidname;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.aidname);
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
