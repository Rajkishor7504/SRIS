using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class ServicesMaster 
    {
        [Key]
        public int serviceid { get; set; }
        public string servicename { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deleteflag { get; set; }

    }
}

