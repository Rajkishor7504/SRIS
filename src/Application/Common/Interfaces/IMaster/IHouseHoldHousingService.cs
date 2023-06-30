using SRIS.Application.AllMaster.HouseHoldHousingAPI.Queries.GetHouseHoldHousing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface IHouseHoldHousingService
    {
      Task<List<CommonHouseHoldHousingDto>> GetoccupancyStatusData();//not getting tablename
        Task<List<CommonHouseHoldHousingDto>> GetwallMaterialData();
        Task<List<CommonHouseHoldHousingSubDto>> GetwallSubMaterialData();
        Task<List<CommonHouseHoldHousingDto>> GetroofMaterialData();
        Task<List<CommonHouseHoldHousingSubDto>> GetroofSubMaterialData();
        Task<List<CommonHouseHoldHousingDto>> GetfloorMaterialData();
        Task<List<CommonHouseHoldHousingSubDto>> GetfloorSubMaterialData();
        Task<List<CommonHouseHoldHousingDto>> GetmainLightingSourceData();
        Task<List<CommonHouseHoldHousingDto>> GetcoockingFuelData();
        Task<List<CommonHouseHoldHousingDto>> GettoiletTypeData();
        Task<List<CommonHouseHoldHousingDto>> GetmainDrinkingSourceData();
        Task<List<CommonHouseHoldHousingDto>> GetdisposeofRubishData();
        Task<List<CommonHouseHoldHousingDto>> GetConstructionMaterialData();
        Task<List<CommonHouseHoldHousingSubDto>> GetConstructionSubMaterialData();
    }
   
}
