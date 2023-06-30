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
    public class ExternalDataRequestDto : SRIS.Domain.Entities.DataRequestCriteria
    {

        //Select column (id) for filter at the time of data request approval(start) Deepak(16-11-2022) 

        public string ap_sex { get; set; }
        public string ap_relationship_to_hh { get; set; }
        public string ap_residencestatus { get; set; }
        public string ap_maritalstatus { get; set; }
        public string ap_nationality { get; set; }
        public string ap_haseverattendedschool { get; set; }
        public string ap_whattypeofschoolattended { get; set; }
        public string ap_whichlevelandgradeattended { get; set; }
        public string ap_iscurrentlyattendingschool { get; set; }
        public string ap_whystopschool { get; set; }
        public string ap_whatlastlevelandgradecompleted { get; set; }
        public string ap_readandorwriteinanylanguage { get; set; }
        public string ap_doessufferanychronicillness { get; set; }
        public string ap_typeofchronicillness { get; set; }
        public string ap_difficultyseeing { get; set; }
        public string ap_difficultyhearing { get; set; }
        public string ap_dohavediffwalking { get; set; }
        public string ap_difficultyrememberingorconcentrating { get; set; }
        public string ap_difficultywithself_caresuchaswashing { get; set; }
        public string ap_difficultycommunicating { get; set; }
        public string ap_mainjobactivitylastthirtydays { get; set; }
        public string ap_hasbeenworking { get; set; }
        public string ap_memberworkingsector { get; set; }
        public string ap_workingstatus { get; set; }
        public string ap_mainreasonofnotworking { get; set; }
        public string ap_occupancystatusofdwelling { get; set; }
        public string ap_mainconstructionmaterialforexterior { get; set; }
        public string ap_materialforroofing { get; set; }
        public string ap_materialforfloor { get; set; }
        public string ap_hhsourcelighting { get; set; }
        public string ap_hhmaincookingfuel { get; set; }
        public string ap_typeoftoiletfacility { get; set; }
        public string ap_mainsourceofdrinkingwater { get; set; }
        public string ap_hhdisposeofrubbish { get; set; }
        //public string ap_distance { get; set; }
        //public string ap_assets { get; set; }
        public string ap_mainincomesourceofhh { get; set; }
        public string ap_hhsecondsourceofincome { get; set; }
        public string ap_didhhreceivemonetaryhelp { get; set; }
        public string ap_typeofaidhhreceived { get; set; }
        public string ap_howfrequentlyaidreceived { get; set; }
        public string ap_whichtypeoforganizationaidreceived { get; set; }
        public string ap_doescultivateland { get; set; }
        public string ap_ifowened_bywhom { get; set; }
        public string ap_typeofecology { get; set; }
        public string ap_householdmemberresponsibleforcultivation { get; set; }
        public string ap_involveincatchingoffarmingfish { get; set; }
        public string ap_householdownlivestock { get; set; }
        public string ap_ishhaffectedbyevent { get; set; }
        public string ap_maintypeofshockaffectedhouseholdactivities { get; set; }
        public string ap_lossescausedbytheshock { get; set; }
        public string ap_livelyhoodcoping { get; set; }
        public string ap_foodcoping { get; set; }
        public string ap_pmtcatagory { get; set; }


        //Select column (id) for filter at the time of data request approval(End) Deepak(16-11-2022) 




        //Select Data At time of Process(Start) Deepak(14-11-2022)
        public string demo_fullname { get; set; }
        public string demo_demography_relationship { get; set; }
        public string demo_dob { get; set; }
        public string demo_address { get; set; }
        public string demo_age { get; set; }
        public string demo_readandorwriteinanylanguage { get; set; }
        public string demo_typeofecology { get; set; }


        public string demo_doessufferanychronicillness { get; set; }
        public string demo_OccupancyStatusDwelling { get; set; }
        public string demo_demography_Residency { get; set; }
        public string demo_demography_Nationality { get; set; }
        public string demo_demography_Readandorwriteinanylanguage { get; set; }
        public string demo_difficultyrememberingorconcentrating { get; set; }
        public string demo_difficultywithself_caresuchaswashing { get; set; }
        public string demo_difficultyhearing { get; set; }
        public string demo_difficultyseeing { get; set; }
        public string demo_difficultycommunicating { get; set; }
        public string demo_dohavediffwalking { get; set; }
        public string demo_typeofchronicillness { get; set; }
        public string demo_Sex { get; set; }
        public string demo_MaritalStatusName { get; set; }
        public string demo_iscurrentlyattendingschool { get; set; }
        public string demo_haseverattendedschool { get; set; }
        public string demo_MainJobActivity { get; set; }
        public string demo_WorkingStatusName { get; set; }
        public string demo_ToiletType { get; set; }
        public string demo_IncomeSource { get; set; }
        public string demo_didhhreceivemonetaryhelp { get; set; }
        public string demo_doescultivateland { get; set; }
        public string demo_ishhaffectedbyevent { get; set; }
        public string demo_whattypeofschoolattended { get; set; }
        public string demo_whichlevelandgradeattended { get; set; }
        public string demo_whystopschool { get; set; }
        public string demo_whatlastlevelandgradecompleted { get; set; }
        public string demo_hasbeenworking { get; set; }
        public string demo_memberworkingsector { get; set; }
        public string demo_mainreasonofnotworking { get; set; }
        public string demo_mainconstructionmaterialforexterior { get; set; }
        public string demo_materialforroofing { get; set; }
        public string demo_materialforfloor { get; set; }
        public string demo_hhsourcelighting { get; set; }
        public string demo_hhmaincookingfuel { get; set; }
        public string demo_mainsourceofdrinkingwater { get; set; }
        public string demo_hhdisposeofrubbish { get; set; }
        public string demo_distance { get; set; }
        public string demo_assets { get; set; }
        public string demo_hhsecondsourceofincome { get; set; }
        public string demo_typeofaidhhreceived { get; set; }
        public string demo_howfrequentlyaidreceived { get; set; }
        public string demo_whichtypeoforganizationaidreceived { get; set; }
        public string demo_ifowened_bywhom { get; set; }
        public string demo_householdmemberresponsibleforcultivation { get; set; }
        public string demo_involveincatchingoffarmingfish { get; set; }
        public string demo_householdownlivestock { get; set; }
        public string demo_maintypeofshockaffectedhouseholdactivities { get; set; }
        public string demo_lossescausedbytheshock { get; set; }
        public string demo_livelyhoodcoping { get; set; }
        public string demo_foodcoping { get; set; }
        public string demo_pmtcategory { get; set; }

        //Select Data At time of Process(Start) Deepak(14-11-2022)

        //Added By Deepak(25-10-2022)
        public int residencestatus_p { get; set; }
        public int nationality_p { get; set; }
        public int headtype_p { get; set; }
        public int readandorwriteinanylanguage_p { get; set; }
        public int difficultyrememberingorconcentrating_p { get; set; }

        public int difficultywithself_caresuchaswashing_p { get; set; }
        public int difficultyhearing_p { get; set; }
        public int typeofchronicillness_p { get; set; }
        public int difficultyseeing_p { get; set; }
        public int difficultycommunicating_p { get; set; }
        public int min_distance_policepost_p { get; set; }
        public int max_distance_policepost_p { get; set; }
        public int min_distance_hospital_p { get; set; }
        public int max_distance_hospital_p { get; set; }

        //End





        public string remark { get; set; } //changes by Deepak Kumar Sahu(11-10-2022)
        public int download_s { get; set; }
        public string statusdownload { get; set; }
        public string ActionCode { get; set; }        
        public string RequiredService { get; set; }
        public List<ExternalDataRequestDto> Lists { get; set; }
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
        public List<DuplicateExternalDto> p_Lists { get; set; }
        //public int p_locationid { get; set; }//adding new property for taking location id
        public string Feedback { get; set; }
        public bool FeedbackStatus { get; set; }
        public string DownloadDate { get; set; }
        public bool DownloadStatus { get; set; }
    }
   
    public class ExternalData
    {
        public string membercode_excel { get; set; } // Created By deepak(17-11-2022)(for select membercode for downloading in excel)

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
        
        //Added By Deepak Kumar Sahu(25-10-2022)
        public string residence_status { get; set; }
        public string nationality { get; set; }
        public string head_type { get; set; }
        public string readandorwriteinanylanguage { get; set; }
        public string difficultyrememberingorconcentrating { get; set; }
        public string difficultywithself_caresuchaswashing { get; set; }
        public string difficultyhearing { get; set; }
        public string typeofchronicillness { get; set; }
        public string difficultyseeing { get; set; }
        public string difficultycommunicating { get; set; }
        public string distance_policepost { get; set; }
        public string distance_hospital { get; set; }
        //end

        public string relationship_to_hh { get; set; }
        public string dob { get; set; }
        public string whattypeofschoolattended { get; set; }
        public string whichlevelandgradeattended { get; set; }
        public string whystopschool { get; set; }
        public string whatlastlevelandgradecompleted { get; set; }

        public string hasbeenworking { get; set; }
        public string memberworkingsector { get; set; }
        public string member_WorkingStatusName { get; set; }
        public string mainreasonofnotworking { get; set; }

    }
    public class DuplicateExternalDto
    {
        public string remark { get; set; } //changes by Deepak Kumar Sahu(11-10-2022)
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





        public List<DuplicateExternalDto> p_Lists { get; set; }
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
        public string ToiletType { get; set; }
        public string IncomeSource { get; set; }
        public string AffectedLivelihood { get; set; }
        public int programmecodeid { get; set; }
        public int pmtCategoryid { get; set; }
        public double pmtCategoryminvalue { get; set; }
        public double pmtCategorymaxvalue { get; set; }
        public string pmtcategory { get; set; }
    }
    public class ExternalDataCriteriaDisplay 
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


        //bind data at the time of approval data sharing popup level box Deepak(16-11-2022)(start)

        public string dem_fullname { get; set; }
        public string dem_Sex { get; set; }
        public string dem_demography_relationship { get; set; }
        public string dem_demography_Residency { get; set; }
        public string dem_dob { get; set; }
        public string dem_MaritalStatusName { get; set; }
        public string dem_address { get; set; }
        public string dem_age { get; set; }
        public string dem_demography_Nationality { get; set; }
        public string dem_haseverattendedschool { get; set; }
        public string dem_whattypeofschoolattended { get; set; }
        public string dem_whichlevelandgradeattended { get; set; }
        public string dem_iscurrentlyattendingschool { get; set; }
        public string dem_whystopschool { get; set; }
        public string dem_whatlastlevelandgradecompleted { get; set; }
        public string dem_readandorwriteinanylanguage { get; set; }
        public string dem_doessufferanychronicillness { get; set; }
        public string dem_typeofchronicillness { get; set; }
        public string dem_difficultyseeing { get; set; }
        public string dem_difficultyhearing { get; set; }
        public string dem_dohavediffwalking { get; set; }
        public string dem_difficultyrememberingorconcentrating { get; set; }
        public string dem_difficultywithself_caresuchaswashing { get; set; }
        public string dem_difficultycommunicating { get; set; }
        public string dem_MainJobActivity { get; set; }
        public string dem_hasbeenworking { get; set; }
        public string dem_memberworkingsector { get; set; }
        public string dem_WorkingStatusName { get; set; }
        public string dem_mainreasonofnotworking { get; set; }
        public string dem_OccupancyStatusDwelling { get; set; }
        public string dem_mainconstructionmaterialforexterior { get; set; }
        public string dem_materialforroofing { get; set; }
        public string dem_materialforfloor { get; set; }
        public string dem_hhsourcelighting { get; set; }
        public string dem_hhmaincookingfuel { get; set; }
        public string dem_ToiletType { get; set; }
        public string dem_mainsourceofdrinkingwater { get; set; }
        public string dem_hhdisposeofrubbish { get; set; }
        public string dem_distance { get; set; }
        public string dem_assets { get; set; }
        public string dem_IncomeSource { get; set; }
        public string dem_hhsecondsourceofincome { get; set; }
        public string dem_didhhreceivemonetaryhelp { get; set; }
        public string dem_typeofaidhhreceived { get; set; }
        public string dem_howfrequentlyaidreceived { get; set; }
        public string dem_whichtypeoforganizationaidreceived { get; set; }
        public string dem_doescultivateland { get; set; }
        public string dem_ifowened_bywhom { get; set; }
        public string dem_typeofecology { get; set; }
        public string dem_householdmemberresponsibleforcultivation { get; set; }
        public string dem_involveincatchingoffarmingfish { get; set; }
        public string dem_householdownlivestock { get; set; }
        public string dem_ishhaffectedbyevent { get; set; }
        public string dem_maintypeofshockaffectedhouseholdactivities { get; set; }
        public string dem_lossescausedbytheshock { get; set; }
        public string dem_livelyhoodcoping { get; set; }
        public string dem_foodcoping { get; set; }
        public string dem_pmtcategory { get; set; }



        //bind data at the time of approval data sharing popup level box Deepak(16-11-2022)(end)

    }
}
