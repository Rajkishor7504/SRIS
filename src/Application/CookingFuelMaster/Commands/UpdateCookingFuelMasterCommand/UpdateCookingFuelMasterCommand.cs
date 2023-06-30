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

namespace SRIS.Application.CookingFuelMaster.Commands.UpdateCookingFuelMasterCommand
{
   public class UpdateCookingFuelMasterCommand : IRequest<int>
    {
        public int fuelid { get; set; }
        public string fuelname { get; set; }
        public string description { get; set; }
        public class UpdateCookingFuelMasterCommandHandler : IRequestHandler<UpdateCookingFuelMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateCookingFuelMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCookingFuelMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_cookingfuel.FindAsync(request.fuelid);


                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(CookingFuel), request.fuelname);
                    }
                    count = _context.m_master_cookingfuel.Where(x => x.fuelname == request.fuelname && x.fuelid != request.fuelid && x.deletedflag == false).Count();
                    if (count == 0)
                   
                    {
                        if (request.fuelid != 0)
                        {
                            entity.fuelname = request.fuelname;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.fuelname);
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
