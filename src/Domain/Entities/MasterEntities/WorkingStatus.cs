using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class WorkingStatus : BaseEntity
    {
        [Key]
        public int statusid { get; set; }
        public string statusname { get; set; }
        public string description { get; set; }

    }
}
