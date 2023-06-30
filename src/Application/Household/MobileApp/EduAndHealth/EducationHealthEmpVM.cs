using FluentValidation;
using SRIS.Application.Household.DemographicMember.CommandsMobile;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.EduAndHealth
{
   public class EducationHealthEmpVM: CommonMobileApiStatus
    {
        public IList<educationValidationFailuremodel> educationerrors { get; set; }
        public IList<healthValidationFailuremodel> healtherrors { get; set; }
        public IList<employementValidationFailuremodel> employementrrors { get; set; }
       
      
    }
    #region-----------education-------
    public class HHEducationDto
    {
        public string eduInfoId { get; set; }// for reject Purpose(update data)
        public string memberId { get; set; }
        public string hhid { get; set; }
        public string action { get; set; }
        public string createdby { get; set; }
        public string apptypeid { get; set; }      
        public string neverAttendSchoolId { get; set; }
        public string lastLevelGradeCmpltId  { get; set; }
        public string isCurentAttendSclId { get; set; }
        public string stopedGoingSchoolId { get; set; }
        public string canReadWriteId { get; set; }
        public string levelGradeAttenedId { get; set; }
        public string typeOfSchoolAttendId { get; set; }          
        public string otherreasonfornotgoingschool { get; set; }       
        public string otherreasonnotattendedschool { get; set; }        
        public string everAttndSchoolId { get; set; }
        public int hd { get; set; }
        public int emd { get; set; }

        //public string age { get; set; }   
        //public string lastgradecompleted { get; set; }
    }
    public class educationValidationFailuremodel
    {
        public IList<ValidationFailuremodel> errors { get; set; }
    }
    public class educationValidator : AbstractValidator<HHEducationDto>
    {
        public educationValidator()
        {
            RuleFor(x => x.action).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.memberId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.hhid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.createdby).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.apptypeid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.neverAttendSchoolId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.neverAttendSchoolId == "1001", () => {
                RuleFor(x => x.otherreasonnotattendedschool).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required."); //if yes then
            });
            RuleFor(x => x.lastLevelGradeCmpltId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.isCurentAttendSclId).NotNull().WithMessage("{PropertyName} is required.");
            //When(x => x.isCurentAttendSclId == "1", () => {
            //    RuleFor(x => x.stopedGoingSchoolId).NotNull().NotEmpty().WithMessage("{PropertyName} is required."); //if yes then
            //});
            RuleFor(x => x.stopedGoingSchoolId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.stopedGoingSchoolId == "1001", () => {
                RuleFor(x => x.otherreasonfornotgoingschool).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required."); //if yes then
            });
            RuleFor(x => x.canReadWriteId).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.levelGradeAttenedId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.typeOfSchoolAttendId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
          
          
           
            RuleFor(x => x.everAttndSchoolId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //When(x => x.typeOfSchoolAttendId == "1", () => {
            //    RuleFor(x => x.gradeattendedId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");//if yes then
            //});
        }
    }
    #endregion
    #region-----------health-------
    public class HHHealthDto
    {
        public string healthInfoId { get; set; }// for reject Purpose(update data)
        public string memberId { get; set; }
        public string hhid { get; set; }
        public string action { get; set; }
        public string createdby { get; set; }
        public string apptypeid { get; set; }     
       
        public string typeOfChronicIllnessId { get; set; }    //1,2,3  
        public string difficultyHearingId { get; set; }
        public string difficultyWalkingId { get; set; }
        public string difficultyRememberingId { get; set; }
        public string difficultySeeingId { get; set; }
        public string difficultySelfCaringId { get; set; }
        public string difficultyCommunicatingId { get; set; }   
        // public string difficultyWearingGlassId { get; set; }
        public string chronicIllnessId { get; set; }// 0 or 1
        // public string otherillness { get; set; }
       
    }

    public class healthValidator : AbstractValidator<HHHealthDto>
    {
        public healthValidator()
        {
            RuleFor(x => x.action).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.memberId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.hhid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.createdby).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.apptypeid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.chronicIllnessId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.chronicIllnessId == "1", () => {
                RuleFor(x => x.typeOfChronicIllnessId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");//if yes then
            });
            RuleFor(x => x.difficultyHearingId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");         
            RuleFor(x => x.difficultyRememberingId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.difficultySeeingId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.difficultySelfCaringId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.difficultyWalkingId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.difficultyCommunicatingId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
    public class healthValidationFailuremodel
    {
        public IList<ValidationFailuremodel> errors { get; set; }
    }
    #endregion

    #region-----------employement-------
    public class HHemployementDto
    {
        public string empInfoId { get; set; }// for reject Purpose(update data)
        public string memberId { get; set; }
        public string hhid { get; set; }
        public string action { get; set; }
        public string createdby { get; set; }
        public string apptypeid { get; set; }

        public string mainJobId { get; set; }
        public string frequentlyId { get; set; }
        public string workingSectorId { get; set; }
        public string othersector { get; set; }
        public string workingStatusId { get; set; }
        public string notWorkingReasonId { get; set; }
        public string notWorkingReason { get; set; }
        
    }
  
    public class employementValidator : AbstractValidator<HHemployementDto>
    {
        public employementValidator()
        {
            RuleFor(x => x.action).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.memberId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.hhid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.createdby).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.apptypeid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
          
            RuleFor(x => x.mainJobId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.frequentlyId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.workingSectorId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.workingStatusId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.notWorkingReasonId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
    public class employementValidationFailuremodel
    {
        public IList<ValidationFailuremodel> errors { get; set; }
    }
    #endregion
}
