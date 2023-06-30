using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
   public class SurveyTeamMaster:BaseEntity
    {[Key]
        public int teamid { get; set; }
        public int surveyplanid { get; set; }
        public string teamname { get; set; }
        public string description { get; set; }

    }
}
