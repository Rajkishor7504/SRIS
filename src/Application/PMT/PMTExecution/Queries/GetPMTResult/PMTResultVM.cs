using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRIS.Application.PMT.PMTExecution.Queries.GetPMTResult
{
    public class PMTResultVM
    {
        public PMTResultVM()
        {
            PMTResultParameterLists = new List<PMTResultParameterDto>();
        }
        public string action { get; set; }
        public string locationid { get; set; }
        //public int locationid { get; set; }
        public int surveyid { get; set; }
        public int pmtconfigureid { get; set; }
        public int resultid { get; set; }
        public IList<PMTResultDto> Lists { get; set; }
        public IList<PMTResultParameterDto> PMTResultParameterLists { get; set; }
        public IList<PMTCategoryWiseCountDto> PMTCategoryWiseCountLists { get; set; }
        public IList<PMTReportWiseCountDto> PMTReportWiseCountLists { get; set; }
        public string TotalCalculatedValue
        {
            get
            {
                if (this.PMTResultParameterLists != null && this.PMTResultParameterLists.Count > 0)
                {
                    return String.Format("{0:0.000}", this.PMTResultParameterLists.Select(t => t.formulavalue).Sum());
                }
                else
                    return "0";
            }
        }
        public string TotalPMTValue
        {
            get
            {
                if (this.PMTResultParameterLists != null && this.PMTResultParameterLists.Count > 0)
                {
                    return String.Format("{0:0.000}", this.PMTResultParameterLists.Select(t => t.formulavalue).Sum() + this.PMTResultParameterLists[0].formulaconstant);
                }
                else
                    return "0";
            }
        }
        public string LogTotalPMTValue
        {
            get
            {
                if (this.PMTResultParameterLists != null && this.PMTResultParameterLists.Count > 0)
                {
                    return PMTResultParameterLists[0].Logpmtscore.ToString();
                }
                else
                    return "0";
            }
        }
        public string resultIds { get; set; }
        public int hhstatus { get; set; }
        public string remarks { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
    }
}
