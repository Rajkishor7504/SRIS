using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SRIS.Domain.Entities.MasterEntities;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class RelationMaster : BaseEntity
    {
       [Key]
        public int id { get; set; }
        public string relationname { get; set; }
        [Required]
        public string description { get; set; }
        
        //public int createdby { get; set; }
        //[Required]
        //public int updatedby { get; set; }
        //[Required]
        //public bool deletedflag { get; set; }
    }
}
