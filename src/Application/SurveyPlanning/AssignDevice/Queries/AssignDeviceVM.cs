using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SurveyPlanning.AssignDevice.Queries
{
   public class AssignDeviceVM
    {
        public AssignDeviceVM()
        {
            Lists = new List<AssignDeviceDto>();
        }
        public IList<AssignDeviceDto> Lists { get; set; }
        public int planid { get; set; }
        public int regionid { get; set; }
        public int clusterno { get; set; }
        public int deviceassignid { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
    }
}
