using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class ExternalDataRequest
    {
        [Key]
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
        public string Request_Code { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime createdon { get; set; }
        public int updatedby { get; set; }
        public DateTime updatedon { get; set; }
        public bool deletedflag { get; set; }
    }
    public class DataRequestCriteria : ExternalDataRequest
    {
        [Key]
        public string regdate { get; set; }// changes by Deepak(28-10-2022)

        public string p_location { get; set; }


      //  New Data Process Field Deepak(23-10-2022)

        public string residencestatus_ { get; set; }
        public string nationality_ { get; set; }
        public string readandorwriteinanylanguage_ { get; set; }
        public string difficultyrememberingorconcentrating_ { get; set; }
        public string difficultywithself_caresuchaswashing_ { get; set; }
        public string difficultyhearing_ { get; set; }
        public string typeofchronicillness_ { get; set; }
        public string difficultyseeing_ { get; set; }
        public string difficultycommunicating_ { get; set; }

        //public int min_distance_policepost { get; set; }
        //public int max_distance_policepost { get; set; }
        //public int min_distance_hospital { get; set; }
        //public int max_distance_hospital { get; set; }

        //  End
        //Add By Rajkishor Patra(12-Nov-2022)
        public string sexstringselect { get; set; }
        public string foodcopingselect { get; set; }
        public string livelyhoodcopingselect { get; set; }
        public string lossesscausedbylossesselect { get; set; }
        public string shockswhichaffectedhouseholdselect { get; set; }
        public string ishhaffectedbyeventselect { get; set; }
        public string householdownlivestockselect { get; set; }
        public string involveincatchingselect { get; set; }
        public string responsibleforcultivationselect { get; set; }
        public string typeofecologyselect { get; set; }
        public string ownedbywhomselect { get; set; }
        public string doescultivatelandselect { get; set; }
        public string typeoforganisationselect { get; set; }
        public string howfrequentlyselect { get; set; }
        public string typeofaidhouseselect { get; set; }
        public string didhhreceivemonetaryhelpselect { get; set; }
        public string secondmainsourceselect { get; set; }
        public string mainincomesourceofhhselect { get; set; }
        public string disposerubbishselect { get; set; }
        public string sourcedrinkingwaterselect { get; set; }
        public string typeoftoiletfacilityselect { get; set; }
        public string cookingfuelselect { get; set; }
        public string sourceoflightingselect { get; set; }
        public string materialusedforfloorselect { get; set; }
        public string materialusedforroofselect { get; set; }
        public string mainconstructionselect { get; set; }
        public string occupancystatusofdwellingselect { get; set; }
        public string reasonfornotworkingselect { get; set; }
        public string memberworkingstatusselect { get; set; }
        public string memberworkingsctrselect { get; set; }
        public string workingfrequentlyselect { get; set; }
        public string mainjobactivitylastthirtydaysselect { get; set; }
        public string difficultycommunicatingselect { get; set; }
        public string difficultyseeingselect { get; set; }
        public string typeofchronicillnessselect { get; set; }
        public string dohavediffwalkingselect { get; set; }
        public string difficultyhearingselect { get; set; }
        public string difficultywithself_caresuchaswashingselect { get; set; }
        public string difficultyrememberingorconcentratingselect { get; set; }
        public string doessufferanychronicillnessselect { get; set; }
        public string readandorwriteinanylanguageselect { get; set; }
        public string lastlevelgradeselect { get; set; }
        public string stopgoingtoscholselect { get; set; }
        public string iscurrentlyattendingschoolselect { get; set; }
        public string whichlevelgradeatnselect { get; set; }
        public string whattypeofatnschoolselect { get; set; }
        public string haseverattendedschoolselect { get; set; }
        public string nationalityselect { get; set; }
        public string residencestatusselect { get; set; }
        public string maritalstatusselect { get; set; }
        public string relationshipofhouseholdselect { get; set; }
        public string PMTcatagoryselect { get; set; }

        //End

        //Select column (id) for filter at the time of data request approval(start) Deepak(16-11-2022) 

        public string ap_sex_pi { get; set; }
        public string ap_relationship_to_hh_pi { get; set; }
        public string ap_residencestatus_pi { get; set; }
        public string ap_maritalstatus_pi { get; set; }
        public string ap_nationality_pi { get; set; }
        public string ap_haseverattendedschool_pi { get; set; }
        public string ap_whattypeofschoolattended_pi { get; set; }
        public string ap_whichlevelandgradeattended_pi { get; set; }
        public string ap_iscurrentlyattendingschool_pi { get; set; }
        public string ap_whystopschool_pi { get; set; }
        public string ap_whatlastlevelandgradecompleted_pi { get; set; }
        public string ap_readandorwriteinanylanguage_pi { get; set; }
        public string ap_doessufferanychronicillness_pi { get; set; }
        public string ap_typeofchronicillness_pi { get; set; }
        public string ap_difficultyseeing_pi { get; set; }
        public string ap_difficultyhearing_pi { get; set; }
        public string ap_dohavediffwalking_pi { get; set; }
        public string ap_difficultyrememberingorconcentrating_pi { get; set; }
        public string ap_difficultywithself_caresuchaswashing_pi { get; set; }
        public string ap_difficultycommunicating_pi { get; set; }
        public string ap_mainjobactivitylastthirtydays_pi { get; set; }
        public string ap_hasbeenworking_pi { get; set; }
        public string ap_memberworkingsector_pi { get; set; }
        public string ap_workingstatus_pi { get; set; }
        public string ap_mainreasonofnotworking_pi { get; set; }
        public string ap_occupancystatusofdwelling_pi { get; set; }
        public string ap_mainconstructionmaterialforexterior_pi { get; set; }
        public string ap_materialforroofing_pi { get; set; }
        public string ap_materialforfloor_pi { get; set; }
        public string ap_hhsourcelighting_pi { get; set; }
        public string ap_hhmaincookingfuel_pi { get; set; }
        public string ap_typeoftoiletfacility_pi { get; set; }
        public string ap_mainsourceofdrinkingwater_pi { get; set; }
        public string ap_hhdisposeofrubbish_pi { get; set; }
        //public string ap_distance_pi { get; set; }
        //public string ap_assets_pi { get; set; }
        public string ap_mainincomesourceofhh_pi { get; set; }
        public string ap_hhsecondsourceofincome_pi { get; set; }
        public string ap_didhhreceivemonetaryhelp_pi { get; set; }
        public string ap_typeofaidhhreceived_pi { get; set; }
        public string ap_howfrequentlyaidreceived_pi { get; set; }
        public string ap_whichtypeoforganizationaidreceived_pi { get; set; }
        public string ap_doescultivateland_pi { get; set; }
        public string ap_ifowened_bywhom_pi { get; set; }
        public string ap_typeofecology_pi { get; set; }
        public string ap_householdmemberresponsibleforcultivation_pi { get; set; }
        public string ap_involveincatchingoffarmingfish_pi { get; set; }
        public string ap_householdownlivestock_pi { get; set; }
        public string ap_ishhaffectedbyevent_pi { get; set; }
        public string ap_maintypeofshockaffectedhouseholdactivities_pi { get; set; }
        public string ap_lossescausedbytheshock_pi { get; set; }
        public string ap_livelyhoodcoping_pi { get; set; }
        public string ap_foodcoping_pi { get; set; }
        public string ap_pmtcatagory_pi { get; set; }


        //Select column (id) for filter at the time of data request approval(End) Deepak(16-11-2022)




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
        public int member { get; set; }
        public int relationshiptohousehold { get; set; }
        public int sex { get; set; }
        public int maritalstatus { get; set; }
        public int residencestatus { get; set; }
        public int dob { get; set; }
        public int nationality { get; set; }
        public int headtype { get; set; }
        public int contactno { get; set; }
        public int address { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int iscurrentlyattendingschool { get; set; }
        public int whattypeofatnschool { get; set; }
        public int whichlevelgradeatn { get; set; }
        public int readandorwriteinanylanguage { get; set; }
        public int haseverattendedschool { get; set; }
        public int stopgoingtoschol { get; set; }
        public int lastlevelgrade { get; set; }
        public int doessufferanychronicillness { get; set; }
        public int difficultyrememberingorconcentrating { get; set; }
        public int difficultywithself_caresuchaswashing { get; set; }
        public int difficultyhearing { get; set; }
        public int dohavediffwalking { get; set; }
        public int typeofchronicillness { get; set; }
        public int difficultyseeing { get; set; }
        public int difficultycommunicating { get; set; }

        public int memberworkingstatus { get; set; }
        public int mainjobactivitylastthirtydays { get; set; }
        public int workingfrequently { get; set; }
        public int memberworkingsctr { get; set; }
        public int workingstatus { get; set; }
        public int reasonfornotworking { get; set; }
        public int occupancystatusofdwelling { get; set; }
        public int mainconstruction { get; set; }
        public int materialusedforroof { get; set; }
        public int materialusedforfloor { get; set; }
        public int typeoftoiletfacility { get; set; }
        public int sourceoflighting { get; set; }
        public int cookingfuel { get; set; }
        public int sourcedrinkingwater { get; set; }
        public int disposerubbish { get; set; }
        public int distance_serviceid { get; set; }
        public int min_distance { get; set; }
        public string distance { get; set; }
        public string assets { get; set; }
        public int max_distance { get; set; }
        public int min_distance_dispensary { get; set; }
        public int max_distance_dispensary { get; set; }
        public int min_distance_policepost { get; set; }
        public int max_distance_policepost { get; set; }
        public int min_distance_hospital { get; set; }
        public int max_distance_hospital { get; set; }


        public int min_distance_markt_lumo { get; set; }
        public int max_distance_markt_lumo { get; set; }

        public int min_distance_Pre_school { get; set; }
        public int max_distance_Pre_school { get; set; }

        public int min_distance_Primaryschool { get; set; }
        public int max_distance_Primaryschool { get; set; }

        public int min_distance_Secondaryschool { get; set; }
        public int max_distance_Secondaryschool { get; set; }

        public int min_distance_Postoffice { get; set; }
        public int max_distance_Postoffice { get; set; }

        public int min_distance_seasonedroad { get; set; }
        public int max_distance_seasonedroad { get; set; }
        public int min_distance_FireandRescue { get; set; }
        public int max_distance_FireandRescue { get; set; }

        public int min_distance_Financialservices { get; set; }
        public int max_distance_Financialservices { get; set; }

        public int min_distance_Electricity { get; set; }
        public int max_distance_Electricity { get; set; }

        public int min_distance_Tertiary { get; set; }
        public int max_distance_Tertiary { get; set; }
       
        
        public int mainincomesourceofhh { get; set; }
        public int secodincomesourceofhh { get; set; }
        public int secondmainsource { get; set; }
        public int typeofaidhouse { get; set; }
        public int howfrequently { get; set; }
        public int typeoforganisation { get; set; }
        public int ownedbywhom { get; set; }
        public int typeofecology { get; set; }

        public int rainfedlow { get; set; }
        public int rainfedhigh { get; set; }
        public int Irrigated { get; set; }
        public int Pasture { get; set; }

        public int typeoflivestock { get; set; }
        public int responsibleforcultivation { get; set; }
        public int involveincatching { get; set; }
        public int householdownlivestock { get; set; }
        //public int responsibleforcultivation { get; set; }
        public int amountreceivedinlastoneyear { get; set; }
        public int hashhcollectedanyaidinoneyear { get; set; }
        public int isTVMedium { get; set; }
        public int isComputer { get; set; }


        public int isRadio { get; set; }
        public int ismblphone { get; set; }
        public int islandphone { get; set; }
        public int isBicycle { get; set; }
        public int isMotorcycle { get; set; }
        public int isCar { get; set; }
        public int isTruck { get; set; }

        public int isBus { get; set; }
        public int isBoat { get; set; }
        public int isAnimal { get; set; }
        public int shockswhichaffectedhousehold { get; set; }
        public int lossesscausedbylosses { get; set; }
        //public int workingstatus { get; set; }
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

        // New Data Process Field Deepak(23-10-2022)

        public string demography_Residency { get; set; }
        public string demography_Nationality { get; set; }
        public string demography_Readandorwriteinanylanguage { get; set; }
        public string demography_Difficultyrememberingorconcentrating { get; set; }
        public string demography_Difficultywithself_caresuchaswashing { get; set; }
        public string demography_Difficultyhearing { get; set; }
        public string demography_Typeofchronicillness { get; set; }
        public string demography_Difficultyseeing { get; set; }
        public string demography_Difficultycommunicating { get; set; }

        // End
    }
    public enum RequestStatus
    {
        Pending = 1, Approved, Rejected, Processed
    }
    public class ExternalDataOther
    {
        [Key]
        public int generate_id { get; set; }
        public int hhid { get; set; }
        public string request_id { get; set; }
        public string HHName { get; set; }
        public string HHnumber { get; set; }
        public string membername { get; set; }
        public string Gender { get; set; }
        public string LGAName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string TownName { get; set; }
        public string Age { get; set; }
        public string telephoneno { get; set; }
        public string address { get; set; }
        public string MaritalStatusName { get; set; }
        public string iscurrentlyattendingschool { get; set; }
        public string haseverattendedschool { get; set; }
        public string doessufferanychronicillness { get; set; }
        public string dohavediffwalking { get; set; }
        public string MainJobActivity { get; set; }
        public string WorkingStatusName { get; set; }
        public string OccupancyStatusDwelling { get; set; }
        public string ToiletType { get; set; }
        public string DrinkingWaterDistance { get; set; }
        public string DispensaryDistance { get; set; }
        public string HouseholdTV { get; set; }
        public string HouseholdComputer { get; set; }
        public string MainIncomeSource { get; set; }
        public string didhhreceivemonetaryhelp { get; set; }
        public string doescultivateland { get; set; }
        public string ishhaffectedbyevent { get; set; }
        public string livelyhoodcoping { get; set; }
        public string foodcoping { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
    }
}
