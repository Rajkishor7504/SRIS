using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
    public class SurveyTeamDetails:BaseEntity
    {[Key]
        public int teamdetailid { get; set; }
        public int teamid { get; set; }
        public int userid { get; set; }
        public int usettypeid { get; set; }
    }
}
