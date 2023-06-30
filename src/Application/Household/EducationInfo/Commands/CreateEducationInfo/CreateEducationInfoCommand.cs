using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.EducationInfo.Commands
{
    public class CreateEducationInfoCommand : IRequest<EducationInfoList>
    {
        public int educationinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int isCurrentlyAttendingSchool { get; set; }
        public int age { get; set; }
        public int whystoppedgoingschool { get; set; }

        public string otherreasonfornotgoingschool { get; set; }
        public int canreadwriteanylanguage { get; set; }
        public int haseverattendedschool { get; set; }
        public int whyneverattendedschool { get; set; }

        public string otherreasonnotattendedschool { get; set; }
        public int lastlevelcompleted { get; set; }
        public int lastgradecompleted { get; set; }
        public int typeofschoolattended { get; set; }

        public int levelattended { get; set; }
        public int gradeattended { get; set; }
        public string createdby { get; set; }
        public int apptypeid { get; set; }
        public string whatchronicillnesssuffer { get; set; }
    }
    public class CreateEducationInfoCommandHandler : IRequestHandler<CreateEducationInfoCommand, EducationInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateEducationInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<EducationInfoList> Handle(CreateEducationInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            EducationInfoList objEduList = new EducationInfoList();
            try
            {
                //if ((request.educationinfoid == 0 && request.action == "U") || (request.isCurrentlyAttendingSchool==0 || request.haseverattendedschool==0 || request.typeofschoolattended==0 || request.levelattended==0 ||  request.lastlevelcompleted==0))
                //{
                //    objEduList.status = "400";
                //    objEduList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                //}
                //else
                //{
                    var entity = new EducationInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.memberid = request.memberid;
                    entity.educationinfoid = request.educationinfoid;
                    entity.isCurrentlyAttendingSchool = request.isCurrentlyAttendingSchool;
                    entity.age = request.age;
                    entity.whystoppedgoingschool = request.whystoppedgoingschool;
                    entity.otherreasonfornotgoingschool = request.otherreasonfornotgoingschool;
                    entity.canreadwriteanylanguage = request.canreadwriteanylanguage;
                    entity.haseverattendedschool = request.haseverattendedschool;
                    entity.whyneverattendedschool = request.whyneverattendedschool;
                    entity.otherreasonnotattendedschool = request.otherreasonnotattendedschool;
                    entity.lastlevelcompleted = request.lastlevelcompleted;//what was the last (use)
                    entity.lastgradecompleted = request.lastgradecompleted;
                    entity.typeofschoolattended = request.typeofschoolattended;
                    entity.levelattended = request.levelattended;//which level (use)
                    entity.gradeattended = request.gradeattended;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddEducationInfo(entity);
                    objEduList.status = retval.ToString();
                    objEduList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                //}
            }
            catch (Exception ex)
            {
                objEduList.status = "500";
                objEduList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objEduList.errorMessage = ex.Message;
            }
            return objEduList;

        }
    }
}
