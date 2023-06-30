using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MyUsers.Queries.GetMyUser
{
    public class GetMyUserQuery : IRequest<MyUserVm>
    {
    }

    public class GetMyUserQueryHandler : IRequestHandler<GetMyUserQuery, MyUserVm>
    {
        private readonly IMyUserService _iMyUserService;
        private readonly IMapper _mapper;

        public GetMyUserQueryHandler(IMyUserService iMyUserService, IMapper mapper)
        {
            _iMyUserService = iMyUserService;
            _mapper = mapper;
        }

        public async Task<MyUserVm> Handle(GetMyUserQuery request, CancellationToken cancellationToken)
        {
            return new MyUserVm
            {
                Lists = await _iMyUserService.GetMyUsers()
            };
        }
    }
}
