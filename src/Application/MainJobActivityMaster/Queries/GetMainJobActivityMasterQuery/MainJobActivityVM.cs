using SRIS.Application.MainJobActivityMaster.Commands.CreateMainJobActivityMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.MainJobActivityMaster.Queries.GetMainJobActivityMasterQuery
{
    public class MainJobActivityVM
    {
        public IList<MainJobActivityDto> Lists { get; set; }
        public CreateMainJobActivityCommand command { get; set; }
        public int activityid { get; set; }

        //[DataMember]
        //[Required]
        //[Display(Name = "Activity Name")]
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter Activity Name.")]
        public string activityname { get; set; }
        public string description { get; set; }
    }
}
