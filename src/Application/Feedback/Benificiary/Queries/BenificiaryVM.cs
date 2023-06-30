using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Feedback.Benificiary.Queries
{
   public class BenificiaryVM
    {
        public IList<BenificiaryDto> Lists { get; set; }
        public BenificiaryVM()
        {
            Lists = new List<BenificiaryDto>();
        }
        public int userid { get; set; }//giving userid for the filter
        public string useremail { get; set; }// giving useremail for the filter
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
       
        public string action { get; set; }
        public int createdby { get; set; }
        public int programid { get; set; }
        public string filename { get; set; }
        public int programdetailsid { get; set; }
        public string remark { get; set; }

        public string errormessege { get; set; }
        public string messege { get; set; }
        public bool deletedflag { get; set; }
    }
}
