using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;


namespace SRIS.Application.Household.DemographicMember.Queries.GetDemographicMember
{
    public class DemographicMemberVM: CommonMobileApiStatus
    {
        public IList<DemographicMemberDto> Lists { get; set; }
        public IList<IdentificationDoc> DocumentList { get; set; }
        //This Entities Using For Programme Details(Popup) (Start)
        public string Program_Code { get; set; }
        public string Program_Name { get; set; }
        public string benificiaryname { get; set; }
        public string member_code { get; set; }
        public string location { get; set; }
        public string householdno { get; set; }
        public string householdhead { get; set; }
        public string gender { get; set; }
        public string regdate { get; set; }
        public string enrollmentstatus { get; set; }

        //This Entities Using For Programme Details(Popup) (End)

        //select no of programme registered(Start) Deepak Kumar Sahu(29-09-2022)
        public int programcnt { get; set; }

        //select no of programme registered(End)
    }
}
