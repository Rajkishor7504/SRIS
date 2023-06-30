using SRIS.Application.WorkingStatusMaster.Commands.CreateWorkingStatusMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.WorkingStatusMaster.Queries.GetWorkingStatusMaster
{
    public class WorkingStatusVM
    {
        public IList<WorkingStatusDto> Lists { get; set; }
        public CreateWorkingStatusCommand command { get; set; }
        public int statusid { get; set; }
        public string statusname { get; set; }
        public string description { get; set; }
    }
}
