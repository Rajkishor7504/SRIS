using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DataSharing.Queries
{
    public class DataSharingVM : CommonMobileApiStatus
    {
        public IList<GetHouseholdVM> householdlist { get; set; }
        public IList<GetGouseholdrestdataVM> resthouseholddatalist { get; set; }
    }
    public class GetHouseholdVM
    {
        public string lga { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string town { get; set; }
        public string area { get; set; }
        public string eano { get; set; }
        public int compound_number { get; set; }
        public string hhno { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string relation { get; set; }
        public DateTime dob { get; set; }
        public string telephoneno { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public decimal pmtscore { get; set; }
        public string povertyCategorization { get; set; }
    }
    public class GetGouseholdrestdataVM
    {
        public string lga { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string town { get; set; }
        public string area { get; set; }
        public string eano { get; set; }
        public int compound_number { get; set; }
        public string hhno { get; set; }    
        public int hhid { get; set; }
        public int memberid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string relation { get; set; }
        public DateTime dob { get; set; }
        public string telephoneno { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public decimal pmtscore { get; set; }
        public string povertyCategorization { get; set; }
        public string maritalstatus { get; set; }
        public string iscurrentlyattendingschool { get; set; }
        public string haseverattendedschool { get; set; }
        public string doessufferanychronicillness { get; set; }
        public string dohavediffwalking { get; set; }
        public string mainJobActivity { get; set; }
        public string workingstatus { get; set; }
        public string occupancyStatusDwelling { get; set; }
        public string toiletType { get; set; }
        public string drinkingWaterDistance { get; set; }
        public string dispensaryDistance { get; set; }
        public string householdTV { get; set; }
        public string householdComputer { get; set; }
        public string mainIncomeSource { get; set; }
        public string didhhreceivemonetaryhelp { get; set; }
        public string doescultivateland { get; set; }
        public string ishhaffectedbyevent { get; set; }
        public string livelyhoodcoping { get; set; }
        public string foodcoping { get; set; }
    }
}
