using SRIS.Application.SurveyPlanning.EnumerationArea.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.EnumerationTeam.Command
{
   public class EnumerationTeamDto
    {
        public int assigneaid { get; set; }
        public int createdby { get; set; }
        public int surveyplanid { get; set; }    
        public string action { get; set; }
        public int teamid { get; set; }       
        public int eaid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int settlementid { get; set; }
        public int wardid { get; set; }
        public int clusterno { get; set; }
        public List<EnumerationTeamModel>settlementdata { get; set; }
        public List<EnumerationAreaModel> List { get; set; }
    }
    public class EnumerationTeamModel
    {       
        public int settlementid { get; set; }
       
    }
}
