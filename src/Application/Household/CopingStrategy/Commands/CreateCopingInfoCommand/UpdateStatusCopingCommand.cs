using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SRIS.Application.Household.CopingStrategy.Commands
{
   public class UpdateStatusCopingCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int copingid { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
    public class UpdateStatusCopingCommandHandler : IRequestHandler<UpdateStatusCopingCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusCopingCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusCopingCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CopingStrategyList objEmpList = new CopingStrategyList();
           
            try
            {
                if (request.hhid == 0 && request.action == "U") 
                {
                    objEmpList.status = "400";
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new CopingStatusInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;                  
                    entity.createdby = request.createdby;
                    entity.copingid = request.copingid;
                    entity.apptypeid = request.apptypeid;
                    entity.id = request.id;                
                    entity.parameterid = request.parameterid;
                    entity.remark = request.remark;
                    retval = await _iHouseholdService.UpdateCopingStatusInfo(entity);
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
