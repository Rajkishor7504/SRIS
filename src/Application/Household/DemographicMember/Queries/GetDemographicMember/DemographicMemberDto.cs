using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.DemographicMember.Queries.GetDemographicMember
{
    public class DemographicMemberDto
    {
        //select no of programme registered(Start) Deepak Kumar Sahu(29-09-2022)
        public int programcnt { get; set; }

        //select no of programme registered(End)

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

        public decimal logpmtscore { get; set; }
        public string pmtstatus_s { get; set; }
        public string action { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int sex { get; set; }
        public int relationshiptohhid { get; set; }
        public string uploadphotopath { get; set; }

        public string uploadphotoname { get; set; }
        public int residencestatusid { get; set; }
        public int dohavebirthcertificate { get; set; }

        public string dateofarrival { get; set; }
        public string uploadbirthcertificate { get; set; }
        public string uploadbirthcertificatepath { get; set; }
        public string dateofbirth { get; set; }
        public int ethnicityid { get; set; }
        public string otherethnicgroup { get; set; }
        public int age { get; set; }
        public int maritalstatusid { get; set; }
        public int placeofbirthid { get; set; }
        public int isfatherstillalive { get; set; }
        public int nationalityid { get; set; }
        public string othernationality { get; set; }
        public string identificationdocids { get; set; }
        public string otheridentitydocument { get; set; }
        public int fatherliveinhousehold { get; set; }
        public string recrdlineoffather { get; set; }//Add by Rajkishor Patra(04-Nov-2022)
        public string identificationno { get; set; }
        public int ismotherstillalive { get; set; }

        public string uploadidproof { get; set; }

        public int motherliveinhousehold { get; set; }
        public string recrdlineofmother { get; set; }//Add by Rajkishor Patra(04-Nov-2022)
        public string createdby { get; set; }
        public string uploadidproofpath { get; set; }
        public string membercode { get; set; }
        public int lockstatus { get; set; }
        public string uploadProffilephotoname { get; set; }


        //for view purpose
        public string hhno { get; set; }
        public string membername { get; set; }
        public string sexname { get; set; }
        public string relationshiptohh { get; set; }
        public string residencestatus { get; set; }
        public string placeofbirth { get; set; }
        public string nationality { get; set; }
        public string dohavebirthcertificates { get; set; }
        public string ethnicity { get; set; }
        public string maritalstatus { get; set; }
        public string fatherstillalive { get; set; }
        public string motherstillalive { get; set; }
        public string fatherlivesinhousehold { get; set; }
        public string motherlivesinhousehold { get; set; }
        public string householdheadname { get; set; }
        public int settlementid { get; set; }
        public string settlementcode { get; set; }
        public string hhcode { get; set; }
        public string supervisor { get; set; }
        public int residencestatusid_spt { get; set; }
        //end for view purpose

        //for view purpose after approval

        public int hhid_aft { get; set; }
        public int memberid_aft { get; set; }
        public int settlementid_aft { get; set; }
        public string settlementcode_aft { get; set; }
        public string hhno_aft { get; set; }
        public string firstname_aft { get; set; }
        public string lastname_aft { get; set; }
        public string membername_aft { get; set; }
        public string householdheadname_aft { get; set; }
        public string sexname_aft { get; set; }
        public int age_aft { get; set; }
        public int relationshiptohhid_aft { get; set; }
        public string identificationno_aft { get; set; }
        public string dateofarrival_aft { get; set; }
        public string dateofbirth_aft { get; set; }
        public int placeofbirthid_aft { get; set; }
        public int nationalityid_aft { get; set; }
        public string identificationdocids_aft { get; set; }
        public string dohavebirthcertificates_aft { get; set; }
        public int ethnicityid_aft { get; set; }
        public string maritalstatus_aft { get; set; }
        public string fatherstillalive_aft { get; set; }
        public string motherstillalive_aft { get; set; }
        public string fatherlivesinhousehold_aft { get; set; }
        public string motherlivesinhousehold_aft { get; set; }
        public string relationshiptohh_aft { get; set; }

        public string residencestatus_aft { get; set; }
        public string placeofbirth_aft { get; set; }
        public string nationality_aft { get; set; }
        public string ethnicity_aft { get; set; }
        public string uploadbirthcertificate_aft { get; set; }
        public string uploadidproof_aft { get; set; }

        public string uploadphotoname_aft { get; set; }
        public string Identificationdoc { get; set; }

        //end for view purpose


        //For Spot Checker

        public int hhid_spt { get; set; }
        public int memberid_spt { get; set; }
        public int settlementid_spt { get; set; }
        public string settlementcode_spt { get; set; }
        public string hhno_spt { get; set; }
        public string firstname_spt { get; set; }
        public string lastname_spt { get; set; }
        public string membername_spt { get; set; }
        public string householdheadname_spt { get; set; }
        public string sexname_spt { get; set; }
        public int age_spt { get; set; }
        public int relationshiptohhid_spt { get; set; }
        public string identificationno_spt { get; set; }
        public string dateofarrival_spt { get; set; }
        public string dateofbirth_spt { get; set; }
        public int placeofbirthid_spt { get; set; }
        public int nationalityid_spt { get; set; }
        public string identificationdocids_spt { get; set; }
        public string dohavebirthcertificates_spt { get; set; }
        public int ethnicityid_spt { get; set; }
        public string maritalstatus_spt  { get; set; }
        public string fatherstillalive_spt { get; set; }
        public string motherstillalive_spt { get; set; }
        public string fatherlivesinhousehold_spt { get; set; }
        public string recordlinenumberoffather_spt { get; set; }//Add By Rajkishpor Patra(04-Nov-2022)
        public string motherlivesinhousehold_spt { get; set; }
        public string recordlinenumberofmother_spt { get; set; }//Add By Rajkishpor Patra(04-Nov-2022)
        public string relationshiptohh_spt { get; set; }

        public string residencestatus_spt { get; set; }
        public string placeofbirth_spt { get; set; }
        public string nationality_spt { get; set; }
        public string ethnicity_spt { get; set; }

        public string uploadbirthcertificate_spt { get; set; }
        public string uploadbirthcertificatepath_spt { get; set;}
        public string uploadidproof_spt { get; set; }
        public string uploadidproofpath_spt { get; set; }
        public string uploadphotoname_spt { get; set; }
        public string Identificationdoc_spt { get; set; }

        public string Ticketid { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int HeadMembercount { get; set; }
        public int relationstatus { get; set; }
        public int updatestatus { get; set; }


    }
    public class IdentificationDoc
    {
        public int id { get; set; }

    }

}
