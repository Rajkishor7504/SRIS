using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ReasonForNotWorkings.Queries.GetReasonForNotWorking
{
    public class ReasonForNotWorkingDto:IMapFrom<ReasonForNotWorking>
    {
        public int reasonid { get; set; }
        public string reasonname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
