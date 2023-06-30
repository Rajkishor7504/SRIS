using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanningMobile.GetSurveyPlan.GetQuery
{
   public class SurveyPlanVM:CommonMobileApiStatus
    {
        public List<SurveyPlanDto> serveyPlan { get; set; }
    }
    public class SurveyPlanDto
    {
        public int serveyId { get; set; }
        public string surveyName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string extendedDate { get; set; }
        public string description { get; set; }
        public int regionId { get; set; }
        public string regionName { get; set; }
        public List<DistrictDto> district { get; set; }
    }
    public class DistrictDto
    {
        public int id { get; set; }
        public int regionId { get; set; }
        public string name { get; set; }
    }
    }
