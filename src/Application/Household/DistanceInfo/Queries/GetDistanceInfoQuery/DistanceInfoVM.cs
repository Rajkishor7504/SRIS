using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery
{
    public class DistanceInfoVM: CommonMobileApiStatus
    {
        public IList<HouseholdDistance> Lists { get; set; }
    }
}
