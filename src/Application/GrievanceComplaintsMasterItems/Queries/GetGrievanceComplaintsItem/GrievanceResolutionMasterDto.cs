using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GrievanceResolutionMasterDto : IMapFrom<GrievanceComplaints>
    {
        [Key]

        public int registrationid { get; set; }
        public string name { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public string compldate { get; set; }
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
        public DateTime? actiondate { get; set; }
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
        public string p_id { get; set; }

        //public int p_id { get; set; }
        public int levelid { get; set; }
        public string actndate { get; set; }
        public string levelname { get; set; }
        public int parentid { get; set; }
        public int leveldetailid { get; set; }
        public string complaindate { get; set; }
        public DateTime reopendate { get; set; }
        public string reopendesc { get; set; }
        public string grievancestatus { get { return status.ToString(); } }
        public int createdby { get; set; }
        public int userid { get; set; }
        public bool isportal { get; set; }
        public bool canForward { get; set; }
        public string forwardedtocommittee { get; set; }
        public string forwardedbycommittee { get; set; }
        public string forwardedby { get; set; }
        public string forwardedtocommitteename { get; set; }
        public string HouseholdNumber { get; set; }
        public string HouseholdHeadName { get; set; }
        public int updatepriorityid { get; set; }
        public string updatecategoryid { get; set; }
        public int pending { get; set; }
        public int approved { get; set; }
        public int rejected { get; set; }
        public int forwarded { get; set; }
        public int resolved { get; set; }
        public int totalGrievance { get; set; }
        public string grievanceauthority { get; set; }
        public int pendinggriv { get; set; }
        public string admis { get; set; }
        public DateTime createdon { get; set; }
        public int totalnoofstatus { get; set; }
        public int relationid { get; set; }
        public string relationname { get; set; }
    }
}
