using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
  public  class BaseEntity
    {
        public int? createdby { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deletedflag { get; set; }
    }
}
