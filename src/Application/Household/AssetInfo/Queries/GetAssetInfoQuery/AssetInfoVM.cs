using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery
{
   public class AssetInfoVM: CommonMobileApiStatus
    {
        public IList<AssetInfoDetail> Lists { get; set; }
    }
}
