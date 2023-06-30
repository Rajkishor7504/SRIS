using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Feedback.Payment.Queries
{
   public class PaymentDto
    {
        public int userid { get; set; }//giving userid for the filter
        public string useremail { get; set; }// giving useremail for the filter
        public string action { get; set; }
        public string programname { get; set; }
        public string programcode { get; set; }
        public int createdby { get; set; }
        public int programid { get; set; }
        public string filename { get; set; }
        public int programdetailsid { get; set; }
        public List<PaymentDto> Lists { get; set; }
        //public string firstname { get; set; }

        //public string middlename { get; set; }

        //public string lastname { get; set; }
        public string benificiaryname { get; set; }
        public string householdno { get; set; }
       public string householdnumber { get; set; }
        public string location { get; set; }
        public string paymenttype { get; set; }
        public decimal amounttodate { get; set; }
        public decimal amountinlastcycle { get; set; }
        public DateTime dateofcashtransefer { get; set; }
        public DateTime datesofactualtransefer { get; set; }
        public string proxyrecipientname { get; set; }
        public DateTime dobofproxy { get; set; }
        public string genderofproxy { get; set; }
        public string relationofproxytorecipient { get; set; }
        public string paymentserviceprovider { get; set; }
        public string createddate { get; set; }
        public string orgname { get; set; }
        public DateTime regdate { get; set; }
        public string remark { get; set; }

        public int documentType { get; set; }
        // NEW COLUMN ADD
        public string status { get; set; }
        public int statusid { get; set; }
        public string approvalremarks { get; set; }

        //Newly added on 05-Jan-2021
        public string District { get; set; }
        public string Ward { get; set; }
        public string Settlement { get; set; }
        public string Sector { get; set; }
        public string MemberID { get; set; }
        public string EnrollmentStatus { get; set; }
        public string Benefits { get; set; }
        public string TransferFreq { get; set; }
        public string programmecode { get; set; }
        public string programmname { get; set; }
        public string hhid { get; set; }
        public string membercode { get; set; }
        public DateTime enrollmentstartdate { get; set; }
        public DateTime enrollmentenddate { get; set; }
       // public int documentType { get; set; }
    }

    public class ExternalPaymentDto
    {
        public string programname { get; set; }
        public string programcode { get; set; }
        //public int programid { get; set; }
        public string filename { get; set; }
        public string username { get; set; }
        public DateTime createdon { get; set; }
        public bool deletedflag { get; set; }
        public string remark { get; set; }
        public int documentType { get; set; }
    }
}
