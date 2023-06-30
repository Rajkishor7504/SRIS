using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class Shocks : BaseEntity
    {
        [Key]
        public int shockid { get; set; }
        public string shockname { get; set; }
        public string description { get; set; }
    }   

}
