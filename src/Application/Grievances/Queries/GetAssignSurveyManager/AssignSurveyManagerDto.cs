using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using System;

namespace SRIS.Application.Grievances.Queries.GetAssignSurveyManager
{
    public class AssignSurveyManagerDto : GrievanceRegisteredDto
    {
        public int pkid { get; set; }
        public int grievanceid { get; set; }
        public int planid { get; set; }
        public string surveymanager { get; set; }
        public string surveyname { get; set; }
        public int surveymanagerid { get; set; }
        public int createdby { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
        public string remarks { get; set; }
        public DateTime remarksgivendate { get; set; }
        public int remarkstatus { get; set; }
    }
}
