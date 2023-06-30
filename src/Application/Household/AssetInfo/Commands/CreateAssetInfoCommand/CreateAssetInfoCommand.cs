using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery;
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
    public  class CreateAssetInfoCommand: IRequest<AssetInfoList>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        
        public int assetid { get; set; }
        public int apptypeid { get; set; }
        public List<AssetInfoDetail> assetdetail { get; set; }
    }
    public class CreateAssetInfoCommandHandler : IRequestHandler<CreateAssetInfoCommand, AssetInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateAssetInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<AssetInfoList> Handle(CreateAssetInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            AssetInfoList objAssetList = new AssetInfoList();
            int validationcount = 0;
            try
            {
                foreach (AssetInfoDetail aid in request.assetdetail)
                {
                    if (aid.mediumid == 0 || aid.totalno == 0 || aid.item1age==0 || aid.item2age==0)
                    {
                        validationcount += 1;
                    }
                }
                if ((request.hhid == 0) || (validationcount < 0))
                {
                    objAssetList.status = "400";
                    objAssetList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new AssetInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.assetdetail = request.assetdetail;
                    entity.assetid = request.assetid;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddAssetInfo(entity);
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
