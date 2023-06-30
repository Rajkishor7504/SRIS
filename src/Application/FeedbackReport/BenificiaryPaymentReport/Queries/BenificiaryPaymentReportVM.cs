using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.FeedbackReport.BenificiaryPaymentReport.Queries
{
    public class BenificiaryPaymentReportVM 
    {
        public IList<BenificiaryPaymentReportDto> Lists { get; set; }
        public BenificiaryPaymentReportVM()
        {
            Lists = new List<BenificiaryPaymentReportDto>();
        }
       
        public IList<BenificiaryPaymentReportDto> ReportLists { get; set; }
        public string slno { get; set; }

        public int datarequest_id { get; set; }
        public string program_Code { get; set; }
        public string program_Name { get; set; }
        public int benificiaryid { get; set; }
        //public string Program_Name { get; set; }
        //public string Program_Code { get; set; }
        public string householdno { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int regionid { get; set; }
        public int lga { get; set; }
        public int district { get; set; }
        public int town { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string householdnumber { get; set; }
        public string householdpaid { get; set; }
        public string orgname { get; set; }
        public bool deletedflag { get; set; }
        public int p_id { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }

        public int programdetailsid { get; set; }

        public int Request_UserId { get; set; }

        public int organisationid { get; set; }
        public string organisationname { get; set; }
        public int organizationid { get; set; }

        public int programdtlsid { get; set; }

        public int household { get; set; }




        public string benificiaryname { get; set; }
        public string location { get; set; }
        public string idnumber { get; set; }



        public string householdhead { get; set; }
        //public string enrollmentstatus { get; set; }
        public string regdate { get; set; }
        public string gender { get; set; }
        public int datarequestid { get; set; }

      //  public int pageno { get; set; }
       // public int pagesize { get; set; }
        public int totalrecords { get; set; }

        public string settlement { get; set; }
        public string districtt { get; set; }
        public string ward { get; set; }
        public int id { get; set; }
        public string RegistrationDate { get; set; }
        public string EnrollmentStatus { get; set; }

    }
}
