using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class MaritalStatus
    {
        [Key]
        public int  maritalstatusid { get; set; }
       
        public string maritalstatusname { get; set; }
       
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deletedflag{ get; set; }
    }
}
