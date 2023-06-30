using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class DrinkingSource : BaseEntity
   {
        [Key]
        public int sourceid { get; set; }
        public string sourcename { get; set; }
        public string description { get; set; }
   }  

}
