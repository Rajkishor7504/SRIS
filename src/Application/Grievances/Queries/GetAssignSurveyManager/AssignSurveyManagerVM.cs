using System.Collections.Generic;

namespace SRIS.Application.Grievances.Queries.GetAssignSurveyManager
{
    public class AssignSurveyManagerVM
    {
        public IList<AssignSurveyManagerDto> Lists { get; set; }
        public int pkid { get; set; }
        public int grievanceid { get; set; }
        public int planid { get; set; }
        public string surveymanager { get; set; }
        public string surveyname { get; set; }
        public int surveymanagerid { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
        public string remarks { get; set; }
    }
}
