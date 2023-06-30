using SRIS.Application.ReasonforNeverAttendSchools.Commands.CreateReasonForNeverAttendSchoolMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.ReasonforNeverAttendSchools.Queries.GetReasonforNeverAttendSchoolQuery
{
    public class ReasonforNeverAttendSchoolVM
    {
        public IList<ReasonforNeverAttendSchoolDto> LISTS { get; set; }
        public CreateReasonforNeverAttendSchoolCommand command { get; set; }
        public int reasonid { get; set; }
        public string reason { get; set; }
        public string description { get; set; }



    }
}
