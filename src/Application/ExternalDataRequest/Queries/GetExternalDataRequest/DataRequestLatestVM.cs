using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest
{
    public class DataRequestLatestVM
    {
        public DataRequestLatestVM()
        {
           
            p_Lists = new List<DuplicateExternalDupDto>();
        }
        public List<DuplicateExternalDupDto> p_Lists { get; set; }
       
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
       
        public string Request_Purpose { get; set; }
        public string Program_Name { get; set; }
        public string Program_Code { get; set; }
        public string Country { get; set; }
         public int Required_Service { get; set; }
      
        public string ModeOfSharing { get; set; }
        public int Total_HH_Registered { get; set; }
        public int member { get; set; }
        public int address { get; set; }
        public int dob { get; set; }
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
        public int datarequest_id_linked { get; set; }
        public int Criteria_Id { get; set; }
        public string slga { get; set; }
       public string PMTcatagoryselect { get; set; }
        public string sdistrict { get; set; }
     
        public string sward { get; set; }
       
        public string stown { get; set; }
       
       
        public string distance { get; set; }
        public string assets { get; set; }
        public int MinAge { get; set; }
       
        public int programmecodeid { get; set; }
       
        public string organisationname { get; set; }
    }
}

