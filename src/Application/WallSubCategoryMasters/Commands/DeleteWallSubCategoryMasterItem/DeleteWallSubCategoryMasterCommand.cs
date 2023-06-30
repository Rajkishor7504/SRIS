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

namespace SRIS.Application.WallSubCategoryMasters.Commands.DeleteWallSubCategoryMasterItem
{
   public class DeleteWallSubCategoryMasterCommand : IRequest<int>
    {
        public int subcategoryid { get; set; }
    }
    public class DeleteWallSubCategoryMasterCommandHandler : IRequestHandler<DeleteWallSubCategoryMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWallSubCategoryMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteWallSubCategoryMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_wallsubcategory.FindAsync(request.subcategoryid);
            try
            {
                count = _context.t_hhr_housing.Where(x => x.f03_mainmaterialusedforroofing == request.subcategoryid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Housing), request.subcategoryid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_wallsubcategory.Remove(entity);
                    //await _context.SaveChangesAsync(cancellationToken);
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    entity.updatedon = DateTime.Now;
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
        //public async Task<Unit> Handle(DeleteWallSubCategoryMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_wallsubcategory.FindAsync(request.subcategoryid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(WallSubCategory), request.subcategoryid);
        //    }

        //    _context.m_master_wallsubcategory.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }

}

