using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo
{
    public class EducationInfoDto
    {
        public int educationinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int isCurrentlyAttendingSchool { get; set; }
        public int age { get; set; }
        public int whystoppedgoingschool { get; set; }

        public string otherreasonfornotgoingschool { get; set; }
        public int canreadwriteanylanguage { get; set; }
        public int haseverattendedschool { get; set; }
        public int whyneverattendedschool { get; set; }

        public string otherreasonnotattendedschool { get; set; }
        public int lastlevelcompleted { get; set; }
        public int lastgradecompleted { get; set; }
        public int typeofschoolattended { get; set; }

        public int levelattended { get; set; }
        public int gradeattended { get; set; }
        public string createdby { get; set; }
        public int apptypeid { get; set; }

        //For view purpose
        public string membername { get; set; }
        public string haseverattendedschoolv { get; set; }
        public string whyneverattendedschoolv { get; set; }
        public string typeofschoolattendedv { get; set; }
        public string levelattendedv { get; set; }
        public string gradeattendedv { get; set; }
        public string iscurrentlyattendingschoolv { get; set; }
        public string whystoppedgoingschoolv { get; set; }
        public string lastlevelcompletedv {get;set;}
        public string lastgradecompletedv { get; set; }
        public string readwriteanylanguagev { get; set; }
        public string hhno { get; set; }
        public string hhheadname { get; set; }

        //Spot Checker
        public int hhid_spt { get; set; }
        public string membername_spt { get; set; }
        public string haseverattendedschoolv_spt { get; set; }
        public string whyneverattendedschoolv_spt { get; set; }
        public string typeofschoolattendedv_spt { get; set; }
        public string levelattendedv_spt { get; set; }
        public string gradeattendedv_spt { get; set; }
        public string iscurrentlyattendingschoolv_spt { get; set; }
        public string whystoppedgoingschoolv_spt { get; set; }
        public string lastlevelcompletedv_spt { get; set; }
        public string lastgradecompletedv_spt { get; set; }
        public string readwriteanylanguagev_spt { get; set; }
        public string hhno_spt { get; set; }
        public string hhheadname_spt { get; set; }
        public int age_spt { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        public int haslastlevelcompleted { get; set; }
        
        //end for view
    }
    public class EducationInfoStatusDto
    {
        public int educationinfoid { get; set; }
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
