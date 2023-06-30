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

namespace SRIS.Application.ResortFoodCopingMasters.Command.CreateResortFoodCopingMasterItem
{
    public class CreateResortFoodCopingMasterItemCommand : IRequest<int>
    {
        public int resortfoodcopingid { get; set; }
        public string resortfoodcoping { get; set; }
        public string description { get; set; }
    }
    public class CreateResortFoodCopingMasterItemCommandHandler : IRequestHandler<CreateResortFoodCopingMasterItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateResortFoodCopingMasterItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateResortFoodCopingMasterItemCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ResortFoodCoping();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_resortfoodCoping.Where(x => x.resortfoodcoping == request.resortfoodcoping && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.resortfoodcopingid == 0)
                    {
                        entity.resortfoodcoping = request.resortfoodcoping;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.resortfoodcopingid = request.resortfoodcopingid;
                        bool hasSpecialChars = rgx.IsMatch(entity.resortfoodcoping);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_resortfoodCoping.Add(entity);
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

                            _context.m_master_resortfoodCoping.Add(entity);
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
