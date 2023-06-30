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

namespace SRIS.Application.CopingStrategyMasters.Commands.DeleteCopingStrategyMasterItem
{
    public class DeleteCopingStrategyMasterCommand : IRequest<int>
    {
        public int copingid { get; set; }
    }
    //public class DeleteCopingStrategyMasterCommandHandler : IRequestHandler<DeleteCopingStrategyMasterCommand,int>
    //{
    //    private readonly IApplicationDbContext _context;

    //    public DeleteCopingStrategyMasterCommandHandler(IApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<int> Handle(DeleteCopingStrategyMasterCommand request, CancellationToken cancellationToken)
    //    {
    //        int count = 0;
    //        int retval = 0;
    //        var entity = await _context.m_master_coping.FindAsync(request.copingid);
    //        try
    //        {
    //            count = _context.t_hhr_livelyhoodcopingdetail.Where(x => x.intcopingid == request.copingid && x.deletedflag == false).Count();

    //            if (entity == null)
    //            {
    //                throw new NotFoundException(nameof(Livelyhoodcopingdetail), request.copingid);
    //            }
    //            if (count > 0)
    //            {
    //                retval = 402;
    //            }
    //            else
    //            {
                    
                    
    //                entity.updatedby = 1;
    //                entity.deletedflag = true;
    //                await _context.SaveChangesAsync(cancellationToken);
    //                retval = 200;
    //            }

    //        }
    //        catch (System.Exception ex)
    //        {
    //            throw ex;
    //        }
    //        //return Unit.Value;
    //        return retval;
    //    }
    //    //public async Task<Unit> Handle(DeleteCopingStrategyMasterCommand request, CancellationToken cancellationToken)
    //    //{
    //    //    var entity = await _context.m_master_coping.FindAsync(request.copingid);

    //    //    if (entity == null)
    //    //    {
    //    //        throw new NotFoundException(nameof(CopingStrategyMaster), request.copingid);
    //    //    }

    //    //    _context.m_master_coping.Remove(entity);

    //    //    await _context.SaveChangesAsync(cancellationToken);

    //    //    return Unit.Value;
    //    //}

    //}
}
