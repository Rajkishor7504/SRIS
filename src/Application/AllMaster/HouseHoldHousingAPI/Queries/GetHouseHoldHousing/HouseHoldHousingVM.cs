using SRIS.Application.Household.HousingInfo.Commands;
using SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.HouseHoldHousingAPI.Queries.GetHouseHoldHousing
{
   public class HouseHoldHousingVM
    {
        public List<CommonHouseHoldHousingDto> occupancyStatus { get; set; }
        public List<CommonHouseHoldHousingDto> wallMaterial { get; set; }
        public List<CommonHouseHoldHousingSubDto> wallSubMaterial { get; set; }
        public List<CommonHouseHoldHousingDto> roofMaterial { get; set; }
        public List<CommonHouseHoldHousingSubDto> roofSubMaterial { get; set; }
        public List<CommonHouseHoldHousingDto> floorMaterial { get; set; }
        public List<CommonHouseHoldHousingSubDto> floorSubMaterial { get; set; }
        public List<CommonHouseHoldHousingDto> mainLightingSource { get; set; }
        public List<CommonHouseHoldHousingDto> coockingFuel { get; set; }
        public List<CommonHouseHoldHousingDto> toiletType { get; set; }
        public List<CommonHouseHoldHousingDto> mainDrinkingSource { get; set; }
        public List<CommonHouseHoldHousingDto> disposeofRubish { get; set; }
        public List<CommonHouseHoldHousingDto> constructionMaterial { get; set; }
        public List<CommonHouseHoldHousingSubDto> constructionSubMaterial { get; set; }

    }
    public class HouseHoldHousingResponse : CommonMobileApiStatus
    {
        public HouseHoldHousingVM houseHoldHousing { get; set; }
    }
    public class HouseHoldHousingWebResponse 
    {
        public HouseHoldHousingResponse HHMaster { get; set; }
        public HousingInfoDto Housing { get; set; }
        public int hhid { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
        public string encrypthhid { get; set; }
        public int lockstatus { get; set; }
        public int updatestatus { get; set; }
    }
}
