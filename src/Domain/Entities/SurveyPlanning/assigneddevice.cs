using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class assigneddevice
    {
        [Key]
        public int assigndeviceid { get; set; }
        public int deviceid { get; set; }
        public bool deletedflag { get; set; }
    }
}
