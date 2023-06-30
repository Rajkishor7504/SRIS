using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery;
using SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SRIS.Application.Household.AssetInfo.Commands
{
   public class UpdateStatusAssetCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }

        public int assetid { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
    public class UpdateStatusAssetCommandHandler : IRequestHandler<UpdateStatusAssetCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusAssetCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusAssetCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objAssetList = new CommonMobileApiStatus();
            int validationcount = 0;
            try
            {
               
                if ((request.hhid == 0))
                {
                    objAssetList.status = "400";
                    objAssetList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new AssetStatusInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;                    
                    entity.assetid = request.assetid;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    entity.id = request.id;                  
                    entity.parameterid = request.parameterid;
                    entity.remark = request.remark;
                    retval = await _iHouseholdService.UpdateAssetStatusInfo(entity);
                    objAssetList.status = retval.ToString();
                    objAssetList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objAssetList.status = "500";
                objAssetList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objAssetList.errorMessage = ex.Message;
            }
            return objAssetList;

        }
    }
}
