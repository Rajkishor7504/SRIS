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

namespace SRIS.Application.LiveStockMasters.Commands.DeleteLiveStockMasterItem
{
    public class DeleteLiveStockMasterCommand : IRequest<int>
    {
        public int livestockid { get; set; }
    }
    public class DeleteLiveStockMasterCommandHandler : IRequestHandler<DeleteLiveStockMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLiveStockMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteLiveStockMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_livestock.FindAsync(request.livestockid);
            try
            {
                count = _context.t_hhr_breedinglivestock.Where(x => x.livestockid == request.livestockid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Impactofshocks), request.livestockid);
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
        //public async Task<Unit> Handle(DeleteLiveStockMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_livestock.FindAsync(request.livestockid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(LiveStock), request.livestockid);
        //    }



        //    _context.m_master_livestock.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
