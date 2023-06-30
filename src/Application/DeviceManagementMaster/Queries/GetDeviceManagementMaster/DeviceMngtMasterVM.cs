using SRIS.Application.DeviceManagementMaster.Commands.CreateDeviceManagementMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.DeviceManagementMaster.Queries.GetDeviceManagementMaster
{
    public class DeviceMngtMasterVM
    {
        public IList<DeviceMngtMasterDto> Lists { get; set; }
        public CreateDeviceManagementMasterCommand command { get; set; }
        public int deviceconfigid { get; set; }
        public string make { get; set; }
        public string model { get; set; }       
        public DateTime dateofpurchase { get; set; }
        public string description { get; set; }
        public string deviceimeinumber { get; set; }
        public int assignedstatus { get; set; }
        public bool deletedflag { get; set; }
    }
}
