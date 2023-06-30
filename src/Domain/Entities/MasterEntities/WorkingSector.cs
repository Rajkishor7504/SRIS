using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class WorkingSector : BaseEntity
    {
        [Key]
        public int sectorid { get; set; }
        public string sectorname { get; set; }
        public string description { get; set; }

    }
}
