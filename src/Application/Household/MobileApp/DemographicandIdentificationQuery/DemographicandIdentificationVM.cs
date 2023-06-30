using SRIS.Application.Household.MobileApp.QARejectedhhList;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.DemographicandIdentificationQuery
{
   public class DemographicandIdentificationVM : CommonMobileApiStatus
    {
        public IdentificationModelVM identification { get; set; }
        public IList<DemographicModelVM> demographic { get; set; }
    }
    public class IdentificationModelVM
    {
        public string teamId { get; set; }
        public int clusterno { get; set; }
        public string hhid { get; set; }        
        public string lga { get; set; }
        public string lgaName { get; set; }
        public string ward { get; set; }
        public string wardName { get; set; }
        public string district { get; set; }
        public string districtName { get; set; }
        public string settlementId { get; set; }
        public string settlementName { get; set; }
        public string dateOfInterView { get; set; }
        public string interviewer { get; set; }
        public string area { get; set; }
        public string address { get; set; }      
        public string observation { get; set; }    
        public string latitude { get; set; }
        public string interviewResult { get; set; } 
        public string householdNo { get; set; }
        public string telephoneNo { get; set; }     
        public string compoundNo { get; set; }
        public string respondentName { get; set; }
        public string headHhName { get; set; }
        public string eaNo { get; set; }
        public string longitude { get; set; }
        public string agreeOfInterview { get; set; }
        public string surveyName { get; set; }
        public string surveyId { get; set; }
        public string iDate { get; set; }
        public string rejected_status { get; set; }       
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string hhCode { get; set; }
        public string supervisor { get; set; }
        public string interviewType { get; set; }
        public string spotchecker { get; set; }
        public string completedStatus { get; set; }
    }
    public class DemographicModelVM
    {
        public string hhid { get; set; }
        public string memberId { get; set; }
        public string demoId { get; set; }
        public string motherIsAliveId { get; set; }
        public string identificationDocId { get; set; }
        public string identDocFile { get; set; }//p
        public string motherLiveInHhId { get; set; }
        // "profileImgPath": "/storage/emulated/0/Pictures/Image (1).jpg",
        public string profileImgPath { get; set; } //p
        public string hvBirthCertfId { get; set; }
        public string residentStatusId { get; set; }
        public string residentStatus { get; set; }
        public string ethinicity { get; set; }
        public string fatherIsAliveId { get; set; }
        public string motherLiveInHh { get; set; }
        public string dateOfArival { get; set; }
        public string relationToHh { get; set; }
        public string placeOfBirth { get; set; }
        public string fatherLiveInHhId { get; set; }
        public string sexId { get; set; }
        public string sex { get; set; }
        public string nationalityId { get; set; }
        public string nationality { get; set; }
        public string dateOfBirth { get; set; }
        public string fatherIsAlive { get; set; }
        public string ethinicityId { get; set; }
        public string birthCertfFile { get; set; }
        public string maritalStatusId { get; set; }
        public string maritalStatus { get; set; }
        public string profileImgStr { get; set; }//p
        public string hvBirthCertf { get; set; }
        public string name { get; set; }
        public string placeOfBirthId { get; set; }
        public string motherIsAlive { get; set; }
        public string otherDoc { get; set; }//p
        public string identificationNo { get; set; }
        public string identificationDoc { get; set; }
        public string age { get; set; }       
        public string fatherLiveInHh { get; set; }
        public string relationToHhId { get; set; }
        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }

        // for image Retrive for mobile device
        public string profileAbsolutePath { get; set; }
        public string identImgPStr { get; set; }
        public string birthImgStr { get; set; }
        public string memberSlNo { get; set; }
        public string completedStatus { get; set; }
        public string recrdlineoffather { get; set; }  // added on 13-12-2022 by ashutosh pradhan
        public string recrdlineofmother { get; set; } // added on 13-12-2022 by ashutosh pradhan

    }
}
