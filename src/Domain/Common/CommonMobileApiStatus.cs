using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Domain.Common
{
   public class CommonMobileApiStatus
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string errorMessage { get; set; }

    }
}
