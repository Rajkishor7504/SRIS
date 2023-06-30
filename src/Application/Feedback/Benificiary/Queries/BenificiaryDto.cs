using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Feedback.Benificiary.Queries
{
  public class BenificiaryDto
    {
        public int userid { get; set; }//giving userid for the filter
        public string useremail { get; set; }// giving useremail for the filter
        public string action { get; set; }
        public int datarequest_id { get; set; }
        public string Program_Name { get; set; }
        public string Program_Code { get; set; }
        public string slno { get; set; }
        //public string firstname { get; set; }
        //public string lastname { get; set; }
        //public string middlename { get; set; }
        public string benificiaryname { get; set; }
        public string idnumber { get; set; }
        public string location { get; set; }
        public string programname { get; set; }
        public string programcode { get; set; }
        public string householdno { get; set; }
        public string householdhead { get; set; }
        public string gender { get; set; }
        public DateTime regdate { get; set; }
        public string enrollmentstatus { get; set; }
       
        public int createdby { get; set; }
        public List<BenificiaryDto> Lists { get; set; }
        public int programid { get; set; }
        public string filename { get; set; }
        public string createddate { get; set; }
        public int programdetailsid { get; set; }
        public int Request_UserId { get; set; }
        public string orgname { get; set; }
        public string remark { get; set; }


        public string status { get; set; }
        public int statusid { get; set; }
        public string approvalremarks { get; set; }
    }
}
