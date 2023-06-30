using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery
{
    public class IncomeSourceDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int incomesourceid { get; set; }
        public int mainincomesourceofhh { get; set; }
        public string otherincomesource { get; set; }
        public int secondincomesourceofhh { get; set; }
        public string othersecondincomesource { get; set; }
        public int didhhreceivemonetaryhelp { get; set; }
        public int howmanytimesreceivedmonhelp { get; set; }
        public int amountreceivedinlastoneyear { get; set; }
        public int hashhcollectedanyaidinoneyear { get; set; }
        public int freequencyofaidreceived { get; set; }
        public string otherfreequencyofaidreceived { get; set; }
        public string organizationtype { get; set; }
        public string aidids { get; set; }
        public string orgtypeids { get; set; }
        public string otheraid { get; set; }
        public string otherorgtype { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        //for view purpose
        public string mainincomesourceofhhv { get; set; }
        public string otherincomesourcev { get; set; }
        public string secodincomesourceofhhv { get; set; }
        public string othersecondincomesourceofhhv { get; set; }
        public string didhhreceivemonetaryhelpv { get; set; }
        public string howmanytimesreceivedmonhelpv { get; set; }
        public int amountreceivedinlastoneyearv { get; set; }
        public string hashhcollectedanyaidinoneyearv { get; set; }
        public string freequencyofaidreceivedv { get; set; }
        public string otherfreequencyofaidreceivedv { get; set; }
        public string organizationtypev { get; set; }
        //End

        // Spot Checker
        public int incomesourceid_spt { get; set; }

        public int hhid_spt { get; set; }
        public string mainincomesourceofhh_spt { get; set; }
        public string otherincomesource_spt { get; set; }
        public string secodincomesourceofhh_spt { get; set; }
        public string othersecondincomesourceofhh_spt { get; set; }
        public string didhhreceivemonetaryhelp_spt { get; set; }
        public string howmanytimesreceivedmonhelp_spt { get; set; }
        public int amountreceivedinlastoneyear_spt { get; set; }
        public string hashhcollectedanyaidinoneyear_spt { get; set; }
        public string freequencyofaidreceived_spt { get; set; }
        public string otherfreequencyofaidreceived_spt { get; set; }
        public string organizationtype_spt { get; set; }
        public int spotcheckerstatus { get; set; }
        public int spotcheckerstatus_spt { get; set; }
        // public string mainincomesourceofhh_spt { get; set; }
        public string aidids_spt { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
    }

    public class IncomeStatusSourceDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int incomesourceid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
    }
