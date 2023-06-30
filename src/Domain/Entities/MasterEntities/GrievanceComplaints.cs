using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class GrievanceComplaints : BaseEntity
    {[Key]
        public int registrationid { get; set; }
        public string name { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string community { get; set; }
        public string contactno { get; set; }
        public string Email { get; set; }
        public DateTime dateofreceiptofthegrievance { get; set; }
        public string timeofreceiptofthegrievance { get; set; }
        public int admissibility { get; set; }
        public string relationshiptotheproject { get; set; }
        public int grievanceconfigid { get; set; }
        public ResolutionStatus status { get; set; }
        public string ticketid { get; set; }
        public string grievancedescription { get; set; }
        public string association { get; set; }
        public string document { get; set; }
        public DateTime? actiondate { get; set; }
        public DateTime? reopendate { get; set; }
        public string reopendesc { get; set; }
        public bool isportal { get; set; }


    }
    public enum ResolutionStatus
    {
        Pending = 0,
        Onhold = 1,
        Rejected = 2,
        Forwarded = 3,
        Resolved = 4,
        Inprogress = 5
    }

    public enum ForwardStatus
    {
        Pending = 0,
        Forwarded = 1,
        Resolved = 2,
        Rejected = 3
    }

}
