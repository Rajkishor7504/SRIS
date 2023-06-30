using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class CookingFuel : BaseEntity
    {
        [Key]
        public int fuelid { get; set; }
        public string fuelname { get; set; }
        public string description { get; set; }

    }
}

