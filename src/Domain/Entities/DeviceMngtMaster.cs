using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class DeviceMngtMaster
    {
        [Key]
        public int deviceconfigid { get; set; }
        public string make { get; set; }
        public string model { get; set; }


        public DateTime dateofpurchase { get; set; }

        public string description { get; set; }
        public string deviceimeinumber { get; set; }

        public int createdby { get; set; }
        public int updatedby { get; set; }
        public bool deletedflag { get; set; }
        public int assignedstatus { get; set; }
    }
}
