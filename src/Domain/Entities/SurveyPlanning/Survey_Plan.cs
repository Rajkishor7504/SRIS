using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
    public class Survey_Plan:BaseEntity
    {[Key]
        public int planid { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
       
        public DateTime surveyextendeddate { get; set; }
        public string description { get; set; }
        public string surveyname { get; set; }
        public int status { get; set; }
    }
}
