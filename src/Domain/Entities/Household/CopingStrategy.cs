using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class CopingStrategy
    {
    }
    public class CopingStrategyList : CommonMobileApiStatus
    {
        [DataMember]
        public List<CopingStrategy> CopingInfoData { get; set; }
    }
}
