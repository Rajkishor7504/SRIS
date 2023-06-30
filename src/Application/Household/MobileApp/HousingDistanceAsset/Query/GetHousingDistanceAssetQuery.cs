using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.HousingDistanceAsset.Query
{
   public class GetHousingDistanceAssetQuery : IRequest<HousingDistanceAssetQueryVM>
    {
        public string hhid { get; set; }
    }
    public class GetHousingDistanceAssetQueryHandler : IRequestHandler<GetHousingDistanceAssetQuery, HousingDistanceAssetQueryVM>
    {


        private readonly IHouseholdServiceMobile _iHouseholdService;

        public GetHousingDistanceAssetQueryHandler(IHouseholdServiceMobile iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HousingDistanceAssetQueryVM> Handle(GetHousingDistanceAssetQuery request, CancellationToken cancellationToken)
        {
            HousingDistanceAssetQueryVM objVM = new HousingDistanceAssetQueryVM();
            try
            {
               
                
                objVM.housing = await _iHouseholdService.GetHousingList(request);//housing details

                var distanceData = await _iHouseholdService.GetDistanceList(request);
                RespnseDistanceModelVM dista = new RespnseDistanceModelVM();
                dista.hhdistance= await _iHouseholdService.GetDistanceList(request); 
                if(dista.hhdistance.Count>0)
                {
                    objVM.distance = dista;//Distance details
                }
                else
                {
                    objVM.distance = null;//Distance details
                }
                

                ResponseAssetModelVM ass = new ResponseAssetModelVM();
                ass.assetdetail = await _iHouseholdService.GetAssetList(request);                
                if (ass.assetdetail.Count > 0)
                {
                    objVM.householdAsset = ass;//Asset details
                }
                else
                {
                    objVM.householdAsset = null;//Asset details
                }

                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                objVM.errorMessage = "";
            }

            catch (Exception ex)
            {
                objVM.housing = null;
                objVM.distance.hhdistance = null;
                objVM.householdAsset.assetdetail = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;

        }
    }
}
