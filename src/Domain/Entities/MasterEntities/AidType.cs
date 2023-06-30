using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class AidType : BaseEntity
    {
        [Key]
        public int aidid { get; set; }
        public string aidname { get; set; }
        public string description { get; set; }
    }
}

