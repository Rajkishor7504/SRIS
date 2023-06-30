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

namespace SRIS.Application.CropMasters.Commands.DeleteCropMasterItem
{
   public class DeleteCropMasterCommand : IRequest<int>
    {
        public int cropid { get; set; }
    }
    public class DeleteCropMasterCommandHandler : IRequestHandler<DeleteCropMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCropMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteCropMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_crop.FindAsync(request.cropid);
            try
            {
                count = _context.t_hhr_cultivationresponsibility.Where(x => x.cropid == request.cropid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Cultivationresponsibility), request.cropid);
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
                    //_context.m_master_crop.Remove(entity);
                    //await _context.SaveChangesAsync(cancellationToken);
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

        //public async Task<Unit> Handle(DeleteCropMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_crop.FindAsync(request.cropid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(Crop), request.cropid);
        //    }

        //    _context.m_master_crop.Remove(entity);           

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}