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

namespace SRIS.Application.CookingFuelMaster.Commands.CreateCookingFuelMasterList
{
   public class CreateCookingFuelMasterCommand : IRequest<int>
    {
        public int fuelid { get; set; }
        public string fuelname { get; set; }
        public string description { get; set; }
    }
    public class CreateCookingFuelMasterCommandHandler : IRequestHandler<CreateCookingFuelMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCookingFuelMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCookingFuelMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new CookingFuel();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_cookingfuel.Where(x => x.fuelname == request.fuelname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.fuelid == 0)
                    {
                        entity.fuelname = request.fuelname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.fuelid = request.fuelid;
                        bool hasSpecialChars = rgx.IsMatch(entity.fuelname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_cookingfuel.Add(entity);
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

                            _context.m_master_cookingfuel.Add(entity);
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