using SRIS.Application.GradeLevelMasters.Commands.CreateGradeLevelMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.GradeLevelMasters.Queries.GetGradeLevelMaster
{
    public class GradeMasterVM
    {
        public IList<GradeMasterDto> Lists { get; set; }
        public CreateGradeCommand command { get; set; }
        public int gradeid { get; set; }

        [DataMember]
        [Required]
        
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter valid Grade name.")]
        public string gradename { get; set; }
        public string description { get; set; }
    }
}
