using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SRIS.Domain.Entities.MasterEntities;

using System.Text;


namespace SRIS.Domain.Entities
{
    public class ResidenceMaster : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string residencename { get; set; }
        
        public string description { get; set; }
       
        //public int createdby { get; set; }
        
        //public int updatedby { get; set; }
       
        //public bool deletedflag { get; set; }
    }
}
