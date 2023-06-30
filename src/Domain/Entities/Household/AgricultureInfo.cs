using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class AgricultureInfo
    {

    }
    public class AgricultureInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<AgricultureInfo> AgricultureInfoData { get; set; }
    }
}
