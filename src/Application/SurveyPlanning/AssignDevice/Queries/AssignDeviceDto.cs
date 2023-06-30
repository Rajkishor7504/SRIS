using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignDevice.Queries
{
   public class AssignDeviceDto
    {
        public string action { get; set; }
        public int planid { get; set; }
        public int regionid { get; set; }
        public string username { get; set; }
        public int id { get; set; }
        public string device { get; set; }
        public int clusterno { get; set; }
        public int usertypeid { get; set; }
        public int userid { get; set; }
        public int deviceid { get; set; }
        public int createdby { get; set; }
        public int deviceassignid { get; set; }
        public string surveyname { get; set; }
        public string levelname { get; set; }
        public string usertype { get; set; }
        public int searchid { get; set; }
        public List<AssignDeviceDto> Lists { get; set; }

    }
}
