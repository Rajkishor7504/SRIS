using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem
{
    public class SurveyTeamMasterDto:IMapFrom<SurveyTeamMaster>
    {[Key]
        public int teamid { get; set; }
        public int surveyplanid { get; set; }
        public string teamname { get; set; }
        public string description { get; set; }
        public string surveyname { get; set; }
        public int teamdetailid { get; set; }
        public int teamdetailid1 { get; set; }
        public int id { get; set; }
        public int userid { get; set; }
        public int userid1 { get; set; }
        public int usettypeid { get; set; }
        public int usettypeid1 { get; set; }
        public string userfullname { get; set; }
        public string username { get; set; }
        public string action { get; set; }
        public int? createdby { get; set; }
        public DateTime createdon { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        public bool deletedflag { get; set; }
        public List<SurveyTeamMasterDto> Lists { get; set; }
        public string usertypename { get; set; }
        public string deletevalue { get; set; }
        public int planid { get; set; }
        public int searchid { get; set; }


    }
}
