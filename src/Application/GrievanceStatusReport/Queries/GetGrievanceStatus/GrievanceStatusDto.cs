using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GrievanceStatusReport.Queries.GetGrievanceStatus
{
   public class GrievanceStatusDto
    {
        public string p_action { get; set; }
        public int searchid { get; set; }
        public string levelname { get; set; }
        public int levelid { get; set; }
        public string Grievancename { get; set; }
        public int Grievanceid { get; set; }
        public int rgnid { get; set; }
        public int distid { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int Totalgrievanceregister { get; set; }
        public int Approved { get; set; }
        public int Pending { get; set; }
        public int Rejected { get; set; }
        public string district { get; set; }
        public string Status { get; set; }
        public string ComplainedOn { get; set; }
        public string ComplainNo { get; set; }
        public string ComplainGivenBy { get; set; }
        public string Contactno { get; set; }
        public string Isportal { get; set; }
        public string ActionToBeTaken { get; set; }
        public string Description { get; set; }
    }
}
