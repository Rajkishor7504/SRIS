using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo
{
    public class HealthInfoVM: CommonMobileApiStatus
    {
        public IList<HealthInfoDto> Lists { get; set; }
        public IList<Disease> DiseaseList { get; set; }
    }
}
