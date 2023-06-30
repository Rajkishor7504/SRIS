using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ContactTypeMaster.Commands.DeleteContactTypeMasterItem
{
   public class DeleteContactTypeCommand : IRequest
    {
        public int id { get; set; }
    }
    public class DeleteContactTypeCommandHandler : IRequestHandler<DeleteContactTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteContactTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContactTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_master_Contacttype.FindAsync(request.id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactType), request.id);
            }

            entity.updatedby = 1;
            entity.deletedflag = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
