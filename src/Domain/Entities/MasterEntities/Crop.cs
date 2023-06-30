using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class Crop : BaseEntity
    {
        [Key]
        public int cropid { get; set; }
        public string cropname { get; set; }
        public string description { get; set; }
    }
    

}
