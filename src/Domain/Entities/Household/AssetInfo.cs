using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class AssetInfo
    {

    }
    public class AssetInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<AssetInfo> AssetInfoData { get; set; }
    }
}
