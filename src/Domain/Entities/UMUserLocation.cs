using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class UMUserLocation:BaseEntity
    {[Key]
        public int userlocid { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
        public int locationid { get; set; }

    }
}
