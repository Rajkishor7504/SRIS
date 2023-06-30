using SRIS.Application.ReasonforNeverAttendSchools.Queries.GetReasonforNeverAttendSchoolQuery;
using SRIS.Application.ReasonForStopSchools.Commands.CreateReasonForStopSchoolMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ReasonForStopSchools.Queries.GetReasonForStopSchoolQueryMaster
{
    public class ReasonForStopSchoolVM
    {
        public IList<ReasonForStopSchoolDto> Lists { get; set; }
        public CreateReasonForStopSchoolCommand command { get; set; }
        public int reasonid { get; set; }
        public string reason { get; set; }
        public string description { get; set; }
    }
}
