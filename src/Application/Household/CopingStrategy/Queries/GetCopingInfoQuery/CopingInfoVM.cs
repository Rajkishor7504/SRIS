using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery
{
    public class CopingInfoVM:CommonMobileApiStatus
    {
        public IList<LivelihoodCoping> livelyhoodLists { get; set; }
        public IList<FoodCoping> foodLists { get; set; }
    }
}
