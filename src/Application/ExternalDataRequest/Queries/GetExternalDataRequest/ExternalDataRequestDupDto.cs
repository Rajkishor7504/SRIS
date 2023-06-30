/*
* File Name : ExternalDataRequestDto.cs
* class Name : ExternalDataRequestDto
* Created Date : 25 Jun 2021
* Created By : Spandana Ray
* Description : External Data Request DTO
*/

using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest
{
    public class ExternalDataRequestDupDto : SRIS.Domain.Entities.DataRequestCriteria
    {

        public string ActionCode { get; set; }
        public string RequiredService { get; set; }
        public List<ExternalDataRequestDupDto> Lists { get; set; }
        //public List<ExternalDataRequestDto> MyProperty { get; set; }
        public DataRequestCriteria RequestCriteria { get; set; }
        public string Organisation { get; set; }
        public string RequestorName { get; set; }
        public string EMailId { get; set; }
        public string MobileNo { get; set; }
        public string organizationtypename { get; set; }
        public int organisationcategoryid { get; set; }
        public string remarks { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
        public double processedhour { get; set; }
        public string otherdatafile { get; set; }
        public int datarequest_id_linked { get; set; }
        public string programmenamewithcode { get; set; }
        public int registrationpurpose { get; set; }
        // public List<DataRequestCriteria> Lists { get; set; }
        public List<DuplicateExternalDupDto> p_Lists { get; set; }
        //public int p_locationid { get; set; }//adding new property for taking location id
    }

    public class ExternalDataDup
    {
        [DisplayName("HH ID")]
        public int hhid { get; set; }
        [DisplayName("Unique ID")]
        public string uniqueid { get; set; }
        [DisplayName("Request ID")]
        public string ReqId { get; set; }
        [DisplayName("Household Head Name")]
        public string HHName { get; set; }
        [DisplayName("Household No.")]
        public string HHnumber { get; set; }
        [DisplayName("Member Name")]
        public string membername { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("LGA")]
        public string LGAName { get; set; }
        [DisplayName("District")]
        public string DistrictName { get; set; }
        [DisplayName("Ward")]
        public string WardName { get; set; }
        [DisplayName("Town")]
        public string TownName { get; set; }
        [DisplayName("Age")]
        public string Age { get; set; }
        [DisplayName("Contact No")]
        public string telephoneno { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Marital Status")]
        public string MaritalStatusName { get; set; }
        [DisplayName("Is Member currently attending school?")]
        public string iscurrentlyattendingschool { get; set; }
        [DisplayName("Has member ever attended school?")]
        public string haseverattendedschool { get; set; }
        [DisplayName("Does member suffer from any chronic illness?")]
        public string doessufferanychronicillness { get; set; }
        [DisplayName("Does member have any difficulty walking or climbing steps?")]
        public string dohavediffwalking { get; set; }
        [DisplayName("What has been member’s MAIN job/ activity in the last 30 days?")]
        public string MainJobActivity { get; set; }
        [DisplayName("If member has been working, which is his/her status?")]
        public string WorkingStatusName { get; set; }
        [DisplayName("What is the occupancy status of the dwelling?")]
        public string OccupancyStatusDwelling { get; set; }
        [DisplayName("What type of toilet facility does your household use?")]
        public string ToiletType { get; set; }
        [DisplayName("Drinking water supply")]
        public string DrinkingWaterDistance { get; set; }
        [DisplayName("Health center/Dispensary")]
        public string DispensaryDistance { get; set; }
        [DisplayName("Member Household Assets - TV")]
        public string HouseholdTV { get; set; }
        [DisplayName("Member Household Assets - Computer/ Laptop")]
        public string HouseholdComputer { get; set; }
        [DisplayName("Main source of household’s income?")]
        public string MainIncomeSource { get; set; }
        [DisplayName("In the past 12 months, has this household received or collected any aid (money and/or goods) from any organization?")]
        public string didhhreceivemonetaryhelp { get; set; }
        [DisplayName("Does anyone in your household cultivate land?")]
        public string doescultivateland { get; set; }
        [DisplayName("In the last 12 months, have the household’s livelihood activities been affected by any major negative event?")]
        public string ishhaffectedbyevent { get; set; }
        [DisplayName("In the last 12 months, was someone in this household in need of resorting to any of these livelihood coping strategies?")]
        public string livelyhoodcoping { get; set; }
        [DisplayName("In the last 12 months, how often did the household have to resort to any of these food coping strategies?")]

        public string foodcoping { get; set; }

        [DisplayName("PMT Category")]
        public string PmtCategory { get; set; }

        //[DisplayName("Minimum value")]
        //public string pmtCategoryminvalue { get; set; }

        //[DisplayName("Maximum value")]
        //public string pmtCategorymaxvalue { get; set; }
        [DisplayName("PMT Score")]
        public string pmtscore { get; set; }



    }
    public class DuplicateExternalDupDto
    {
        
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
        public string Request_Code { get; set; }
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

        //  public int workingstatus { get; set; }
        public string PMTcatagoryselect { get; set; }

        public List<DuplicateExternalDupDto> p_Lists { get; set; }
        public int Criteria_Id { get; set; }
        public int lga { get; set; }
        public string slga { get; set; }
        public int district { get; set; }
        //public string p_location { get; set; }
        public string sdistrict { get; set; }
        public int ward { get; set; }
        public string sward { get; set; }
        public int town { get; set; }
        public string stown { get; set; }
        public int sex { get; set; }
        public int relationship_to_hh { get; set; }
        public int dob { get; set; }
        public int workingstatus { get; set; }
        public int maritalstatus { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int iscurrentlyattendingschool { get; set; }
        public int whystopschool { get; set; }
        public int whatlastlevelandgradecompleted { get; set; }
        public int whattypeofschoolattended { get; set; }
        public int whichlevelandgradeattended { get; set; }
        public int haseverattendedschool { get; set; }
        public int doessufferanychronicillness { get; set; }
        public int dohavediffwalking { get; set; }
        public int mainjobactivitylastthirtydays { get; set; }
        public int memberworkingstatus { get; set; }
        public int occupancystatusofdwelling { get; set; }
        public int typeoftoiletfacility { get; set; }
        public int distance_serviceid { get; set; }
        public string distance { get; set; }
        public string assets { get; set; }
        public int workingfrequently { get; set; }
        public int memberworkingsctr { get; set; }
        public int reasonfornotworking { get; set; }
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
        public string livelyhoodid { get; set; }
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
        public int mainconstruction { get; set; }
        public int materialusedforroof { get; set; }
        public int materialusedforfloor { get; set; }
        public int sourceoflighting { get; set; }
        public int cookingfuel { get; set; }
        public int sourcedrinkingwater { get; set; }
        public int disposerubbish { get; set; }
        public string ToiletType { get; set; }
        public string IncomeSource { get; set; }


        public int secondmainsource { get; set; }
        public int typeofaidhouse { get; set; }
        public int howfrequently { get; set; }
        public int typeoforganisation { get; set; }
        public string AffectedLivelihood { get; set; }
        public int programmecodeid { get; set; }
        public int pmtCategoryid { get; set; }
        public double pmtCategoryminvalue { get; set; }
        public double pmtCategorymaxvalue { get; set; }
        public string pmtcategory { get; set; }
        public string p_location { get; set; }

        //Added By Rajkishor
        public int memberid { get; set; }
        public int residencestatus { get; set; }
        public int nationality { get; set; }
        public int headtype { get; set; }
        public int contactno { get; set; }
        public int address { get; set; }
        public int min_distance_policepost { get; set; }
        public int max_distance_policepost { get; set; }
        public int min_distance_hospital { get; set; }
        public int max_distance_hospital { get; set; }
        public int readandorwriteinanylanguage { get; set; }
        public int difficultyrememberingorconcentrating { get; set; }
        public int difficultywithself_caresuchaswashing { get; set; }
        public int difficultyhearing { get; set; }
        public int typeofchronicillness { get; set; }
        public int difficultyseeing { get; set; }
        public int difficultycommunicating { get; set; }
        public int shockswhichaffectedhousehold { get; set; }
        public int lossesscausedbylosses { get; set; }
        public int ownedbywhom { get; set; }
        public int typeofecology { get; set; }

        public int rainfedlow { get; set; }
        public int rainfedhigh { get; set; }
        public int Irrigated { get; set; }
        public int Pasture { get; set; }

        public int responsibleforcultivation { get; set; }
        public int involveincatching { get; set; }
        public int householdownlivestock { get; set; }
        //Add By Rajkishor Patra(12-Nov-2022)
        public string sexstring { get; set; }
        public string relationshiptohouseholdstring { get; set; }
        public string maritalstatusstring { get; set; }
        public string residencestatusstring { get; set; }
        public string nationalitystring { get; set; }
        public string haseverattendedschool_string { get; set; }
        public string whattypeofatnschool_string { get; set; }
        public string whichlevelgradeatn_string { get; set; }
        public string iscurrentlyattendingschool_string { get; set; }
        public string stopgoingtoschol_string { get; set; }
        public string lastlevelgrade_string { get; set; }
        public string readandorwriteinanylanguage_string { get; set; }
        public string doessufferanychronicillness_string { get; set; }
        public string difficultyrememberingorconcentrating_string { get; set; }
        public string difficultywithself_caresuchaswashing_string { get; set; }
        public string difficultyhearing_string { get; set; }
        public string dohavediffwalking_string { get; set; }
        public string typeofchronicillness_string { get; set; }
        public string difficultyseeing_string { get; set; }
        public string difficultycommunicating_string { get; set; }
        public string mainjobactivitylastthirtydays_string { get; set; }
        public string workingfrequently_string { get; set; }
        public string memberworkingsctr_string { get; set; }
        public string memberworkingstatus_string { get; set; }
        public string reasonfornotworking_string { get; set; }
        public string occupancystatusofdwelling_string { get; set; }
        public string mainconstruction_string { get; set; }
        public string materialusedforroof_string { get; set; }
        public string materialusedforfloor_string { get; set; }
        public string sourceoflighting_string { get; set; }
        public string cookingfuel_string { get; set; }
        public string typeoftoiletfacility_string { get; set; }
        public string sourcedrinkingwater_string { get; set; }
        public string disposerubbish_string { get; set; }
        public string mainincomesourceofhh_string { get; set; }
        public string secondmainsource_string { get; set; }
        public string didhhreceivemonetaryhelp_string { get; set; }
        public string typeofaidhouse_string { get; set; }
        public string howfrequently_string { get; set; }
        public string typeoforganisation_string { get; set; }
        public string doescultivateland_string { get; set; }
        public string ownedbywhom_string { get; set; }
        public string typeofecology_string { get; set; }
        public string responsibleforcultivation_string { get; set; }
        public string involveincatching_string { get; set; }
        public string householdownlivestock_string { get; set; }
        public string ishhaffectedbyevent_string { get; set; }
        public string shockswhichaffectedhousehold_string { get; set; }
        public string lossesscausedbylosses_string { get; set; }
        public string livelyhoodcoping_string { get; set; }
        public string foodcoping_string { get; set; }
       

        //End
    }
    public class ExternalDataCriteriaDisplayDup
    {
        public string LGAName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string TownName { get; set; }
        public string sex { get; set; }
        public string MinAge { get; set; }
        public string MaxAge { get; set; }
        public string MaritalStatusName { get; set; }
        public string iscurrentlyattendingschool { get; set; }
        public string haseverattendedschool { get; set; }
        public string doessufferanychronicillness { get; set; }
        public string dohavediffwalking { get; set; }
        public string MainJobActivity { get; set; }
        public string WorkingStatusName { get; set; }
        public string OccupancyStatusDwelling { get; set; }
        public string ToiletType { get; set; }
        public string min_distance { get; set; }
        public string max_distance { get; set; }
        public string min_distance_dispensary { get; set; }
        public string max_distance_dispensary { get; set; }
        public string isTVMedium { get; set; }
        public string isComputer { get; set; }
        public string IncomeSource { get; set; }
        public string didhhreceivemonetaryhelp { get; set; }
        public string doescultivateland { get; set; }
        public string ishhaffectedbyevent { get; set; }
        public string livelyhoodcoping { get; set; }
        public string foodcoping { get; set; }
        public string livelyhoodid { get; set; }
        public string AffectedLivelihood { get; set; }
        public string ModeOfSharing { get; set; }
        public string programmenamewithcode { get; set; }
        public int programmecodeid { get; set; }
        public string pmtcategory { get; set; }
        public int pmtCategoryminvalue { get; set; }
        public int pmtCategorymaxvalue { get; set; }

    }
}
