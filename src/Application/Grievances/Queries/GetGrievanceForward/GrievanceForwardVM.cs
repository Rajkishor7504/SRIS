using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Grievances.Queries.GetGrievanceForward
{
    public class GrievanceForwardVM
    {
        public int forwardedId { get; set; }
        public int grievanceId { get; set; }
        public int forwardedBy_userId { get; set; }
        public int forwardedBy_committeeId { get; set; }
        public int forwardedTo_committeeId { get; set; }
        public int status { get; set; }
        public string remarks { get; set; }
        public int admissibility { get; set; }
        public string relationshiptotheproject { get; set; }
        public int grievanceconfigid { get; set; }
        public string association { get; set; }
        public int refNo { get; set; }
        public int roleid { get; set; }
    }
}
