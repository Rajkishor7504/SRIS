using SRIS.Domain.Entities.MasterEntities;
using System;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GrievanceDetailDto
    {
        public int forwardedId { get; set; }
        public int grievanceId { get; set; }
        public int forwardedBy_userId { get; set; }
        public int forwardedBy_committeeId { get; set; }
        public int forwardedTo_committeeId { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
        public int? updatedby { get; set; }
        public DateTime? createdon { get; set; }
        public DateTime? updatedon { get; set; }
        public string remarks { get; set; }
        public string forwardedBy { get; set; }
        public string forwardedTo { get; set; }
        public string actionTakenBy { get; set; }
        public string grievanceStatus { get; set; }
        public string householdno { get; set; }
        public string hhheadname { get; set; }
        public int updatepriorityid { get; set; }
        public string priority { get; set; }
        public int updatecategoryid { get; set; }
        public string modulename { get; set; }
        public string PendingAt { get; set; }

    }
    public class GrievanceDetailticketDto
    {
        public int forwardedId { get; set; }
        public int grievanceId { get; set; }
        public int forwardedBy_userId { get; set; }
        public int forwardedBy_committeeId { get; set; }
        public int forwardedTo_committeeId { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
        public int? updatedby { get; set; }
        public DateTime? createdon { get; set; }
        public DateTime? updatedon { get; set; }
        public string remarks { get; set; }
        public string forwardedBy { get; set; }
        public string forwardedTo { get; set; }
        public string actionTakenBy { get; set; }
        public string grievanceStatus { get; set; }
        public string householdno { get; set; }
        public string hhheadname { get; set; }
        public int updatepriorityid { get; set; }
        public string priority { get; set; }
        public int updatecategoryid { get; set; }
        public string modulename { get; set; }
        public string PendingAt { get; set; }

    }
    public class GrievanceStatusDto
    {
        public int statusid { get; set; }
        public int grievanceId { get; set; }
        public ResolutionStatus status { get; set; }
        public string remarks { get; set; }
        public int createdby { get; set; }
        public DateTime? createdon { get; set; }
        public string actionTakenBy { get; set; }
        public string actionTakenByCommittee { get; set; }
        public string purpose { get; set; }
        public string grievancedocument { get; set; }
        public string PendingAt { get; set; }
    }
    public class HouseholdDetailsDto
    {
        public int grievanceId { get; set; }
        public string householdno { get; set; }
        public string hhheadname { get; set; }
        public int updatepriorityid { get; set; }
        public string priority { get; set; }
        public int updatecategoryid { get; set; }
        public string modulename { get; set; }
    }
    public class SurveyManagerDto
    {
        public int assignmanagerid { get; set; }
        public int surveyplanid { get; set; }
        public int userid { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public string surveyname { get; set; }
        public string userfullname { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
        public string region { get; set; }
        public string district { get; set; }
    }
}
