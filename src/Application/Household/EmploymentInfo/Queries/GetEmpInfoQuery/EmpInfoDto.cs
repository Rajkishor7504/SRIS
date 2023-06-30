using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery
{
    public class EmploymentInfoDto
    {
        public string action { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int employmentinfoid { get; set; }
        public int mainjobactivitylastthirtydays { get; set; }
        public int howfreequentlyworking { get; set; }
        public int workinginwhichsector { get; set; }
        public int age { get; set; }
        public string othersector { get; set; }
        public int workingstatus { get; set; }
        public int reasonfornotworking { get; set; }
        public string othereasonfornotworking { get; set; }
        public int createdby { get; set; }

        public int apptypeid { get; set; }

        //For view purpose
        public string membername { get; set; }
        public string mainjobactivitylastthirtydaysv { get; set; }
        public string howfreequentlyworkingv { get; set; }
        public string workinginwhichsectorv { get; set; }
        public string workingstatusv { get; set; }
        public string reasonfornotworkingv { get; set; }
        public string othereasonfornotworkingv { get; set; }
        public string hhno { get; set; }
        public string hhheadname { get; set; }
        public int spotchecker { get; set; }

        // Spot Checker
        public string membername_spt { get; set; }
        public string mainjobactivitylastthirtydaysv_spt { get; set; }
        public string howfreequentlyworkingv_spt { get; set; }
        public string workinginwhichsectorv_spt { get; set; }
        public string workingstatusv_spt { get; set; }
        public string reasonfornotworkingv_spt { get; set; }
        public string othereasonfornotworkingv_spt { get; set; }
        public string hhno_spt { get; set; }
        public string hhheadname_spt { get; set; }
        public int memberid_spt { get; set; }
        public int hhid_spt { get; set; }
        public int spotchecker_spt { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        

        //end for view
    }


    public class EmploymentStatusInfoDto
    {
        public string action { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int employmentinfoid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }

    }
    }
