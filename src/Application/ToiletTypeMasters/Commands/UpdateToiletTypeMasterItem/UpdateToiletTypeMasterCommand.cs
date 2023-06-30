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

namespace SRIS.Application.ToiletTypeMasters.Commands.UpdateToiletTypeMasterItem
{
    public class UpdateToiletTypeMasterCommand : IRequest<int>
    {
       public int typeid { get; set; }
        public string typename { get; set; }
        public string description { get; set; }
        public class UpdateToiletTypeMasterCommandHandler : IRequestHandler<UpdateToiletTypeMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateToiletTypeMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateToiletTypeMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_toilettype.FindAsync(request.typeid);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(ToiletType), request.typename);
                    }
                    count = _context.m_master_toilettype.Where(x => x.typename == request.typename && x.typeid != request.typeid && x.deletedflag == false).Count();
                    if (count == 0)

                    {
                        if (request.typeid != 0)
                        {
                            entity.typename = request.typename;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.typename);
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
