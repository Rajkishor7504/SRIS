using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignSurvey.Queries
{
   public class AssignSurveyVM
    {
        public AssignSurveyVM()
        {
            Lists = new List<AssignSurveyDto>();
        }
        public int assignsupid { get; set; }
        public int assignmentid { get; set; }
        public int userid { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
        public int assignenumid { get; set; }
        public IList<AssignSurveyDto> Lists { get; set; }
        public string actiontype { get; set; }
        public int assigndeviceid { get; set; }
        public int deviceid { get; set; }
    }
}
