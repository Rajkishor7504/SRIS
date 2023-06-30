using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PMT.PMTConfigurationMasterItem.Queries.GetPMTConfigurationMaster
{
    public class PMTConfigurationVM
    {
        public PMTConfigurationVM()
        {
            Lists = new List<PMTConfigurationDto>();
        }
        public IList<PMTConfigurationDto> Lists { get; set; }
        public PMTConfigurationDto pmtConfigdto { get; set; }
        public int pmtconfigureid { get; set; }
        public string formulaname { get; set; }
        public string formulacode { get; set; }
        public string formuladescription { get; set; }
        public int planid { get; set; }
        public decimal formulaconstant { get; set; }
        public decimal coefficient { get; set; }
        public decimal constant { get; set; }
        public int yesvalue { get; set; }
        public int novalue { get; set; }
        public string surveyname { get; set; }
        public string modulename { get; set; }
        public string parametername { get; set; }
        

    }
}
