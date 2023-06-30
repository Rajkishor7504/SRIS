using SRIS.Application.UserRoleMasters.Queries.GetUserRoleMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
    public interface IUserRoleService
    {
        //Task<int> AddUserRoleMaster(UserRoleMasterDto userRole);
        Task<List<UserRoleMasterDto>> GetUserRoles();
    }
}
