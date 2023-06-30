using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GrievanceReport
{
    public class GrievanceReportDto
    {
        public int totalgrievanceregistration { get; set; }
        public int totalgrievanceregistrationthroughweb { get; set; }
        public int totalgrievanceregistrationthroughportal { get; set; }
        public int pending  { get; set; }
        public int resolved { get; set; }
        public int rejected { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int roleid { get; set; }
        public int id { get; set; }
        public int grievanceconfigid { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string action { get; set; }
        public string complaindate { get; set; }
        public string ticketid { get; set; }
       
        public string name { get; set; }
        public string grievancedescription { get; set; }
        public string PendingAt { get; set; }
        public string grievancename { get; set; }
    }
}
