using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold
{
   public class RegisterHouseholdVM: CommonMobileApiStatus
    {
        public IList<RegisterHouseholdDto> Lists { get; set; }

    }
}
