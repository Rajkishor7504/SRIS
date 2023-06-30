using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class EthnicityMaster
    {
        [Key]
        public int ethnicityid { get; set; }
        public string ethnicityname { get; set; }
   
        public string description { get; set; }
        
        public int createdby { get; set; }
       
        public int updatedby { get; set; }
    
        public bool deletedflag { get; set; }
    }
}
