using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ReasonForStopSchools.Queries.GetReasonForStopSchoolQueryMaster
{
    public class ReasonForStopSchoolDto: IMapFrom<ReasonForStopSchool>
    {

        public bool deletedflag { get; set; }
        public int reasonid { get; set; }
        public string reason { get; set; }
        public string description { get; set; }

    }
}
