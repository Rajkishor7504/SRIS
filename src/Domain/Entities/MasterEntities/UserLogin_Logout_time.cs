using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class UserLogin_Logout_time
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public string user_ipadress { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
    }
}
