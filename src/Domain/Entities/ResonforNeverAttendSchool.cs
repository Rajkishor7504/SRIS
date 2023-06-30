using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class ResonforNeverAttendSchool : BaseEntity
    {
        [Key]
        public int reasonid { get; set; }
        [Required]
        public string reason { get; set; }
        public string description { get; set; }

        //[Required]
        //public int createdby { get; set; }
        //[Required]
        //public int updatedby { get; set; }
        //[Required]
        //public bool deletedflag { get; set; }
    }
}
