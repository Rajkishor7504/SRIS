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

namespace SRIS.Application.TransportationModeMasters.Commands.DeleteTransportationModeItem
{
    public class DeleteTransportationModeMasterCommand : IRequest<int>
    {
        public int modeid { get; set; }
    }
    public class DeleteTransportationModeMasterCommandHandler : IRequestHandler<DeleteTransportationModeMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTransportationModeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteTransportationModeMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_transportationmode.FindAsync(request.modeid);
            try
            {
                count = _context.t_hhr_distance.Where(x => x.transportationmodeid == request.modeid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Distance), request.modeid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
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
        //public async Task<Unit> Handle(DeleteTransportationModeMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_transportationmode.FindAsync(request.modeid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(TransportationMode), request.modeid);
        //    }

        //    _context.m_master_transportationmode.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
