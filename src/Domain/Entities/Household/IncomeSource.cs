using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class IncomeSource
    {
    }
    public class IncomeSourceList : CommonMobileApiStatus
    {
        [DataMember]
        public List<IncomeSource> IncomeSourceData { get; set; }

    }
}
