using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ServiceMasterItem.Queries.GetServicesMasterQueries
{
    public class ServicesMasterDto : IMapFrom<ServicesMaster>
    {
        public ServicesMasterDto()
        {
        }
        public int serviceid { get; set; }
        public string servicename { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deleteflag { get; set; }
    }
}
