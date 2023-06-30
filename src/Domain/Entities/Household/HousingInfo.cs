using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class HousingInfo
    {

    }
    public class HousingInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<HousingInfo> HousingInfoData { get; set; }
    }
}
