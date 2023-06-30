using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo;
using SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery;
using SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.EduAndHealth
{
  public  class RejectEducationHealthEmp : IRequest<EducationHealthEmpVM>
    {

        public List<HHEducationDto> education { get; set; }
        public List<HHHealthDto> health { get; set; }
        public List<HHemployementDto> employment { get; set; }
    }
    public class RejectEducationHealthEmpHandler : IRequestHandler<RejectEducationHealthEmp, EducationHealthEmpVM>
    {


        private readonly IHouseholdService _iHouseholdService;
        private readonly IHouseholdServiceMobile _iHouseholdServiceMobile;


        public RejectEducationHealthEmpHandler(IHouseholdService iHouseholdService, IHouseholdServiceMobile iHouseholdServiceMobile)
        {
            _iHouseholdService = iHouseholdService;
            _iHouseholdServiceMobile = iHouseholdServiceMobile;
        }

        public async Task<EducationHealthEmpVM> Handle(RejectEducationHealthEmp createrequest, CancellationToken cancellationToken)
        {

            int eduretval = 0;
            int healthretval = 0;
            int empretval = 0;
            int statuscnt = 0;
            EducationHealthEmpVM objEduList = new EducationHealthEmpVM();
            try
            {
                int health = 0;
                int employement = 0;
                int education = 0;
                int registerhouseholdcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("1", Convert.ToInt32(createrequest.education[0].hhid), 0);
                if (registerhouseholdcnt == 0)
                {
                    objEduList.status = "404";
                    objEduList.message = "Household Not Registerd";
                    objEduList.errorMessage = "";
                }
                else
                {
                    if (createrequest.education != null)
                    {
                        if (createrequest.education.Count > 0)
                        {
                            foreach (var request in createrequest.education)
                            {
                                if (Convert.ToInt32(request.memberId) > 0)
                                {
                                    var entity = new EducationInfoDto();
                                    entity.action = request.action;
                                    entity.educationinfoid = (request.eduInfoId != null && request.eduInfoId != "") ? Convert.ToInt32(request.eduInfoId) : 0;
                                    entity.hhid = Convert.ToInt32(request.hhid);
                                    entity.memberid = Convert.ToInt32(request.memberId);
                                    entity.isCurrentlyAttendingSchool = Convert.ToInt32(request.isCurentAttendSclId);
                                    entity.whystoppedgoingschool = Convert.ToInt32(request.stopedGoingSchoolId);
                                    entity.otherreasonfornotgoingschool = request.otherreasonfornotgoingschool;
                                    entity.canreadwriteanylanguage = Convert.ToInt32(request.canReadWriteId);
                                    entity.haseverattendedschool = Convert.ToInt32(request.everAttndSchoolId);
                                    entity.whyneverattendedschool = Convert.ToInt32(request.neverAttendSchoolId);
                                    entity.otherreasonnotattendedschool = request.otherreasonnotattendedschool;
                                    entity.lastlevelcompleted = Convert.ToInt32(request.lastLevelGradeCmpltId);

                                    entity.typeofschoolattended = Convert.ToInt32(request.typeOfSchoolAttendId);
                                    entity.levelattended = request.levelGradeAttenedId != "" ? Convert.ToInt32(request.levelGradeAttenedId) : 0;
                                    entity.age = 0;
                                    entity.lastgradecompleted = 0;
                                    entity.gradeattended = 0;
                                    entity.createdby = request.createdby.ToString();
                                    entity.apptypeid = Convert.ToInt32(request.apptypeid);
                                    eduretval = await _iHouseholdService.AddEducationInfo(entity);
                                    if (eduretval == 200 || eduretval == 201)
                                    {
                                        education = education + 1;
                                    }
                                }
                            }
                        }
                    }
                    if (createrequest.health != null)
                    {
                        if (createrequest.health.Count > 0)
                        {
                            foreach (var request in createrequest.health)
                            {
                                if (Convert.ToInt32(request.memberId) > 0)
                                {
                                    var entity = new HealthInfoDto();
                                    entity.action = request.action;
                                    entity.hhid = Convert.ToInt32(request.hhid);
                                    entity.memberid = Convert.ToInt32(request.memberId);
                                    entity.healthinfoid = (request.healthInfoId != null && request.healthInfoId != "") ? Convert.ToInt32(request.healthInfoId) : 0;
                                    entity.doessufferanychronicillness = Convert.ToInt32(request.chronicIllnessId);//ex-Yes ,No
                                    entity.dohavediffwearingglass = Convert.ToInt32(request.difficultySeeingId);
                                    entity.dohavediffhearing = Convert.ToInt32(request.difficultyHearingId);
                                    entity.dohavediffwalking = Convert.ToInt32(request.difficultyWalkingId);
                                    entity.dohavediffremembering = Convert.ToInt32(request.difficultyRememberingId);
                                    entity.dohavediffselfcare = Convert.ToInt32(request.difficultySelfCaringId);
                                    entity.dohavediffcommunicate = Convert.ToInt32(request.difficultyCommunicatingId);
                                    entity.whatchronicillnesssuffer = request.typeOfChronicIllnessId;//ex-1,2,3
                                    entity.otherillness = "";
                                    entity.createdby = request.createdby.ToString();
                                    entity.apptypeid = Convert.ToInt32(request.apptypeid);
                                    healthretval = await _iHouseholdService.AddHealthInfo(entity);
                                    if (healthretval == 200 || healthretval == 201)
                                    {
                                        health = health + 1;
                                    }
                                }

                            }
                        }
                    }
                    if (createrequest.employment != null)
                    {
                        if (createrequest.employment.Count > 0)
                        {
                            foreach (var request in createrequest.employment)
                            {
                                if (Convert.ToInt32(request.memberId) > 0)
                                {
                                    var entity = new EmploymentInfoDto();
                                    entity.action = request.action;
                                    entity.hhid = Convert.ToInt32(request.hhid);
                                    entity.employmentinfoid = (request.empInfoId != null && request.empInfoId != "") ? Convert.ToInt32(request.empInfoId) : 0;
                                    entity.memberid = Convert.ToInt32(request.memberId);
                                    entity.mainjobactivitylastthirtydays = Convert.ToInt32(request.mainJobId);
                                    entity.howfreequentlyworking = Convert.ToInt32(request.frequentlyId);
                                    entity.workinginwhichsector = Convert.ToInt32(request.workingSectorId);
                                    entity.othersector = request.othersector;
                                    entity.workingstatus = Convert.ToInt32(request.workingStatusId);
                                    entity.reasonfornotworking = Convert.ToInt32(request.notWorkingReasonId);
                                    entity.othereasonfornotworking = request.notWorkingReason;
                                    entity.createdby = Convert.ToInt32(request.createdby);
                                    entity.apptypeid = Convert.ToInt32(request.apptypeid);

                                    empretval = await _iHouseholdService.AddEmploymentInfo(entity);
                                    if (empretval == 200 || empretval == 201)
                                    {
                                        employement = employement + 1;
                                    }
                                }
                            }
                        }
                    }

                    //if (createrequest.education.Count>0 && createrequest.health.Count>0 && createrequest.employment.Count>0)
                    if (createrequest.education != null || createrequest.health != null || createrequest.employment != null)
                    {
                         statuscnt = await _iHouseholdServiceMobile.CheckStatusOfHousehold("A", Convert.ToInt32(createrequest.education[0].hhid), Convert.ToInt32(createrequest.education[0].createdby));                      
                         objEduList.status = MobileApiStatusCode.OK;
                         objEduList.message = "Success";
                         objEduList.errorMessage = "";
                    }
                    else
                    {
                        objEduList.status = MobileApiStatusCode.Badrequest;
                        objEduList.message = "Bad request";
                        objEduList.errorMessage = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objEduList.status = "500";
                objEduList.message = ex.Message;
                objEduList.errorMessage = ex.Message;
            }
            return objEduList;

        }
    }
}
