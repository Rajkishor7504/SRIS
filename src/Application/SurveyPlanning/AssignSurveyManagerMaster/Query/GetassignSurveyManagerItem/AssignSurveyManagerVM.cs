using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Query.GetassignSurveyManagerItem
{
    public class AssignSurveyManagerVM
    {
        public AssignSurveyManagerVM()
        {
            Lists = new List<AssignSurveyManagerDto>();
        }
        public IList<AssignSurveyManagerDto> Lists { get; set; }
        public int assignmanagerid { get; set; }
        public int surveyplanid { get; set; }
        public int userid { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
        public string surveyname { get; set; }
        public string userfullname { get; set; }
    }
}
