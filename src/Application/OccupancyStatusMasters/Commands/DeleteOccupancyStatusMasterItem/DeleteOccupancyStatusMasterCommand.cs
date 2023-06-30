using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OccupancyStatusMasters.Commands.DeleteOccupancyStatusMasterItem
{
    public class DeleteOccupancyStatusMasterCommand : IRequest
    {
        public int id { get; set; }
    }
    public class DeleteOccupancyStatusMasterCommandHandler : IRequestHandler<DeleteOccupancyStatusMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOccupancyStatusMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOccupancyStatusMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_occupancyStatus.FindAsync(request.id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OccupancyStatusMaster), request.id);
            }

            //_context.m_master_occupancyStatus.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);
            entity.updatedby = 1;
            entity.deletedflag = true;
            entity.updatedon = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
