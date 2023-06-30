using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.EnumerationTeam.Query
{
    public class EnumerationTeamVM: CommonMobileApiStatus
    { 
        public List<EnumerationTeamInfo> List { get; set; }
    
    }

        public class EnumerationTeamInfo
         {
        public int assigneaid { get; set; }
        public int eaid { get; set; }
        public int surveyplanid { get; set; }
        public string surveyPlan { get; set; }

       
        public string eanumber { get; set; }

        public int teamid { get; set; }
        public string teamName { get; set; }

        public int regionid { get; set; }
        public int districtid { get; set; }
        public int settlementid { get; set; }
        public int wardid { get; set; }

        public int searchid { get; set; }
        public string lgaName { get; set; }
        public string districtName { get; set; }
        public string settlementName { get; set; }
        public string wardName { get; set; }
        public int clusterNo { get; set; }
    }
}
