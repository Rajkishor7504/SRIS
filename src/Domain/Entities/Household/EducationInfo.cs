using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class EducationInfo
    {

    }
    public class EducationInfoList : CommonMobileApiStatus
    {
        [DataMember]
        public List<EducationInfo> EducationInfoData { get; set; }

    }
}
