using FluentValidation;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace SRIS.Application.Household.DemographicMember.CommandsMobile
{
   public class DemographicVM: CommonMobileApiStatus
    {
        public IList<ValidationFailuremodel> identityerrors { get; set; }
        public IList<DemoValidationFailuremodel> demographicerrors { get; set; }
        public string hhid { get; set; }       
        public List<DemoResponsemodel> demographicMemeber { get; set; }
    }

    public class DemographicModel
    {    
        public string firstname { get; set; }
        public string lastname { get; set; }     
        public string sexId { get; set; }
        public string relationToHhId { get; set; }
        public string residentStatusId { get; set; }
        public DateTime dateOfArival { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string age { get; set; }
        public string placeOfBirthId { get; set; }
        public string nationalityId { get; set; }
        public string identificationDocId { get; set; }
        public string identificationNo { get; set; }
        public string identDocFile { get; set; }
        public string identImgPStr { get; set; }
        public string profileImgStr { get; set; }
        public string profileImgPath { get; set; }       
        public string birthCertfFile { get; set; }
        public string birthImgStr { get; set; }
        public string ethinicityId { get; set; }
        public string maritalStatusId { get; set; }
        public string fatherIsAliveId { get; set; }
        public string fatherLiveInHhId { get; set; }
        public string motherIsAliveId { get; set; } 
        public string motherLiveInHhId { get; set; }
        public string hvBirthCertfId { get; set; }
        public string memberSlNo { get; set; }
        public string demoId { get; set; } // For Reject for 
        public string recrdlineoffather { get; set; }
        public string recrdlineofmother { get; set; }

        // View Purpose
        //public string name { get; set; }
        //public string ethinicity { get; set; }      
        //public string relationToHh { get; set; }
        //public string placeOfBirth { get; set; }
        //public string residentStatus { get; set; }
        //public string sex { get; set; }      
        //public string nationality { get; set; }
        //public string hvBirthCertf { get; set; }
        //public string motherLiveInHh { get; set; }
        //public string motherIsAlive { get; set; }
        //public string otherDoc { get; set; }      
        //public string maritalStatus { get; set; }
        //public string fatherLiveInHh { get; set; }
        //public string fatherIsAlive { get; set; }
        //public List<identitydocumentmodel> documentlist { get; set; }
        //public int hhid { get; set; }
        //public int memberid { get; set; }
    }

    public class identificationdto
    {
        public string teamId { get; set; }
        public string clusterno { get; set; }
        public string surveyId { get; set; }
        public string lga { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string settlementId { get; set; }      
        public string area { get; set; }
        public string eaNo { get; set; }
        public string compoundNo { get; set; }       
        public DateTime dateOfInterView { get; set; }
        public string interviewer { get; set; }
        public string supervisor { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string agreeOfInterview { get; set; }
        public string telephoneNo { get; set; }
        public string address { get; set; }
        public string interviewResult { get; set; }      
        public string observation { get; set; }
        public string respondentName { get; set; }
        public string headHhName { get; set; }
        public string spotchecker { get; set; }
        public string hhCode { get; set; }
        public string supervisorName { get; set; }

        //added on 270922
        //public string lgaName { get; set; }
        //public string districtName { get; set; }
        //public string wardName { get; set; }
        //public string settlementName { get; set; }
        //public int householdNo { get; set; }
        //public string surveyName { get; set; }
        //public DateTime iDate { get; set; }
        //public string settlementCode { get; set; }
        //public string interviewType { get; set; }
    }

    public class identificationValidator : AbstractValidator<identificationdto>
    {
        public identificationValidator()
        {
            RuleFor(x => x.surveyId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //RuleFor(x => x.clusterno).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.lga).NotNull().NotEmpty().WithMessage("{PropertyName} is required."); 
            RuleFor(x => x.district).NotNull().NotEmpty().WithMessage("{PropertyName} is required."); 
            RuleFor(x => x.ward).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.settlementId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.area).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.eaNo).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.compoundNo).NotNull().NotEmpty().Must((x, list, context) =>
            {
                if (x.compoundNo.ToString() != "")
                {
                    context.MessageFormatter.AppendArgument("compoundNo", x.compoundNo);
                    return Int32.TryParse(x.compoundNo.ToString(), out int number);
                }
                return true;
            })
            .WithMessage("{PropertyName}  must be a number.");           
            RuleFor(x => x.dateOfInterView).NotNull().NotEmpty().WithMessage("{PropertyName}  is required.")
            .LessThan(p => DateTime.Now).WithMessage("{PropertyName} Should be less than today date");
            RuleFor(x => x.interviewer).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.supervisor).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.agreeOfInterview).NotNull().NotEmpty().Must(x=>x=="1").WithMessage("{PropertyName} is required.");
            When(x => x.agreeOfInterview == "1", () => {
            RuleFor(x => x.respondentName).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.headHhName).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.interviewResult).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.address).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.spotchecker).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
              
            });
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
            //RuleFor(product => product.name).NotNull().NotEmpty();
        }
    }
   
    public class demographicModelValidator : AbstractValidator<DemographicModel>
    {
        public demographicModelValidator()
        {
          
            RuleFor(x =>x. firstname).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x =>x. lastname).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.sexId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.residentStatusId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.nationalityId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

            //When(x => x.residentStatusId != "2", () => {
            //    RuleFor(x => x.dateOfArival).NotNull().NotEmpty().WithMessage("{PropertyName}  is required.")
            //   .LessThan(p => DateTime.Now).WithMessage("{PropertyName} Should be less than today date");
            //});
            RuleFor(x =>x.dateOfBirth).NotNull().NotEmpty().WithMessage("{PropertyName}  is required.")
            .LessThan(p => DateTime.Now).WithMessage("{PropertyName} Should be less than today date");
            //RuleFor(x => Convert.ToInt32(x.age)).NotNull().NotEmpty().InclusiveBetween(0, 95).WithMessage("{PropertyName} is required.");
            RuleFor(x => x.placeOfBirthId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.profileImgPath).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.profileImgStr).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            //RuleFor(x => x.birthCertfFile).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //RuleFor(x => x.birthImgStr).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //RuleFor(x => x.identDocFile).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //RuleFor(x => x.identImgPStr).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //RuleFor(x => x.identificationDocId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");//for now

              RuleFor(x => x.identificationNo).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
              When(x => x.nationalityId == "1", () =>
              {
                 RuleFor(x => x.ethinicityId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
              });
              When(x => Convert.ToInt32(x.age) > 12, () =>
              {
                 RuleFor(x => x.maritalStatusId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
              });
              RuleFor(x => x.identificationDocId).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
        }
    }
    public class DemoResponsemodel
    {
        public int id { get; set; }
        public string memeberName { get; set; }
    }
    public class ValidationFailuremodel
    {
        public string propertyName { get; set; }
        public string errorMessage { get; set; }
        public object attemptedValue { get; set; }
    }
    public class DemoValidationFailuremodel
    {
        public List<ValidationFailure> demoerrors { get; set; }
    }
}
