using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class LiveStock : BaseEntity
    {
        [Key]
        public int livestockid { get; set; }
        public string livestockname { get; set; }
        public string description { get; set; }
    }
}

