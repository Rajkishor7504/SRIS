using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DataRequestReport.Queries.GetDataRequestReport
{
    public class DataRequestReportDto
    {
        public string p_action { get; set; }
        public string organisationname { get; set; }
        public int organisationid { get; set; }
        public int totalnoofdatarequest { get; set; }
        public int totalnoofapproved { get; set; }
        public int totalnoofprocessed { get; set; }
        public int totalnoofpending { get; set; }
        public int totalnoofrejected { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string dateofrequest { get; set; }
        public int Noofhousehold { get; set; }
        public string Status { get; set; }
        public string requestcode { get; set; }
        //public int tt { get; set; }

    }
}
