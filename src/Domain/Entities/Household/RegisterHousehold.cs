using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace SRIS.Domain.Entities
{
    public class RegisterHousehold 
    {
        public string District { get; set; }
        public string LGA { get; set; }
        public string Ward { get; set; }
        public string Settlement { get; set; }

    }
    public class RegisterHouseholdList: CommonMobileApiStatus
    {
        [DataMember]
        public List<RegisterHousehold> RegisterHouseholdData { get; set; }

    }
}
