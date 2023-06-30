using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class HealthInfo
    {

    }
    public class HealthInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<HealthInfo> HealthInfoData { get; set; }

    }
}
