using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery
{
    public class ImpactVM: CommonMobileApiStatus
    {
        public IList<ImpactDto> Lists { get; set; }
    }
}
