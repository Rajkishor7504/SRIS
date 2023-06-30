
using SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.HouseHoldAssetAPI.Queries.GethhAssetMaster
{
   public class AssetMasterDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class AssetMasterVM
    {
        public List<AssetMasterDto> houseHoldAsset { get; set; }
      

    }
    public class AssetMasterResponse : CommonMobileApiStatus
    {
        public AssetMasterVM householdAsset { get; set; }
    }
    public class AssetWebResponse
    {
        public AssetMasterVM Asset { get; set; }
       public List<AssetInfoDetail> InfoLists { get; set; }
        public int hhid { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
        public string encrypthhid { get; set; }
        public int lockstatus { get; set; }


    }
}
