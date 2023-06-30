using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UserRoleMasters.Queries.GetUserRoleMaster
{
   public class GetUserRoleMasterQuery : IRequest<UserRoleMasterVM>
    {
        public int roleid { get; set; }
        public string paction { get; set; }
    }

    public class GetUserRoleMasterQueryHandler : IRequestHandler<GetUserRoleMasterQuery,UserRoleMasterVM>
    {
        private readonly IUserRoleService _IUserRoleService;
        private readonly IMapper _mapper;

        public GetUserRoleMasterQueryHandler(IUserRoleService iUserRoleService, IMapper mapper)
        {
            _IUserRoleService = iUserRoleService;
            _mapper = mapper;
        }

       
        public async Task<UserRoleMasterVM> Handle(GetUserRoleMasterQuery request, CancellationToken cancellationToken)
        {
            //var entity = new UserRoleMasterDto();
            //entity.action = request.paction;
            return new UserRoleMasterVM
            {
                Lists = await _IUserRoleService.GetUserRoles()
            };
        }
       
    }
}
