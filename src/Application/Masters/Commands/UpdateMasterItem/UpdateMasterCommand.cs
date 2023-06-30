using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Commands.UpdateMaster
{
    public class UpdateMasterCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class UpdateMasterCommandHandler : IRequestHandler<UpdateMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.masters.FindAsync(request.Name);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Master), request.Name);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
