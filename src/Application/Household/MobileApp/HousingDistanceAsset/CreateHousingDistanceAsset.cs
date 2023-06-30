using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery;
using SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery;
using SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.HousingDistanceAsset
{
   public class CreateHousingDistanceAsset:IRequest<HousingDistanceAssetVM>
    {
       // public string memberId { get; set; }
        public string hhid { get; set; }
        public string action { get; set; }
        public string createdby { get; set; }
        public string apptypeid { get; set; }
        public HHHousingDto housing { get; set; }
        public List<HHDistanceDto> distance { get; set; }
        public List<HHAssetDto> householdAsset { get; set; }

    }
    public class CreateHousingDistanceAssetHandler : IRequestHandler<CreateHousingDistanceAsset, HousingDistanceAssetVM>
    {


        private readonly IHouseholdService _iHouseholdService;
        private readonly IHouseholdServiceMobile _iHouseholdServiceMobile;

        public CreateHousingDistanceAssetHandler(IHouseholdService iHouseholdService, IHouseholdServiceMobile iHouseholdServiceMobile)
        {
            _iHouseholdService = iHouseholdService;
            _iHouseholdServiceMobile = iHouseholdServiceMobile;
        }

        public async Task<HousingDistanceAssetVM> Handle(CreateHousingDistanceAsset request, CancellationToken cancellationToken)
        {

            int housingretval = 0;
            int distanceretval = 0;
            int assetretval = 0;
            HousingDistanceAssetVM objEduList = new HousingDistanceAssetVM();
            try
            {               
                int registerhouseholdcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("1", Convert.ToInt32(request.hhid),0);
                if (registerhouseholdcnt == 0)
                {
                    objEduList.status = "404";
                    objEduList.message = "Household Not Registerd";
                    objEduList.errorMessage ="";
                }
                else
                {

                    #region---------------housing--------------------
                   
                        if (request.housing != null)
                         {
                        //int housingcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("6", Convert.ToInt32(request.hhid), 0);// 6 for housing
                        //if (housingcnt == 0)
                        //{
                            var entity = new HousingInfoDto();
                            entity.action = request.action;
                            entity.hhid = Convert.ToInt32(request.hhid);
                            entity.housinginfoid = 0;
                            entity.occupancystatusofdwelling = Convert.ToInt32(request.housing.occupancyStatusId);
                            entity.mainconstructionmaterial = Convert.ToInt32(request.housing.wallMaterialId);
                            entity.otherconstructionmaterial = request.housing.otherWallMaterial;
                            entity.mainmaterialusedforroofing = Convert.ToInt32(request.housing.roofingMaterialId);
                            entity.othermaterialroofing = request.housing.roofingMaterialOther;
                            entity.mainmaterialusedforflooring = Convert.ToInt32(request.housing.flooringMaterialId);
                            entity.othermaterialflooring = request.housing.flooringMaterialOther;
                            entity.mainsourceoflighting = Convert.ToInt32(request.housing.lightingSourceId);
                            entity.othersourceoflighting = request.housing.lightingSourceOther;
                            entity.maincookingfuel = Convert.ToInt32(request.housing.cookingFuelId);
                            entity.othermaincookingfuel = request.housing.cookingFuelOther;
                            entity.typeoftoiletfacility = Convert.ToInt32(request.housing.typeOfToiletId);
                            entity.othertoiletfacility = request.housing.typeOfToiletOther;
                            entity.toiletsharedwithotherhh = Convert.ToInt32(request.housing.isSharedToilet);
                            entity.howmanyhhusetoiletfacility = Convert.ToInt32(request.housing.totalUseToilet);
                            entity.mainsourceofdrinkingwater = Convert.ToInt32(request.housing.drinkingWaterSourceId);
                            entity.othersourceofdrinkingwater = request.housing.drinkingWaterSourceOther;
                            entity.howhhdisposerubbish = Convert.ToInt32(request.housing.disposeRubbishId);
                            entity.otherwayforrubbish = request.housing.disposeRubbishOther;
                            entity.createdby = Convert.ToInt32(request.createdby);
                            entity.apptypeid = Convert.ToInt32(request.apptypeid);
                            housingretval = await _iHouseholdService.AddHousingInfo(entity);
                        //}
                        //else
                        //{
                        //    housingretval = 200;
                        //}
                        
                    }
                    #endregion
                    #region---------------distance--------------------
                    if (request.distance != null)
                    {
                        //int housingcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("7", Convert.ToInt32(request.hhid), 0);//7 for distance
                        //if (housingcnt == 0)
                        //{
                            List<HouseholdDistance> hhDistance = new List<HouseholdDistance>();
                            if (request.distance.Count > 0)
                            {
                                foreach (var item in request.distance)
                                {
                                    hhDistance.Add(new HouseholdDistance
                                    {
                                        //distanceinkm = Convert.ToInt32(item.distanceinkm),
                                        distanceinkm = Convert.ToDecimal(item.distanceinkm),
                                        othertransportation = item.othertransportation,
                                        timeinmin = item.timeinmin!=""?Convert.ToInt32(item.timeinmin):0,
                                        //timeinmin = item.timeinmin != "" ? Convert.ToDecimal(item.timeinmin) : 0,
                                        serviceid = item.serviceid != "" ? Convert.ToInt32(item.serviceid):0,
                                        transportationmodeid = Convert.ToInt32(item.transportationmodeid)
                                    });
                                }
                                var entity1 = new DistanceInfoDto();
                                entity1.action = request.action;
                                entity1.hhid = Convert.ToInt32(request.hhid);
                                entity1.hhDistance = hhDistance;

                                entity1.createdby = Convert.ToInt32(request.createdby);
                                entity1.apptypeid = Convert.ToInt32(request.apptypeid);
                                distanceretval = await _iHouseholdService.AddDistanceInfo(entity1);
                            }
                        //}
                        //else
                        //{
                        //    distanceretval = 200;
                        //}

                    }
                    #endregion
                    #region---------------asset--------------------
                    List<AssetInfoDetail> assetdetail = new List<AssetInfoDetail>();
                    if (request.householdAsset != null)
                    {
                        if (request.householdAsset.Count > 0)
                        {
                            //int assetcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("8", Convert.ToInt32(request.hhid), 0);//8 for asset
                            //if (assetcnt == 0)
                            //{
                            foreach (var item in request.householdAsset)
                            {
                                assetdetail.Add(new AssetInfoDetail
                                {
                                    isavailable = Convert.ToInt32(item.isavailable),
                                    item1age = item.item1age != "" ? Convert.ToInt32(item.item1age) : 0,
                                    item2age = item.item2age != "" ? Convert.ToInt32(item.item2age) : 0,
                                    mediumid = item.mediumid != "" ? Convert.ToInt32(item.mediumid) : 0,
                                    totalno = item.totalno != "" ? Convert.ToInt32(item.totalno) : 0
                                });
                            }
                            var entity2 = new AssetInfoDto();
                            entity2.action = request.action;
                            entity2.hhid = Convert.ToInt32(request.hhid);
                            entity2.assetdetail = assetdetail;

                            entity2.createdby = Convert.ToInt32(request.createdby);
                            entity2.apptypeid = Convert.ToInt32(request.apptypeid);
                            assetretval = await _iHouseholdService.AddAssetInfo(entity2);
                            //}
                            //else
                            //{
                            //    assetretval = 200;
                            //}
                        }
                    }
                    //if (housingretval == 200 && distanceretval == 200 && assetretval == 200 )
                    if(request.housing != null || request.distance != null || request.householdAsset != null)
                    {
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
                    #endregion
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
