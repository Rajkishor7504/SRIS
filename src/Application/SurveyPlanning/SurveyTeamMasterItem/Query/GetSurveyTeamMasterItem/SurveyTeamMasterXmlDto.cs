using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem
{
   public class SurveyTeamMasterXmlDto
    {
        [Key]
        public int surveyplanid { get; set; }
        public string teamname { get; set; }
        public string description { get; set; }
        public int userid { get; set; }
        public int usettypeid { get; set; }
    }
}
