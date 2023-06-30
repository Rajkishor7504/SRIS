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

namespace SRIS.Application.DrinkingSourceMaster.Commands.DeleteDrinkingSourceMasterItem
{
   public class DeleteDrinkingSourceMasterCommand : IRequest<int>
    {
        public int sourceid { get; set; }
    }
    public class DeleteDrinkingSourceMasterCommandHandler : IRequestHandler<DeleteDrinkingSourceMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDrinkingSourceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteDrinkingSourceMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_drinkingsource.FindAsync(request.sourceid);
            try
            {
                count = _context.t_hhr_housing.Where(x => x.f10_mainsourceofdrinkingwater == request.sourceid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Housing), request.sourceid);
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
        //public async Task<Unit> Handle(DeleteDrinkingSourceMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_drinkingsource.FindAsync(request.sourceid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(DrinkingSource), request.sourceid);
        //    }

        //    _context.m_master_drinkingsource.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}