using Microsoft.AspNetCore.Http;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GrievanceResolutionMasterVM
    {
        public IList<GrievanceResolutionMasterDto> Lists { get; set; }
        public IList<GrievanceRegisteredDto> GrievanceLists { get; set; }
        public IList<GrievanceDetailDto> GrievanceDetailLists { get; set; }
        public IList<GrievanceDetailticketDto> GrievanceDetailticketLists { get; set; }
        public IList<GrievanceStatusDto> GrievanceStatusLists { get; set; }
        public IList<HouseholdDetailsDto> HouseholdDetailsLists { get; set; }
        public IList<SurveyManagerDto> AssignSurveyManagerLists { get; set; }
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
       public string grievancename { get; set; }
        public string grievancedescription { get; set; }
        public string association { get; set; }
        public string document { get; set; }
        public int leveldetailid { get; set; }
        public string levelname { get; set; }
        public string action { get; set; }
        public DateTime reopendate { get; set; }
        public string reopendesc { get; set; }
        public int createdby { get; set; }
        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public string complaindate { get; set; }
        public string compldate { get; set; }
        public IFormFile grievancefile { get; set; }
        public string remarks { get; set; }
        public string purpose { get; set; }
        public string grievancedocument { get; set; }
        public int requestid { get; set; }
        public string householdno { get; set; }
        public string hhheadname { get; set; }
        public int updatepriorityid { get; set; }
        public string priority { get; set; }
        public int updatecategoryid { get; set; }
        public string modulename { get; set; }
        public string admis { get; set; }
        public DateTime createdon { get; set; }
        public int relationid { get; set; }
        public string relationname { get; set; }
        public string PendingAt { get; set; }
        public int refNo { get; set; }
        public int roleid { get; set; }

    }
}
