using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Userlogin_lgouttime.Queries.Userlogin_logouttimeQuery
{
    public class Userlogin_logouttimeDto: IMapFrom<UserLogin_Logout_time>
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string user_ipadress { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
    }
}
