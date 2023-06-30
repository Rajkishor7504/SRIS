using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SRIS.Application.Household.EmploymentInfo.Commands
{
    public class UpdateStatusEmpCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int employmentinfoid { get; set; }      
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
    public class UpdateStatusEmpCommandHandler : IRequestHandler<UpdateStatusEmpCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusEmpCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusEmpCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objEmpList = new CommonMobileApiStatus();
            try
            {
                if (request.employmentinfoid == 0 && request.action == "U")
                {
                    objEmpList.status = "400";
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new EmploymentStatusInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.memberid = request.memberid;
                    entity.employmentinfoid = request.employmentinfoid;                  
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    entity.id = request.id;
                    entity.remark = request.remark;
                    entity.parameterid = request.parameterid;
                    retval = await _iHouseholdService.UpdateEmploymentStatusInfo(entity);
                    objEmpList.status = retval.ToString();
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objEmpList.status = "500";
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objEmpList.errorMessage = ex.Message;
            }
            return objEmpList;

        }
    }
}
