using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.SurveyPlanning
{
    public class SettlementWiseTarget:BaseEntity
    {[Key]
        public int stargetid { get; set; }
        public string eano { get; set; }
        public int enumdetailid { get; set; }
        public int householdtarget { get; set; }

    }
}
