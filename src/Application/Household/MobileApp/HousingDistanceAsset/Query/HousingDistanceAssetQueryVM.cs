using SRIS.Application.Household.MobileApp.QARejectedhhList;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.HousingDistanceAsset.Query
{
   public class HousingDistanceAssetQueryVM : CommonMobileApiStatus
    {
        public HousingModelVM housing { get; set; }
        public RespnseDistanceModelVM distance { get; set; }
        public ResponseAssetModelVM householdAsset { get; set; }

    }
    
    public class HousingModelVM
    {
        public string housingInfoId { get; set; } //for update purpose       
        public string occupancyStatus { get; set; }
        public string occupancyStatusId { get; set; }

     
        public string wallMaterialId { get; set; }
        public string wallMaterial { get; set; }

        public string roofingMaterial { get; set; }
        public string roofingMaterialId { get; set; }
        public string roofingMaterialOther { get; set; }

        public string typeOfToiletId { get; set; }
        public string typeOfToilet { get; set; }
        public string typeOfToiletOther { get; set; }

        public string isSharedToilet { get; set; }

        public string lightingSource { get; set; }
        public string lightingSourceId { get; set; }
        public string lightingSourceOther { get; set; }

        public string drinkingWaterSourceId { get; set; }
        public string drinkingWaterSource { get; set; }
        public string drinkingWaterSourceOther { get; set; }
        public string totalUseToilet { get; set; }
      


     

        public string disposeRubbishId { get; set; }
        public string disposeRubbish { get; set; }
        public string disposeRubbishOther { get; set; }
     

        public string flooringMaterialId { get; set; }
        public string flooringMaterial { get; set; }
        public string flooringMaterialOther { get; set; }
      
       


        public string cookingFuelId { get; set; }
        public string cookingFuel { get; set; }      
        public string cookingFuelOther { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }


    }

    public class DistanceModelVM 
    {
       // public string distanceInfoId { get; set; }//for update purpose
        public string transportationmodeid { get; set; }
        public string transportationmodeNm { get; set; }
        public string timeinmin { get; set; }
        public string serviceid { get; set; }

        public string serviceName { get; set; }
        public string distanceinkm { get; set; }
        public string distanceid { get; set; }//for update purpose
        public string othertransportation { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }
    }
    public class RespnseDistanceModelVM
    {
        public IList<DistanceModelVM> hhdistance { get; set; }
    }

        public class AssetModelVM
    {
       // public string assetInfoId { get; set; }//for update purpose
        public string isavailable { get; set; }
   
        public string mediumName { get; set; }
        public string mediumid { get; set; }

        public string totalno { get; set; }
       public string assetdetailid { get; set; }
        public string item1age { get; set; }
        public string item2age { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }
    }
    public class ResponseAssetModelVM
    {     
    public IList<AssetModelVM> assetdetail { get; set; }
    }
  }
