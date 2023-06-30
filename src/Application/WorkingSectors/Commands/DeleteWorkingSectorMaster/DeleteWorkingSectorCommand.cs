using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.WorkingSectors.Commands.DeleteWorkingSectorMaster
{
    public class DeleteWorkingSectorCommand:IRequest
    {
        public int sectorid { get; set; }
    }
    public class DeleteWorkingSectorCommandHandler : IRequestHandler<DeleteWorkingSectorCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWorkingSectorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteWorkingSectorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_workingsector.FindAsync(request.sectorid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WorkingSector), request.sectorid);
            }

            //_context.m_master_workingsector.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);
            entity.updatedby = 1;
            entity.deletedflag = true;
            entity.updatedon = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

