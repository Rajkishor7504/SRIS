using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class DistanceInfo
    {

    }
    public class DistanceInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<DistanceInfo> DistanceInfoData { get; set; }
    }
   
}
