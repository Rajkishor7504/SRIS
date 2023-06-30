using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest
{    
    public class ExternalDataRequestResponse : CommonMobileApiStatus
    {
        public IList<ExternalData> ExternalDataList { get; set; }
    }
}
