using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class Disease : BaseEntity
    {
        [Key]
        public int diseaseid { get; set; }
        public string diseasename { get; set; }
        public string description { get; set; }
    }
}

