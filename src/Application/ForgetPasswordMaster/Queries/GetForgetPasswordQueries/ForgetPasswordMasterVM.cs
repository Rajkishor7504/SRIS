using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ForgetPasswordMaster.Queries.GetForgetPasswordQueries
{
   public class ForgetPasswordMasterVM
    {
        public ForgetPasswordMasterVM()
        {
            Lists = new List<ForgetPasswordMasterDto>();
        }
        public IList<ForgetPasswordMasterDto> Lists { get; set; }
        public string Action { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public string useremail { get; set; }
        public string usermobile { get; set; }
        public string newpassword { get; set; }
        public string secretkey { get; set; }
        public int createdby { get; set; }
    }
}
