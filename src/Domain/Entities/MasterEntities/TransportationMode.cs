using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class TransportationMode : BaseEntity
    {
        [Key]
        public int modeid { get; set; }
        public string modename { get; set; }
        public string description { get; set; }
    }   

}