using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class shocksSeverityMaster : BaseEntity
    {
        [Key]
        public int severityid { get; set; }
        public string severityname { get; set; }
        public string description { get; set; }


    }
}
