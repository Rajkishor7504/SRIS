using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class ReasonForStopSchool : BaseEntity
    {
        [Key]
        public int reasonid { get; set; }
        public string reason { get; set; }
        public string description { get; set; }
        //public int createdby { get; set; }
        //public int updatedby { get; set; }

        //public bool deletedflag { get; set; }
    }   

}
