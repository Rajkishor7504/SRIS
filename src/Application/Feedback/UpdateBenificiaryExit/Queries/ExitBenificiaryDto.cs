using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Feedback.UpdateBenificiaryExit.Queries
{
    public class ExitBenificiaryDto
    {
        public string programmecode { get; set; }
        public string benificiarynumber { get; set; }
        public string exittype { get; set; }
        public DateTime exiteddate { get; set; }

    }
}
