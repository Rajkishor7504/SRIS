using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.shocksSeverityMasters.Commands.DeleteshocksSeverityMasterItem
{
   public class DeleteshocksSeverityMasterCommand : IRequest
    {
        public int severityid { get; set; }
    }
    public class DeleteshocksSeverityMasterCommandHandler : IRequestHandler<DeleteshocksSeverityMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteshocksSeverityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteshocksSeverityMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_severity.FindAsync(request.severityid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(shocksSeverityMaster), request.severityid);
            }

            //_context.m_master_severity.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);
            entity.updatedby = 1;
            entity.deletedflag = true;
            entity.updatedon = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
