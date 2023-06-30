using FluentValidation;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using SRIS.Application.HhInterviewStatusReport.Queries.GetHhInterviewStatusReport;
using SRIS.Domain.Entities;

namespace SRIS.Application.LoginForMobile
{
   public class LoginVM
    {
    }
    public class LoginResponse : CommonMobileApiStatus
    {
        public GetLoginDto userDetails { get; set; }
        public IList<ValidationFailure> loginerrors { get; set; }
        public GettokenkeyDto token { get; set; }
        //public List<EnumeratorListVM> enumerator { get; set; }
    }
    public class GettokenkeyDto
    {
        public string tokenkey { get; set; }
    }
    public class GetLoginDto
    {
        public int userId { get; set; }
        public string mobile { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string gender { get; set; }
        public int userType { get; set; }
        public int spotChecker { get; set; }
        public string spotCheckerStatus { get; set; }
        public string eano { get; set; }
        public string tokenkey { get; set; }
        public string districtId { get; set; }
        public int surveyPlanId { get; set; }
        public string surveyPlanName { get; set; }
        public string imageUploadUrl { get; set; }
        public int teamId { get; set; }
        public List<EnumeratorList> enumerator { get; set; }
    }
    public class EnumeratorListVM{
        public int EnumeratorId { get; set; }
        public string EnueratorName { get; set; }
        //public List<EnumeratorListVM> enumerator { get; set; }
    }
    public class userloginmodel
    {
        public string username { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
    }
    public class userloginmodelValidator : AbstractValidator<userloginmodel>
    {
        public userloginmodelValidator()
        {
            RuleFor(x => x.username).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.password).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");
            RuleFor(x => x.userType).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");           
        }
    }
}
