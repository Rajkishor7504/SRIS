using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery
{
   public class HousingInfoVM : CommonMobileApiStatus
    {
        public IList<HousingInfoDto> Lists { get; set; }
    }
}
