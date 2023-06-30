using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DataSharing.Queries
{
    public class DataSharingDto
    {
        public string programcode { get; set; }
        public string lga { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string town { get; set; }
        public bool restdatarequired { get; set; }
    }
}
