using SRIS.Application.AssignLinkToRoleMasters.Queries.GetAssignLinkToRoleMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface IAssignLinkToRoleService
    {
        Task<List<AssignLinkToRoleMasterDto>> GetUserAccessLinks(int userid);
    }

}
