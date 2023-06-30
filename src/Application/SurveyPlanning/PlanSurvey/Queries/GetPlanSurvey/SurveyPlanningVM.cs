using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.PlanSurvey.Queries.GetPlanSurvey
{
   public class SurveyPlanningVM
    {
        public SurveyPlanningVM()
        {
            Lists = new List<SurveyPlanningDto>();
        }
        public string action { get; set; }
        public DateTime surveystartdate { get; set; }
        public DateTime surveyenddate { get; set; }
        public int createdby { get; set; }
        public DateTime surveyextendeddate { get; set; }
        public string description { get; set; }
        public string surveyname { get; set; }
        public int planid { get; set; }
        public int clusterno { get; set; }
        public int regionid { get; set; }
        public int levelid { get; set; }
        public int locationid { get; set; }

        public IList<SurveyPlanningDto> Lists { get; set; }

        public string startdate { get; set; }
        public string enddate { get; set; }
        public string extendeddate { get; set; }

        //location entity

        public string dist { get; set; }
        public string Region { get; set; }
        public int planlocationid { get; set; }
       

        //status update entity
        public int statusid { get; set; }
        public string status { get; set; }
        public int deletedflag { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public string userfullname { get; set; }

    }
}
