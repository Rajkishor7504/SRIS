using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery
{
    public class HousingInfoDto
    {
        public int lockstatus { get; set; }
        public string action { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int hhid_spt { get; set; }
        public int housinginfoid { get; set; }
        public int occupancystatusofdwelling { get; set; }
        public int mainconstructionmaterial { get; set; }
        public string otherconstructionmaterial { get; set; }
        public int mainmaterialusedforroofing { get; set; }
        public string othermaterialroofing { get; set; }
        public int mainmaterialusedforflooring { get; set; }
        public string othermaterialflooring { get; set; }
        public int mainsourceoflighting { get; set; }
        public string othersourceoflighting { get; set; }
        public int maincookingfuel { get; set; }
        public string othermaincookingfuel { get; set; }
        public int typeoftoiletfacility { get; set; }
        public string othertoiletfacility { get; set; }
        public int toiletsharedwithotherhh { get; set; }
        public int howmanyhhusetoiletfacility { get; set; }
        public int mainsourceofdrinkingwater { get; set; }
        public string othersourceofdrinkingwater { get; set; }

        public int howhhdisposerubbish { get; set; }
        public string otherwayforrubbish { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        //for view purpose
        public string occupancystatusofdwellingv { get; set; }
        public string mainconstructionmaterialv { get; set; }
        public string otherconstructionmaterialv { get; set; }
        public string mainmaterialusedforroofingv { get; set; }
        public string othermaterialroofingv { get; set; }
        public string mainmaterialusedforflooringv { get; set; }
        public string othermaterialflooringv { get; set; }
        public string mainsourceoflightingv { get; set; }
        public string othersourceoflightingv { get; set; }
        public string maincookingfuelv { get; set; }
        public string othermaincookingfuelv { get; set; }
        public string typeoftoiletfacilityv { get; set; }
        public string othertoiletfacilityv { get; set; }
        public string toiletsharedwithotherhhv { get; set; }
        public int howmanyhhusetoiletfacilityv { get; set; }
        public string mainsourceofdrinkingwaterv { get; set; }
        public string othersourceofdrinkingwaterv { get; set; }
        public string howhhdisposerubbishv { get; set; }
        public string otherwayforrubbishv { get; set; }
        //end
        public string occupancystatusofdwellingv_aft { get; set; }
        public string occupancystatusofdwelling_aft { get; set; }
        public int mainconstructionmaterial_aft { get; set; }
        public string otherconstructionmaterial_aft { get; set; }
        public int mainmaterialusedforroofing_aft { get; set; }
        public string othermaterialroofing_aft { get; set; }
        public string mainmaterialusedforflooring_aft { get; set; }
        public string othermaterialflooring_aft { get; set; }
        public string mainsourceoflighting_aft { get; set; }
        public string othersourceoflighting_aft { get; set; }
        public int maincookingfuel_aft { get; set; }
        public string othermaincookingfuel_aft { get; set; }
        public string typeoftoiletfacility_aft { get; set; }
        public string othertoiletfacility_aft { get; set; }
        public string toiletsharedwithotherhh_aft { get; set; }
        public int howmanyhhusetoiletfacility_aft { get; set; }
        public string mainsourceofdrinkingwater_aft { get; set; }
        public string othersourceofdrinkingwater_aft { get; set; }

        public string howhhdisposerubbish_aft { get; set; }
        public string otherwayforrubbish_aft { get; set; }
        public string mainconstructionmaterialv_aft { get; set; }
        public string mainmaterialusedforroofingv_aft { get; set; }
        public string mainmaterialusedforflooringv_aft { get; set; }
        public string maincookingfuelv_aft { get; set; }
        public string othermaincookingfuelv_aft { get; set; }


        //Spot Checker
        public string occupancystatusofdwelling_spt { get; set; }
        public string mainconstructionmaterial_spt { get; set; }
        public string otherconstructionmaterial_spt { get; set; }
        public string mainmaterialusedforroofing_spt { get; set; }
        public string othermaterialroofing_spt { get; set; }
        public string mainmaterialusedforflooring_spt { get; set; }
        public string othermaterialflooring_spt { get; set; }
        public string mainsourceoflighting_spt { get; set; }
        public string othersourceoflighting_spt { get; set; }
        public string maincookingfuel_spt { get; set; }
        public string othermaincookingfuel_spt { get; set; }
        public string typeoftoiletfacility_spt { get; set; }
        public string othertoiletfacility_spt { get; set; }
        public string toiletsharedwithotherhh_spt { get; set; }
        public int howmanyhhusetoiletfacility_spt { get; set; }
        public string mainsourceofdrinkingwater_spt { get; set; }
        public string othersourceofdrinkingwater_spt { get; set; }

        public string howhhdisposerubbish_spt { get; set; }
        public string otherwayforrubbish_spt { get; set; }
        public int mainconstructionmaterialspt { get; set; }
        public int mainmaterialusedforroofingspt { get; set; }
        public int mainmaterialusedforflooringspt { get; set; }
        public int mainsourceoflightingspt { get; set; }
        public int maincookingfuelspt { get; set; }
        public int typeoftoiletfacilityspt { get; set; }
        public int mainsourceofdrinkingwaterspt { get; set; }
        public int howhhdisposerubbishspt { get; set; }
        public int toiletsharedwithotherhhspt { get; set; }
        public int spotcheckerstatus { get; set; }
        public int spotcheckerstatus_spt { get; set; }
        public int housinginfoid_aft { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
    }
}
