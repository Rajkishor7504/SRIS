using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Userlogin_lgouttime.Queries.Userlogin_logouttimeQuery
{
    public class Userlogin_logouttimeVm
    {
        public IList<Userlogin_logouttimeDto> userlogin_logouttimeDto { get; set; }
        public int id { get; set; }
        public int userid { get; set; }
        public string user_ipadress { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
    }
}
