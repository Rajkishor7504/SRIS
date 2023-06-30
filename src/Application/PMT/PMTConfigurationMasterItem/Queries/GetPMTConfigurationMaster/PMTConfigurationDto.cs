using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.PMT;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PMT.PMTConfigurationMasterItem.Queries.GetPMTConfigurationMaster
{
    public class PMTConfigurationDto: IMapFrom<PMTConfigurationMaster>
    {
        public int pmtconfigureid { get; set; }
        public string formulaname { get; set; }
        public string formulacode { get; set; }
        public string formuladescription { get; set; }
        public int planid { get; set; }
        public decimal coefficient { get; set; }
        public int  moduleid { get; set; }
        public string surveyname { get; set; }
        public int parameterid { get; set; }
        public int yesvalue { get; set; }
        public int novalue { get; set; }
        public decimal formulaconstant { get; set; }
        public decimal constant { get; set; }
        public int coefficientid { get; set; }
        public string modulename { get; set; }
        public string parametername { get; set; }
        public bool deletedflag { get; set; }
    }
}
