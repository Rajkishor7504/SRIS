using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem
{
    public class SurveyTeamMasterVM
    {
        public SurveyTeamMasterVM()
        {
            Lists = new List<SurveyTeamMasterDto>();
        }
        public IList<SurveyTeamMasterDto> Lists { get; set; }
        public int teamid { get; set; }
        public int surveyplanid { get; set; }
        public string teamname { get; set; }
        public string description { get; set; }
        public string surveyname { get; set; }
        public int teamdetailid { get; set; }
        public int id { get; set; }
        public int userid { get; set; }
        public int usettypeid { get; set; }
        public string userfullname { get; set; }
        public string username { get; set; }
        public int createdby { get; set; }
        public string usertypename { get; set; }
        public string deletevalue { get; set; }

    }
}
