using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class ToiletType : BaseEntity
    {
        [Key]
        public int typeid { get; set; }
        public string typename { get; set; }
        public string description { get; set; }
    }
}

