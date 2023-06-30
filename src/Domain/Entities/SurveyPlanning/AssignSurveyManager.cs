using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
    public class AssignSurveyManager: BaseEntity
    {[Key]
    public int assignmanagerid { get; set; }
        public int surveyplanid { get; set; }
        public int userid { get; set; }

    }
}
