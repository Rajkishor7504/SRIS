using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignSurvey.Queries
{
   public class AssignSurveyDto
    {
        public int assignsupid { get; set; }
        public int assignmentid { get; set; }
        public int userid { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
        public int assignenumid { get; set; }
        public string supervisorname { get; set; }
        public string surveyname { get; set; }
        public string actiontype { get; set; }
        public int assigndeviceid { get; set; }
        public int deviceid { get; set; }
        public int searchid { get; set; }
        public List<AssignSurveyDto> Lists { get; set; }

    }
}
