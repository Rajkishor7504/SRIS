using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SRIS.Application.Household.DistanceInfo.Commands
{
   public class UpdateStatusDistanceCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }      
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }

    }
    public class UpdateStatusDistanceCommandHandler : IRequestHandler<UpdateStatusDistanceCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusDistanceCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusDistanceCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objEmpList = new CommonMobileApiStatus();          
            try
            {
                var entity = new DistanceStatusInfoDto();
                entity.action = request.action;
                entity.hhid = request.hhid; 
                entity.createdby = request.createdby;
                entity.apptypeid = request.apptypeid;
                entity.id = request.id;
                entity.remark = request.remark;
                entity.parameterid = request.parameterid;
                retval = await _iHouseholdService.UpdateDistanceStatusInfo(entity);
                objEmpList.status = retval.ToString();
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
               
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
