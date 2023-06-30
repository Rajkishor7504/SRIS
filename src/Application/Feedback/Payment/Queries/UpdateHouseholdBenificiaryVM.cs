using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Feedback.Payment.Queries
{
    public class UpdateHouseholdBenificiaryVM : CommonMobileApiStatus
    {
        public string programmecode { get; set; }
        public string username { get; set; }
        public string remark { get; set; }
      
    }
        public class UpdateHouseholdDto
        {
       
            public string programmname { get; set; }
            public string programmcode { get; set; }
            public string district { get; set; }
            public string ward { get; set; }
            public string settlement { get; set; }
            public string sector { get; set; }
            public string memberid { get; set; }
            public string householdnumber { get; set; }
            public string benificiaryname { get; set; }
            public string enrollmentstartdate { get; set; }
            public string enrollmentenddate { get; set; }
            public decimal amount { get; set; }
            public string transferfreq { get; set; }
        }
    
}
