using SRIS.Application.AllMaster.HouseHoldAssetAPI.Queries.GethhAssetMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
   public interface IHouseHoldAssetService
    {
        Task<List<AssetMasterDto>> GethhAssetData();
    }
}
