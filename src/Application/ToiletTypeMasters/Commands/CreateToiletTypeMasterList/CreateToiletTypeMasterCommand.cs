using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ToiletTypeMasters.Commands.CreateToiletTypeMasterList
{
    public class CreateToiletTypeMasterCommand : IRequest<int>
    {
        public int typeid { get; set; }
        public string typename { get; set; }
        public string description { get; set; }
    }
    public class CreateToiletTypeMasterCommandHandler : IRequestHandler<CreateToiletTypeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateToiletTypeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateToiletTypeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ToiletType();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_toilettype.Where(x => x.typename == request.typename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.typeid == 0)
                    {
                        entity.typename = request.typename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.typeid = request.typeid;
                        bool hasSpecialChars = rgx.IsMatch(entity.typename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_toilettype.Add(entity);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 1;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            _context.m_master_toilettype.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
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