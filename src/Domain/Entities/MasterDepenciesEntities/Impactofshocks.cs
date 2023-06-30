using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Impactofshocks : BaseEntity
    {
        [Key]
        public int impactid { get; set; }
        public int shockforlivestockid { get; set; }
        public int shockforcropid { get; set; }
    }
}
