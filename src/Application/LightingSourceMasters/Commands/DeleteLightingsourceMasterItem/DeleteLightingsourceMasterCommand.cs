using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LightingSourceMasters.Commands.DeleteLightingsourceMasterItem
{
   public class DeleteLightingsourceMasterCommand : IRequest
    {
        public int sourceid { get; set; }
    }
    public class DeleteLightingsourceMasterCommandHandler : IRequestHandler<DeleteLightingsourceMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLightingsourceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLightingsourceMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_lightingsource.FindAsync(request.sourceid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(LightingSource), request.sourceid);
            }

            entity.updatedby = 1;
            entity.deletedflag = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}