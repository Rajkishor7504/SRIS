using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.QASurvey.Query
{
   public class SurveyApproveStatusDto
    {
       
            public string action { get; set; }
            public string remarks { get; set; }
            public int moduleid { get; set; }
            public int hhid { get; set; }
            public int createdby { get; set; }
            public int approvestatus { get; set; }
       
    }
    public class AllHouseholdStatusDto
    {
        public string action { get; set; }
        public string remarks { get; set; }
        public int moduleid { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int verifystatus { get; set; }
      
    }

    public class OverallVerifiedStatusDto
    {
        public string action { get; set; }       
        public int hhid { get; set; }
        public int createdby { get; set; }
       

    }
    public class OverallStatusDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }


    }
}
