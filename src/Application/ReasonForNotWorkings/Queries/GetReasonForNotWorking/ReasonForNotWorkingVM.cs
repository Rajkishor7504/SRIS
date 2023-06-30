using SRIS.Application.ReasonForNotWorkings.Commands.CreateReasonForNotWorking;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ReasonForNotWorkings.Queries.GetReasonForNotWorking
{
    public class ReasonForNotWorkingVM
    {
        public IList<ReasonForNotWorkingDto> Lists { get; set; }
        public CreateReasonForNotWorkingCommand command { get; set; }
        public int reasonid { get; set; }
        public string reasonname { get; set; }
        public string description { get; set; }
    }
}
