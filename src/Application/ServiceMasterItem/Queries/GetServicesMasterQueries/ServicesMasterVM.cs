using SRIS.Application.ServiceMasterItem.Command.CreateServiceMasterItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ServiceMasterItem.Queries.GetServicesMasterQueries
{
    public class ServicesMasterVM
    {
        public IList<ServicesMasterDto> Lists { get; set; }
        public CreateServiceMasterCommand command { get; set; }
        public int serviceid { get; set; }
        public string servicename { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deleteflag { get; set; }
    }
}
