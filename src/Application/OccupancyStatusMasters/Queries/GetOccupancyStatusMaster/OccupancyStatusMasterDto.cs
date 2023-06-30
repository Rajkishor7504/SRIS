using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.OccupancyStatusMasters.Queries.GetOccupancyStatusMaster
{
   public class OccupancyStatusMasterDto : IMapFrom<OccupancyStatusMaster>
    {
        public OccupancyStatusMasterDto()
        {
        }
        public bool deletedflag { get; set; }
        public string occupancyStatusName { get; set; }
        public string description { get; set; }
        public int id { get; set; }
    }
}
