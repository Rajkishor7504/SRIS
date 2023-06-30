using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;


namespace SRIS.Application.ReasonforNeverAttendSchools.Queries.GetReasonforNeverAttendSchoolQuery
{
    public class ReasonforNeverAttendSchoolDto : IMapFrom<ResonforNeverAttendSchool>
    {


        public int reasonid { get; set; }
        public string reason { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }

    }
}
