using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
  public  class TSurveyEnumerationArea: BaseEntity
    {
        [Key]
        public int enumdetailid { get; set; }
        public int eaid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int settlementid { get; set; }



        



    }
}
