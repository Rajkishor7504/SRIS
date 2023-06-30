using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.shocksSeverityMasters.Queries.GetshocksSeverityMaster
{
    public class shocksSeverityMasterDto : IMapFrom<shocksSeverityMaster>
    {
        public shocksSeverityMasterDto()
        {
        }
        public int severityid { get; set; }
        public string severityname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
