using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.HhInterviewStatusReport.Queries.GetHhInterviewStatusReport
{
    public class HhInterviewStatusReportDto
    {

        public string p_action { get; set; }
        public string HhNo { get; set; }
        public string HhName { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TelephoneNo { get; set; }
        public string RespondentName { get; set; }
        public string InterviewDate { get; set; }
        public string InterviewerName { get; set; }
        public string InterviewerStatus { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
        public int searchid { get; set; }
        public int rgnid { get; set; }
        public int distid { get; set; }
        public int id { get; set; }
        public string enumeratorname { get; set; }
        public string userfullname { get; set; }
        public string supervisorname { get; set; }
        public string qaverified { get; set; }
        public string qaapproved { get; set; }

    }
}
