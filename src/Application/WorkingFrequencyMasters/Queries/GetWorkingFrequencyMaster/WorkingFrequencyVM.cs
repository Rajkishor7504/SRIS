using SRIS.Application.WorkingFrequencyMasters.Commands.CreateWorkingFrequencyMater;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.WorkingFrequencyMasters.Queries.GetWorkingFrequencyMaster
{
    public class WorkingFrequencyVM
    {
        public IList<WorkingFrequencyDto> Lists { get; set; }
        public CreateWorkingFrequencyCommand command { get; set; }
        public int id { get; set; }

        //[DataMember]
        //[Required]
        //[Display(Name = "Activity Name")]
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter Activity Name.")]
        public string name { get; set; }
        public string description { get; set; }
    }
}
