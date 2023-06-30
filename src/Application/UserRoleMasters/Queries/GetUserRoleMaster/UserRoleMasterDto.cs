using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.UserRoleMasters.Queries.GetUserRoleMaster
{
    public class UserRoleMasterDto : IMapFrom<UserRoleMaster>
    {
        public string action { get; set; }
        public int roleid { get; set; }

        public string rolename { get; set; }
        
        public string description { get; set; }
        public int createdby { get; set; }
        public bool deletedflag { get; set; }
    }
}
