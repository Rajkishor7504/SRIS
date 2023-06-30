using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.CookingFuelMaster.Commands.DeleteCookingFuelMasterCommand
{
   public class DeleteCookingFuelMasterCommand : IRequest<int>
    {
        public int fuelid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteCookingFuelMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteCookingFuelMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_cookingfuel.FindAsync(request.fuelid);
            try
            {
                count = _context.t_hhr_housing.Where(x => x.f06_maincookingfuel == request.fuelid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Housing), request.fuelid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            //return Unit.Value;
            return retval;
        }
       

        //public async Task<Unit> Handle(DeleteCookingFuelMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_cookingfuel.FindAsync(request.fuelid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(CookingFuel), request.fuelid);
        //    }

        //    _context.m_master_cookingfuel.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
