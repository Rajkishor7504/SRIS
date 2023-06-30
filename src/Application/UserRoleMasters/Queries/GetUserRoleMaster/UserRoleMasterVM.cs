using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.UserRoleMasters.Queries.GetUserRoleMaster
{
    public class UserRoleMasterVM
    {
        public IList<UserRoleMasterDto> Lists { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public string description { get; set; }
    }
}
