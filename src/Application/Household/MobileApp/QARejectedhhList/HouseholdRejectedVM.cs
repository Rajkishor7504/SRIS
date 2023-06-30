using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.QARejectedhhList
{
   public class HouseholdRejectedVM: CommonMobileApiStatus
    {
        public IList<HouseholdRejectedDto> rejectedList { get; set; }
    }
    public class HouseholdRejectedDto
    {
        public string hhid { get; set; }
        public string householdNo { get; set; }
        public string surveyPlan { get; set; }
        public string compoundNo { get; set; }
        public string EANo { get; set; }
        public string HeadMember { get; set; }
        public string address { get; set; }
        public string interviewdate { get; set; }
        public string hhCode { get; set; }
    }
   

}
