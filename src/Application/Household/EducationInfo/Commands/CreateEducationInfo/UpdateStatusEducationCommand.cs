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

namespace SRIS.Application.Household.EducationInfo.Commands.UpdateStatusEducationCommand
{
  public  class UpdateStatusEducationCommand : IRequest<CommonMobileApiStatus>
    {
        public int educationinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
    public class UpdateStatusEducationCommandHandler : IRequestHandler<UpdateStatusEducationCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusEducationCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusEducationCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objEduList = new CommonMobileApiStatus();
            try
            {
               
                var entity = new EducationInfoStatusDto();
                entity.action = request.action;
                entity.hhid = request.hhid;
                entity.memberid = request.memberid;
                entity.educationinfoid = request.educationinfoid;
                entity.id = request.id;
                entity.educationinfoid = request.educationinfoid;
                entity.parameterid = request.parameterid;
                entity.remark = request.remark;
                entity.createdby = request.createdby;
                entity.apptypeid = request.apptypeid;
                retval = await _iHouseholdService.UpdateEducationStatusInfo(entity);
                objEduList.status = retval.ToString();
                objEduList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
              
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
