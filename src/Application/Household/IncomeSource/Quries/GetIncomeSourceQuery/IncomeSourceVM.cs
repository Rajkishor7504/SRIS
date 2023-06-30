using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery
{
  public class IncomeSourceVM: CommonMobileApiStatus
    {
        public IList<IncomeSourceDto> Lists { get; set; }
    }
    
}
