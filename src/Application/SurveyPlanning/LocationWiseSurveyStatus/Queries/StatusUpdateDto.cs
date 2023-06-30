using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Queries
{
   public class StatusUpdateDto
    {
        public string action { get; set; }
        public int planid { get; set; }
        public string surveyname { get; set; }
        public string region { get; set; }
        public string dist { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public int regionid { get; set; }
        public int distid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
        public int searchid { get; set; }
        public string surveystatus { get; set; }
        public int householdtarget { get; set; }
        public int actualdata { get; set; }
        public int clustorno { get; set; }
        //public int searchid { get; set; }
    }
}
