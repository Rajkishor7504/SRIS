using SRIS.Application.PurposeMaster.Commands.CreatePurposeMasterList;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PurposeMaster.Queries.GetPurposeMaster
{
    public class PurposeMasterVM
    {
        public IList<PurposeMasterDto> Lists { get; set; }
        public CreatePurposeMasterCommand Command { get; set; }
        public int purposeid { get; set; }
        public string purposename { get; set; }
        public string description { get; set; }
    }
}
