
using SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster;
using SRIS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRIS.Application.Common
{
    public interface ISysUserService
    {
        //Task<List<MyUser>> CheckLogin(MyUser sysUser,string userName, string password);
        MyUser CheckLogin(string userName, string password, MyUser sysuser);
        public string ForgotPasswordManage(MyUser userMaster, string strAction);
        List<AccessLinkMasterDto> UserLinkAccessVIew(int userid);
        List<MenuItem> GetUserLinks(int intUserId);
        MyUser GetUserDetailsByUserId(int userid);
        Task<int> ChangePassword(MyUser user);
        MyUser CheckMobileLogin(string userName, string password, int userType);
    }
}
