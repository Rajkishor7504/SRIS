using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo
{
   public class EducationInfoVM: CommonMobileApiStatus
    {
        public IList<EducationInfoDto> Lists { get; set; }
    }
}
