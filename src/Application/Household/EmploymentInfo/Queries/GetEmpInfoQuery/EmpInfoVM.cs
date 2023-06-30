using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery
{
   public class EmploymentInfoVM: CommonMobileApiStatus
    {
        public IList<EmploymentInfoDto> Lists { get; set; }
    }
}
