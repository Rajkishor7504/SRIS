using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SRIS.Domain.Entities.MasterEntities;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class NationalityMaster:BaseEntity
    {
        [Key]
        public int nationalityid { get; set; }
        public string nationality { get; set; }
        
        public string description { get; set; }
      
        //public int createdby { get; set; }
        //[Required]      
        //public int updatedby { get; set; }
        //[Required]
        //public bool deletedflag { get; set; }
    }
}
