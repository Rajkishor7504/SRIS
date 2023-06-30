using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold
{
    public class RegisterHouseholdDto
    {
        public int teamId { get; set; }
        public int clusterno { get; set; }
        public int lgaid { get; set; }
        public int hhid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }  
        //public int clusterno { get; set; }
        public int settlementid { get; set; }
        public string lga { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }

        public string dateofinterview { get; set; }
        public string interviewer { get; set; }
        public string supervisor { get; set; }
        public int areaid { get; set; }
        public string area { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string hhno { get; set; }
        public string eano { get; set; }
        public string compoundno { get; set; }
        public int isaggreed { get; set; }

        public string isaggreedforinterview { get; set; }
        public string respondantname { get; set; }
        public string telephoneno { get; set; }
        public string address { get; set; }
        public string householdheadname { get; set; }
        public string resultofhhinterview { get; set; }
        public string observation { get; set; }
        public string createdby { get; set; }
        public string hhcode { get; set; }

        public string action { get; set; }
        public int totalrecords { get; set; }
        public string settlementcode { get; set; }
        public int spotchecker { get; set; }
        public DateTime createdon { get; set; }

        public int overallverifiedstatus { get; set; }
        public int allapprovedstatus { get; set; }
        public int verifystatus { get; set; }
        public int createdid { get; set; }
        public int lockstatus { get; set; }

        public string createddate { get; set; }
        public int surveyplanid { get; set; }
        public string surveyplanname { get; set; }

        //Spot Checker
        public int lgaidspt { get; set; }
        public int hhidspt { get; set; }
        public int districtidspt { get; set; }
        public int wardidspt { get; set; }
        public int sptclusterno { get; set; }
        public int settlementidspt { get; set; }
        public string lgaspt { get; set; }
        public string districtspt { get; set; }
        public string wardspt { get; set; }
        public string settlementspt { get; set; }

        public string dateofinterviewspt { get; set; }
        public string interviewerspt { get; set; }
        public string supervisorspt { get; set; }
        public int areaidspt { get; set; }
        public string areaspt { get; set; }
        public string latitudespt { get; set; }
        public string longitudespt { get; set; }
        public string hhnospt { get; set; }
        public string eanospt { get; set; }
        public string compoundnospt { get; set; }
        public int isaggreedspt { get; set; }

        public string isaggreedforinterviewsptspt { get; set; }
        public string respondantnamespt { get; set; }
        public string telephonenospt { get; set; }
        public string addressspt { get; set; }
        public string householdheadnamespt { get; set; }
        public string resultofhhinterviewspt { get; set; }
        public string observationspt { get; set; }
        public string createdbyspt { get; set; }
        public string hhcodespt { get; set; }

        public string actionspt { get; set; }
        public int totalrecordsspt { get; set; }
        public string settlementcodespt { get; set; }
        public int spotcheckerspt { get; set; }
        public DateTime createdonspt { get; set; }

        public int overallverifiedstatusspt { get; set; }
        public int allapprovedstatusspt { get; set; }
        public int verifystatusspt { get; set; }
        public int createdidspt { get; set; }

        public string createddatespt { get; set; }
        public int surveyplanidspt { get; set; }
        public string surveyplannamespt { get; set; }
        //
        public string ModeOfRequest { get; set; }
        public string Remarks { get; set; }
        public string Ticketid { get; set; }
        public int Grievanceregistrationid { get; set; }

        public string modulename { get; set; }
        public int moduleid { get; set; }
        public int requestid { get; set; }

        public List<Module> moduleList { get; set; }
        public string dateofcomplian { get; set; }
        public string RejectRemark { get; set; }
        public int approvestatus { get; set; }
        public int updatestatus { get; set; }
        public string dateofresolvedcomplian { get; set; }
    }
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
