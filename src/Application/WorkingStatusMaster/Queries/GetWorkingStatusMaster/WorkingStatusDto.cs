using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.WorkingStatusMaster.Queries.GetWorkingStatusMaster
{
    public class WorkingStatusDto:IMapFrom<WorkingStatus>
    {
        public int statusid { get; set; }
        public string statusname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
