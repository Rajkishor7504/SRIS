using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery
{
    public class AgricultureinfoVM : CommonMobileApiStatus
    {
        public IList<AgricultureinfoDto> Lists { get; set; }
    }
}
