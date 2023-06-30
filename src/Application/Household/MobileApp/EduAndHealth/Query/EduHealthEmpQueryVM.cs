using SRIS.Application.Household.MobileApp.QARejectedhhList;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.EduAndHealth.Query
{
   public class EduHealthEmpQueryVM:CommonMobileApiStatus
    {
        public IList<EducationModelVM> education { get; set; }
        public IList<HealthModelVM> health { get; set; }
        public IList<EmployementModelVM> employment { get; set; }
    }
    public class EducationModelVM 
    {
        
        public string eduInfoId { get; set; }// for reject Purpose(update data)
        public string hhid { get; set; }
        public string householdNo { get; set; }
        public string hhCode { get; set; }
        public string memberNameId { get; set; }
        public string memberSlNo { get; set; }
        public string memberName { get; set; }
        public string typeOfSchoolAttend { get; set; }
        public string typeOfSchoolAttendId { get; set; }
        public string neverAttendSchoolId { get; set; }
       
        public string isCurentAttendScl { get; set; }
        public string stopedGoingSchool { get; set; }

        public string lastLevelGradeCmpltId { get; set; }
        public string everAttndSchool { get; set; }
        public string isCurentAttendSclId { get; set; }
     
        public string levelGradeAttened { get; set; }
        public string stopedGoingSchoolId { get; set; }
        public string canReadWrite { get; set; }
     
        public string canReadWriteId { get; set; }
        public string levelGradeAttenedId { get; set; }
        public string neverAttendSchool { get; set; }
        public string lastLevelGradeCmplt { get; set; }

        public string everAttndSchoolId { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string stopedGoingSchoolOther { get; set; }
        public string completedStatus { get; set; }
    }


    public class HealthModelVM 
    {
        public string healthInfoId { get; set; }// for reject Purpose(update data)
        public string hhid { get; set; }
        public string householdNo { get; set; }
        public string hhCode { get; set; }
        public string memberNameId { get; set; }
        public string memberSlNo { get; set; }
        public string memberName { get; set; }
        public string difficultyHearingId { get; set; }
        public string difficultyRememberingId { get; set; }
        public string difficultySeeingId { get; set; }//p

     
        public string difficultySelfCaring { get; set; }
        public string chronicIllness { get; set; }
        public string otherIllness { get; set; }      //p  
        public string difficultyCommunicatingId { get; set; }
        //"typeOfChronicIllnessId": "5,6",
        public string typeOfChronicIllnessId { get; set; }

        public string difficultySeeing { get; set; }
        public string chronicIllnessId { get; set; }
     
         // "typeOfChronicIllness": "Hepatitis, HIV/Aids",
        public string typeOfChronicIllness { get; set; }
        public string difficultyRemembering { get; set; }

        public string difficultySelfCaringId { get; set; }
        public string difficultyWalking { get; set; }
        public string difficultyHearing { get; set; }
        public string difficultyWalkingId { get; set; }
        public string difficultyCommunicating { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }
    }
    public class EmployementModelVM 
    {
        public string empInfoId { get; set; }// for reject Purpose(update data)
        public string hhid { get; set; }
        public string householdNo { get; set; }
        public string hhCode { get; set; }
        public string memberNameId { get; set; }
        public string memberSlNo { get; set; }
        public string memberName { get; set; }

        public string mainJobId { get; set; }
        public string mainJob { get; set; }
        public string frequentlyId { get; set; }
        public string workingSectorId { get; set; }

        public string notWorkingReasonId { get; set; }
        public string workingStatusId { get; set; }
        public string notWorkingReason { get; set; }   
        public string frequently { get; set; }
    

        public string workingSector { get; set; }
       
        public string workingStatus { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }

        public string statusid { get; set; }
        
        public string notWorkingReasonOther { get; set; }
        public string completedStatus { get; set; }
    }   
}
