using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Queries
{
   public class StatusUpdateVM
    {
        public IList<StatusUpdateDto> Lists { get; set; }
        public string action { get; set; }
        public int planid { get; set; }
        public int regionid { get; set; }
        public int distid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
        public int householdtarget { get; set; }
        public int actualdata { get; set; }
        public int searchid { get; set; }
        public int clustorno { get; set; }

    }
}
