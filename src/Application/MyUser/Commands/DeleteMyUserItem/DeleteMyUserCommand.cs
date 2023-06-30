using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MyUsers.Commands.DeleteMyUser
{
    public class DeleteMyUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteMyUserCommandHandler : IRequestHandler<DeleteMyUserCommand,int>
    {
        private readonly IMyUserService _iMyUserService;

        public DeleteMyUserCommandHandler(IMyUserService iMyUserService)
        {
            _iMyUserService = iMyUserService;
        }

        public async Task<int> Handle(DeleteMyUserCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = await _iMyUserService.GetMyUser(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(MyUser), request.Id);
            }

            retval = await _iMyUserService.DeleteMyUser(request.Id);

            return retval;
        }
    }
}
