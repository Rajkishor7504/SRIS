using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AssignLinkToRoleMasters.Queries.GetAssignLinkToRoleMaster
{
   public class GetAssignLinkToRoleMasterQuery : IRequest<AssignLinkToRoleMasterVM>
    {
        public int linkaccessid { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
    }
    public class GetAssignLinkToRoleMasterQueryHandler : IRequestHandler<GetAssignLinkToRoleMasterQuery, AssignLinkToRoleMasterVM>
    {
        private readonly IAssignLinkToRoleService _IAssignLinkToRoleService;
        private readonly IMapper _mapper;

        public GetAssignLinkToRoleMasterQueryHandler(IAssignLinkToRoleService IAssignLinkToRoleService, IMapper mapper)
        {
            _IAssignLinkToRoleService = IAssignLinkToRoleService;
            _mapper = mapper;
        }

        #region "To Get User Access Link"
       
        public async Task<AssignLinkToRoleMasterVM> Handle(GetAssignLinkToRoleMasterQuery request, CancellationToken cancellationToken)
        {
            var list = await _IAssignLinkToRoleService.GetUserAccessLinks(request.roleid);
            var glist = list.Where(u => u.linkaccessid != 0).Select(p => new GlobalLinkMasterDto()
            {
                glinkname = p.glinkname,
                glinkid = p.glinkId
            }).ToList();
            return new AssignLinkToRoleMasterVM
            {
                Lists = list.OrderBy(g => g.glinkId).ToList(),
                GLLists = glist.GroupBy(x => x.glinkid).Select(x => x.FirstOrDefault()).OrderBy(g => g.glinkid).ToList()
            };
        }
        #endregion
    }
}
