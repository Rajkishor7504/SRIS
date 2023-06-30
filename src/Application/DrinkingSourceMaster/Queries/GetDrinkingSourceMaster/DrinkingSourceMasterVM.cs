using SRIS.Application.DrinkingSourceMaster.Commands.CreateDrinkingSourceMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.DrinkingSourceMaster.Queries.GetDrinkingSourceMaster
{
   public class DrinkingSourceMasterVM
    {
        public IList<DrinkingSourceMasterDto> Lists { get; set; }
        public CreateDrinkingSourceMasterCommand Command { get; set; }
        public int sourceid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Main Drinking Source Name")]

        //[RegularExpression(@"[A-Za-z0-9 ][^<>%!#$%^&]*", ErrorMessage = "Please enter valid Main Drinking Source Name.")]
        public string sourcename { get; set; }


        //[DataMember]
       // [Display(Name = "Description")]
        [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
