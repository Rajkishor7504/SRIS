using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
  public  class MSurveyEnumerationArea: BaseEntity
    {
        [Key]
        public int   eaid { get; set; }
        public string eaname { get; set; }
        public int surveyplanid { get; set; }
    }
}
