using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Commands.DeleteMaster
{
    public class DeleteMasterCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMasterCommandHandler : IRequestHandler<DeleteMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.masters.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Master), request.Id);
            }

            _context.masters.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
