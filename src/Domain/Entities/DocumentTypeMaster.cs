using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class DocumentTypeMaster
    {
        [Key]
        public int id { get; set; }
        public string documentType { get; set; }
        //[Required]
        public string description { get; set; }
  
        public int createdby { get; set; }
        //[Required]
        public int updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }
    }
}
