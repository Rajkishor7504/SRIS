using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
   public class GradeLevelMaster
    {
        [Key]
      
        public int gradeid { get; set; }
        public string gradename { get; set; }
        //[Required]
        public string description { get; set; }
        [Required]
        public int createdby { get; set; }
        //[Required]
        public int updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }
    }
}
