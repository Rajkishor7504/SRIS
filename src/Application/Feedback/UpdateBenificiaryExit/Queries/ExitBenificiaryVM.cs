using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Feedback.UpdateBenificiaryExit.Queries
{
    public class ExitBenificiaryVM: CommonMobileApiStatus
    {
        public string programmecode { get; set; }
        public string benificiarynumber { get; set; }
        public string exittype { get; set; }
        public string exiteddate { get; set; }

    }
}
