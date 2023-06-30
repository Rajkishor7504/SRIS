using System.Collections.Generic;

namespace SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery
{
    public class DistanceInfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public string distancexml { get; set; }
        public int apptypeid { get; set; }
        public List<HouseholdDistance> hhDistance { get; set; }
    }
    public class HouseholdDistance
    {
        public int distanceid { get; set; }
        public int serviceid { get; set; }
        public int transportationmodeid { get; set; }
        public string othertransportation { get; set; }
        //public int distanceinkm { get; set; }
        //public int timeinmin { get; set; }
        public decimal distanceinkm { get; set; }
        public int timeinmin { get; set; }

        //Changed by Ashutosh Pradhan on dt: 07-06-2023

        //for view purpose Enumerator
        public string servicev { get; set; }
        public string transportationmodev { get; set; }
        public string othertransportationmodev { get; set; }
        public string timeinminv { get; set; }
        public string distanceinkmv { get; set; }
        public int hhid { get; set; }

        //Spot Checker
        public int distanceid_spt { get; set; }
        public string service_spt { get; set; }
        public string transportationmode_spt { get; set; }
        public string othertransportationmode_spt { get; set; }
        public string timeinmin_spt { get; set; }
        public string distanceinkm_spt { get; set; }
        public int hhid_spt { get; set; }
        public int transportationmodeid_spt { get; set; }
        public string transportationmodev_spt { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }

        //end 
    }


    public class DistanceStatusInfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }       
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
}
