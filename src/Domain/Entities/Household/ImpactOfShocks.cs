using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class ImpactOfShocks
    {
    }
    public class ImpactOfShocksList : CommonMobileApiStatus
    {
        [DataMember]
        public List<ImpactOfShocks> ImpactOfShocksData { get; set; }
    }
}
