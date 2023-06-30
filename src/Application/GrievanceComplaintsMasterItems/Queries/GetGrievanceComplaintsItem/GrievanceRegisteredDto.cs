using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GrievanceRegisteredDto
    {
        public int registrationid { get; set; }
        public string name { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string community { get; set; }
        public string contactno { get; set; }
        public DateTime dateofreceiptofthegrievance { get; set; }
        public string timeofreceiptofthegrievance { get; set; }
        public int admissibility { get; set; }
        public string relationshiptotheproject { get; set; }
        public int grievanceconfigid { get; set; }
        public ResolutionStatus status { get; set; }
        public DateTime actiondate { get; set; }
        public string ticketid { get; set; }
        public string grievancename { get; set; }
        public string grievancedescription { get; set; }
        public string association { get; set; }
        public string document { get; set; }
        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public string action { get; set; }
        public int p_id { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public string grievancestatus { get { return status.ToString(); } }
        public bool isForwarded { get; set; }
        public bool isNSPS { get; set; }
        public bool canEdit { get; set; }
        public string forwardedtocommittee { get; set; }
        public string forwardedbycommittee { get; set; }
        public string forwardedby { get; set; }
        public string forwardedtocommitteename { get; set; }
        public bool isportal { get; set; }
        public bool canForward { get; set; }
        public int pkid { get; set; }
    }
}
