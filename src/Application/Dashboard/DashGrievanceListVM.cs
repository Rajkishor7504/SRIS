using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Dashboard
{
    public class DashGrievanceListVM
    {
        public IList<DashboardDto> Lists { get; set; }
        //public IList<GrievanceRegisteredDto> GrievanceLists { get; set; }
        //public IList<GrievanceDetailDto> GrievanceDetailLists { get; set; }
        //public IList<GrievanceStatusDto> GrievanceStatusLists { get; set; }
        //public IList<HouseholdDetailsDto> HouseholdDetailsLists { get; set; }

        public int pending { get; set; }
        public int approved { get; set; }
        public int rejected { get; set; }
        public int forwarded { get; set; }
        public int resolved { get; set; }
        public int totalGrievance { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string action { get; set; }
        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public string grievanceauthority { get; set; }
        public int pendinggriv { get; set; }
        public string organisationname { get; set; }
        public string grievancename { get; set; }
        public string surveyplanname { get; set; }
        public int totalhousehold { get; set; }
        public int totalapproved { get; set; }
        public string district { get; set; }
        public string location { get; set; }
        public int total { get; set; }
        public int id { get; set; }
        public int verificationpending { get; set; }
        public int approvalpending { get; set; }
        public int verificationrejected { get; set; }
        public int approvalrejected { get; set; }
        public int totalnoofdatarequest { get; set; }
        public int totalnoofpending { get; set; }
        public int totalnoofapproved { get; set; }
        public int totalnoofrejected { get; set; }
        public int totalnoofprocessed { get; set; }

        //HH and Grievance Status(Start) Created by Deepak Kumar Sahu(21-09-2022)
        public int NoOfHH { get; set; }
        public int NonPoorHousehold { get; set; }
        public int PoorHousehold { get; set; }
        public int ExtremlyPoorHousehold { get; set; }

        //HH and Grievance Status(End)

        // Graph Year(Start)  Created by Deepak Kumar Sahu(27-09-2022)
        public string h_create_year { get; set; }
        public string g_create_year { get; set; }
        public string dr_create_year { get; set; }
        public string part_create_year { get; set; }
        public string sm_create_year { get; set; }

        // Graph Year(End)

        //Grievance summary filter year(start) Created by Deepak Kumar Sahu(27-09-2022)
        public string yeargv { get; set; }

        //Grievance summary filter year(End)

        //Dashboard  non-graph filter year(start) Created by Deepak Kumar Sahu(10-10-2022)
        public string yearga { get; set; }

        //Dashboard  non-graph filter year(End)

        //Dashboard of nspsgrievance login for pmt (start) (Deepak(23-11-2022))

        public string region_name { get; set; }
        public int Extremely_poor { get; set; }
        public int Poor { get; set; }
        public int Non_Poor { get; set; }

        //Dashboard of nspsgrievance login for pmt (End) (Deepak(23-11-2022))

    }
}
