using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class LiveliHood : BaseEntity
    {
        [Key]
        public int livelihoodid { get; set; }
        public string livelihoodname { get; set; }
        public string description { get;set; }
    }
}

