using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.HealthInfo.Commands
{
   public class UpdateStatusHealthCommand : IRequest<CommonMobileApiStatus>
    {
        public int healthinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }

    public class UpdateStatusHealthCommandHandler : IRequestHandler<UpdateStatusHealthCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusHealthCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusHealthCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objHealthList = new CommonMobileApiStatus();
            try
            {
                
                var entity = new HealthStatusInfoDto();
                entity.action = request.action;
                entity.hhid = request.hhid;
                entity.memberid = request.memberid;
                entity.healthinfoid = request.healthinfoid;
                entity.id = request.id;              
                entity.parameterid = request.parameterid;
                entity.remark = request.remark;
                entity.createdby = request.createdby;
                entity.apptypeid = request.apptypeid;
                retval = await _iHouseholdService.UpdateHealthStatusInfo(entity);
                objHealthList.status = retval.ToString();
                objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                
            }
            catch (Exception ex)
            {
                objHealthList.status = "500";
                objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objHealthList.errorMessage = ex.Message;
            }
            return objHealthList;

        }
    }
}
