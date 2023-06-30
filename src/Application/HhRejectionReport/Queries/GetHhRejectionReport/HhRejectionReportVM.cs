using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.HhRejectionReport.Queries.GetHhRejectionReport
{
   public class HhRejectionReportVM
    {
        public HhRejectionReportVM()
        {
            Lists = new List<HhRejectionReportDto>();
        }
        public IList<HhRejectionReportDto> Lists { get; set; }
        public string p_action { get; set; }
        public int surveyplanid { get; set; }
        public string surveyname { get; set; }
        public int splanid { get; set; }
        public string levelname { get; set; }
        public int levelid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int QA_Officer_Reject { get; set; }
        public int QA_Supervisor_Reject { get; set; }
        public int settlementid { get; set; }
        public string hhcode { get; set; }
        public string hhheadname { get; set; }
        public string Enumrator { get; set; }
        public string Supervisor { get; set; }
        public string Enumration_Area { get; set; }
        public string Rejectiondate { get; set; }
        public string rejectedby { get; set; }
    }
}
