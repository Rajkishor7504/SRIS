using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class DisposeRubbish : BaseEntity
    {
        [Key]
        public int disposeid { get; set; }
        public string disposename { get; set; }
        public string description { get; set; }
    }
}

