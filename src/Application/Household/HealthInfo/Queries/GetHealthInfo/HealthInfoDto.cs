using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo
{
   public class HealthInfoDto
    {
        public int healthinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int doessufferanychronicillness { get; set; }
        public int dohavediffwearingglass { get; set; }
        public int dohavediffhearing { get; set; }

        public int dohavediffwalking { get; set; }
        public int dohavediffremembering { get; set; }
        public int dohavediffselfcare { get; set; }
        public int dohavediffcommunicate { get; set; }

        
        public string createdby { get; set; }
        public int apptypeid { get; set; }
        public string whatchronicillnesssuffer { get; set; }
        public int age { get; set; }
        public string otherillness { get; set; }

        //For view purpose
        public string doessufferanychronicillnessv { get; set; }
        public string dohavediffwearingglassv { get; set; }
        public string dohavediffhearingv { get; set; }

        public string dohavediffwalkingv { get; set; }
        public string dohavediffrememberingv { get; set; }
        public string dohavediffselfcarev { get; set; }
        public string dohavediffcommunicatev { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
        public int spotchecking { get; set; }
        public string membername { get; set; }

        //Spot Checking
        public string doessufferanychronicillnessv_spt { get; set; }
        public string dohavediffwearingglassv_spt { get; set; }
        public string dohavediffhearingv_spt { get; set; }
        public string dohavediffwalkingv_spt { get; set; }
        public string dohavediffrememberingv_spt { get; set; }
        public string dohavediffselfcarev_spt { get; set; }
        public string dohavediffcommunicatev_spt { get; set; }
        public string hhno_spt { get; set; }
        public string householdheadname_spt { get; set; }
        public string membername_spt { get; set; }
        public int spotchecking_spt { get; set; }
        public int age_spt { get; set; }
        public string whatchronicillnesssuffer_spt { get; set; }
        public int hhid_spt { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
        //end for view
    }
    public class Disease
    {
        public int id { get; set; }
    }


    public class HealthStatusInfoDto
    {
        public int healthinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }

    }
    }
