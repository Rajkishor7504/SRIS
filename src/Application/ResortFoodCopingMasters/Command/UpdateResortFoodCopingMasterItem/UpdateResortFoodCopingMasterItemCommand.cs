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

namespace SRIS.Application.ResortFoodCopingMasters.Command.UpdateResortFoodCopingMasterItem
{
    public class UpdateResortFoodCopingMasterItemCommand : IRequest<int>
    {
        public int resortfoodcopingid { get; set; }
        public string resortfoodcoping { get; set; }
        public string description { get; set; }
    }
    public class UpdateResortFoodCopingMasterItemCommandHandler : IRequestHandler<UpdateResortFoodCopingMasterItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateResortFoodCopingMasterItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateResortFoodCopingMasterItemCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_resortfoodCoping.FindAsync(request.resortfoodcopingid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ResortFoodCoping), request.resortfoodcoping);
                }
                count = _context.m_master_resortfoodCoping.Where(x => x.resortfoodcoping == request.resortfoodcoping && x.resortfoodcopingid != request.resortfoodcopingid && x.deletedflag == false).Count();
               
                if (count == 0)
                {
                    if (request.resortfoodcopingid != 0)
                    {
                        entity.resortfoodcoping = request.resortfoodcoping;
                        entity.description = request.description;

                        bool hasSpecialChars = rgx.IsMatch(entity.resortfoodcoping);
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

