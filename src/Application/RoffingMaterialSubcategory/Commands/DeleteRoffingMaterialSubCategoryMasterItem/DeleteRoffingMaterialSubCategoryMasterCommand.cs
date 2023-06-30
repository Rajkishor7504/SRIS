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

namespace SRIS.Application.RoffingMaterialSubcategory.Commands.DeleteRoffingMaterialSubCategoryMasterItem
{
    public class DeleteRoffingMaterialSubCategoryMasterCommand : IRequest<int>
    {
        public int subcategoryid { get; set; }
    }
    public class DeleteRoffingMaterialSubCategoryMasterCommandHandler : IRequestHandler<DeleteRoffingMaterialSubCategoryMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRoffingMaterialSubCategoryMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteRoffingMaterialSubCategoryMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_roffingmaterialsubcategory.FindAsync(request.subcategoryid);
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
                    //_context.m_master_roffingmaterialsubcategory.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteRoffingMaterialSubCategoryMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_roffingmaterialsubcategory.FindAsync(request.subcategoryid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(RoffingMaterialSubCategory), request.subcategoryid);
        //    }

        //    _context.m_master_roffingmaterialsubcategory.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}
    }

}

