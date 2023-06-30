using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery
{
    public class ImpactDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int impactid { get; set; }
        public int ishhaffectedbyevent { get; set; }
        public string livelyhoodaffectedids { get; set; }
        public int shockforcropid { get; set; }
        public int shockforlivestockid { get; set; }
        public int shockforlabourid { get; set; }
        public string othershockforcrop { get; set; }
        public string othershockforlivestock { get; set; }
        public string othershockforlabour { get; set; }
        public int typeofserveritylivestock { get; set; }
        public int typeofseveritycrops { get; set; }
        public int typeofseveritylabour { get; set; }
        public int shockforotherid { get; set; }
        public string othershockforother { get; set; }
        public int typeofseverityother { get; set; }

        public string otheraffectedlivelyhood { get; set; }
        //for view purpose
        public string ishhaffectedbyeventv { get; set; }
        public string shockforcropv { get; set; }
        public string shockforlivestockv { get; set; }
        public string shockforlabourv { get; set; }
        public string othershockforcropv { get; set; }
        public string othershockforlivestockv { get; set; }
        public string othershockforlabourv { get; set; }
        public string typeofseveritycropsv { get; set; }
        public string typeofserveritylivestockv { get; set; }
        public string typeofseveritylabourv { get; set; }
        public string shockforotherv { get; set; }
        public string othershockforotherv { get; set; }
        public string typeofseverityotherv { get; set; }
        //end

        //Spot Checker
        public int shockforotherid_spt { get; set; }
        public string shockforcropv_spt { get; set; }
        public string othershockforcropv_spt { get; set; }
        public int ishhaffectedbyevent_spt { get; set; }
        public string ishhaffectedbyeventv_spt { get; set; }
        
        public int impactid_spt { get; set; }
        public string otheraffectedlivelyhood_spt { get; set; }
        public string livelyhoodaffectedids_spt { get; set; }
        public int hhid_spt { get; set; }
        public int shockforcropid_spt { get; set; }
        public string shockforcrop_spt { get; set; }
        public string shockforlivestock_spt { get; set; }
        public string shockforlabour_spt { get; set; }
        public string othershockforcrop_spt { get; set; }
        public string othershockforlivestock_spt { get; set; }
        public string othershockforlabour_spt { get; set; }
        public string typeofseveritycrops_spt { get; set; }
        public string typeofserveritylivestock_spt { get; set; }
        public string typeofseveritylabour_spt { get; set; }
        public string shockforother_spt { get; set; }
        public string othershockforother_spt { get; set; }
        public string typeofseverityother_spt { get; set; }
        public string Identificationdoc { get; set; }
        public string Identificationdoc_aft { get; set; }
        //End Spot Checker
        //Approver
        public string livelyhoodaffectedids_aft { get; set; }
        public string otheraffectedlivelyhood_aft { get; set; }
        public string ishhaffectedbyeventv_aft { get; set; }
        public int shockforcropid_aft { get; set; }
        public string shockforcropv_aft { get; set; }
        public string othershockforcropv_aft { get; set; }
        public int shockforlivestockid_aft { get; set; }
        public string shockforlivestockv_aft { get; set; }
        public string othershockforlivestockv_aft { get; set; }
        public int shockforlabourid_aft { get; set; }
        public string shockforlabourv_aft { get; set; }
        public string othershockforlabourv_aft { get; set; }
        public int shockforotherid_aft { get; set; }
        public string shockforotherv_aft { get; set; }
        public string othershockforotherv_aft { get; set; }
        public string typeofseveritycropsv_aft { get; set; }
        public string typeofserveritylivestockv_aft { get; set; }
        public string typeofseverityotherv_aft { get; set; }
        public string typeofseveritylabourv_aft { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
    }
}
