using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.CookingFuelMaster.Commands.DeleteCookingFuelMasterCommand;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ToiletTypeMasters.Commands.DeleteToiletTypeMasterItem
{
   public class DeleteToiletTypeMasterCommand : IRequest<int>
    {
        public int typeid { get; set; }
    }
    public class DeleteToiletTypeMasterCommandHandler : IRequestHandler<DeleteToiletTypeMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteToiletTypeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteToiletTypeMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_toilettype.FindAsync(request.typeid);
            try
            {
                count = _context.t_hhr_housing.Where(x => x.f07_typeoftoiletfacility == request.typeid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Housing), request.typeid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_toilettype.Remove(entity);
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
        //public async Task<Unit> Handle(DeleteToiletTypeMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_toilettype.FindAsync(request.typeid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(ToiletType), request.typeid);
        //    }

        //    _context.m_master_toilettype.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
