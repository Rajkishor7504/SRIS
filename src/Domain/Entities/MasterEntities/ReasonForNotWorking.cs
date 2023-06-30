using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class ReasonForNotWorking : BaseEntity
    {
        [Key]
        public int reasonid { get; set; }
        public string reasonname { get; set; }
        public string description { get; set; }

    }
    

}
