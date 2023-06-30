using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Commands.CreateMaster
{
    public class CreateMasterCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateMasterCommandHandler : IRequestHandler<CreateMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new Master();

            entity.Name = request.Name;
            entity.Description = request.Description;

            _context.masters.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
