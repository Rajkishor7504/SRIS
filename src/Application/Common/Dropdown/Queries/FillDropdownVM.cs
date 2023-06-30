using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Common.Dropdown.Queries
{
    public class FillDropdownVM : CommonMobileApiStatus
    {
        public IList<FillDropdownDto> Lists { get; set; }
    }
}
