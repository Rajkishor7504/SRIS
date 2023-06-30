using Microsoft.AspNetCore.Http;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest
{
    public class ExternalDataRequestDupVM
    {
        public ExternalDataRequestDupVM()
        {
            //Lists = new List<ExternalDataRequestDto>();
            p_Lists = new List<DuplicateExternalDupDto>();
        }
        // public int p_locationid { get; set; }//adding new property for taking location id
        public List<DuplicateExternalDupDto> p_Lists { get; set; }
        public string ActionCode { get; set; }
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
        public RequestStatus Request_Status { get; set; }

        public string Request_Purpose { get; set; }
        public string Program_Name { get; set; }
        public string Program_Code { get; set; }
        public string Country { get; set; }
        public int Required_Service { get; set; }
        public string Other_Service_Request { get; set; }
        public string DataPath { get; set; }
        public string ModeOfSharing { get; set; }
        public int Total_HH_Registered { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int updatedby { get; set; }
        public DateTime updatedon { get; set; }
        public bool deletedflag { get; set; }
        public DataRequestCriteria RequestCriteria { get; set; }
        // public IList<ExternalDataRequestDto> Lists { get; set; }
        public string Remarks { get; set; }
        public IList<ExternalData> ExternalDataLists { get; set; }
        public int totalHouseholdCount { get; set; }
        public int totalMemberCount { get; set; }
        public IList<ExternalDataCriteriaDisplayDup> ExternalDataCriteriaLists { get; set; }
        public string email { get; set; }
        public IFormFile otherdatadocument { get; set; }
        public string otherdatafile { get; set; }
        public IList<ExternalDataOther> ExternalDataOtherList { get; set; }
        public int datarequest_id_linked { get; set; }
        public int registrationpurpose { get; set; }
        // public List<DataRequestCriteria> R_Lists { get; set; }
        public List<ExternalDataRequestDto> R_Lists { get; set; }
        //public List<DataRequestCriteria> MyProperty { get; set; }
        public int Criteria_Id { get; set; }
        public int lga { get; set; }
        public string slga { get; set; }
        public int district { get; set; }
        public string p_location { get; set; }
        public string sdistrict { get; set; }
        public int ward { get; set; }
        public string sward { get; set; }
        public int town { get; set; }
        public string stown { get; set; }
        public int sex { get; set; }
        public int maritalstatus { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int iscurrentlyattendingschool { get; set; }
        public int haseverattendedschool { get; set; }
        public int doessufferanychronicillness { get; set; }
        public int dohavediffwalking { get; set; }
        public int mainjobactivitylastthirtydays { get; set; }
        public int workingstatus { get; set; }
        public int occupancystatusofdwelling { get; set; }
        public int typeoftoiletfacility { get; set; }
        public int distance_serviceid { get; set; }
        public int min_distance { get; set; }
        public int max_distance { get; set; }
        public int min_distance_dispensary { get; set; }
        public int max_distance_dispensary { get; set; }
        public int mainincomesourceofhh { get; set; }
        public int secodincomesourceofhh { get; set; }
        public int amountreceivedinlastoneyear { get; set; }
        public int hashhcollectedanyaidinoneyear { get; set; }
        public int isTVMedium { get; set; }
        public int isComputer { get; set; }
        public int didhhreceivemonetaryhelp { get; set; }
        public int doescultivateland { get; set; }
        public int ishhaffectedbyevent { get; set; }
        // public string livelyhoodid { get; set; }
        public int livelyhoodcoping { get; set; }
        public int foodcoping { get; set; }
        public string LGAName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string TownName { get; set; }
        public string MaritalStatusName { get; set; }
        public string MainJobActivity { get; set; }
        public string WorkingStatusName { get; set; }
        public string OccupancyStatusDwelling { get; set; }
        public string ToiletType { get; set; }
        public string IncomeSource { get; set; }
        public string AffectedLivelihood { get; set; }
        public int programmecodeid { get; set; }
        public int pmtCategoryid { get; set; }
        public double pmtCategoryminvalue { get; set; }
        public double pmtCategorymaxvalue { get; set; }
        public string pmtcategory { get; set; }
        public List<ExternalDataRequestDupDto> Lists { get; set; }
        public string organisationname { get; set; }
    }
}
