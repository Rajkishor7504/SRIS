using SRIS.Application.LightingSourceMasters.Commands.CreateLightingsourceMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.LightingSourceMasters.Queries.GetlightingsourceMaster
{
   public class LightingSourceMasterVM
    {
        public IList<LightingSourceMasterDto> Lists { get; set; }
        public CreateLightingsourceMasterCommand command { get; set; }
        public int sourceid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Main Lighting Source Name")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Main Lighting Source Name")]
        public string sourcename { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
