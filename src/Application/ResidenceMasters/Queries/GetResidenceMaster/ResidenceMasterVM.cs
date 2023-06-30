using SRIS.Application.ResidenceMasters.Commands.CreateResidenceMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.ResidenceMasters.Queries.GetResidenceMaster
{
    public class ResidenceMasterVM
    {
        public IList<ResidenceMasterDto> Lists { get; set; }
        public CreateResidenceMasterCommand command {get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Residence name")]
      //  [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid residence name.")]
        public string residencename { get; set; }

       
        //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
