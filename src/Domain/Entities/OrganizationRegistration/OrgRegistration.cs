using SRIS.Domain.Common;
using System.Collections.Generic;

namespace SRIS.Domain.Entities
{
    public class OrgRegistration : AuditableEntity
    {
        public int organisationid { get; set; }
        public string organisationname { get; set; }
        public int organisationcategoryid { get; set; }
        public string contactname { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
        public string State { get; set; }
        public int createdby { get; set; }
        public bool deletedflag { get; set; }
        public RegistrationStatus status { get; set; }
        public string Email { get; set; }
    }
    public enum RegistrationStatus
    {
        Pending = 0, Approved, Rejected
    }
    
}
