using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Queries.GetSettlementWiseTargetMasterQuery
{
    public class SettlementWiseTargetDto: IMapFrom<SettlementWiseTarget>
    {
        [Key]
        public int stargetid { get; set; }
        public string eano { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int enumdetailid { get; set; }
        public int householdtarget { get; set; }
        public string action { get; set; }
        public string eaname { get; set; }
        public int surveyplanid { get; set; }
        public int eaid { get; set; }
        public int planid { get; set; }
        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public int createdby { get; set; }
        public int searchid { get; set; }
        public List<SettlementWiseTargetDto> Lists { get; set; }
        public int actualdata { get; set; }
        public int clusterno { get; set; }

    }
}
