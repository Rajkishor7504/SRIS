using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public  class EmploymentInfo
    {

    }
    public class EmploymentInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<EmploymentInfo> EmploymentInfoData { get; set; }

    }
}
