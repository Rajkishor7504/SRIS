using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class DemographicMember
    {
        
    }
    public class DemographicMemberList : CommonMobileApiStatus
    {
        [DataMember]
        public List<DemographicMember> DemographicMemberData { get; set; }

    }
}
