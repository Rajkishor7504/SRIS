using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.DeviceManagementMaster.Queries.GetDeviceManagementMaster
{
    public class DeviceMngtMasterDto : IMapFrom<DeviceMngtMaster>
    {
        public DeviceMngtMasterDto()
        {
        }
        public int deviceconfigid { get; set; }
        public string make { get; set; }
        public string model { get; set; }

        [DataType(DataType.Date)]
        public DateTime dateofpurchase { get; set; }
        public string description { get; set; }
        public string deviceimeinumber { get; set; }
        public int assignedstatus { get; set; }
        public string status { get; set; }
        public bool deletedflag { get; set; }

    }

}
