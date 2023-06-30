using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.MainJobActivityMaster.Queries.GetMainJobActivityMasterQuery
{
    public class MainJobActivityDto: IMapFrom<MainJobActivity>
    {
        public int activityid { get; set; }
        public string activityname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
