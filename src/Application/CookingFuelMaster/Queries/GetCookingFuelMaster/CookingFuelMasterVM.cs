using SRIS.Application.CookingFuelMaster.Commands.CreateCookingFuelMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.CookingFuelMaster.Queries.GetCookingFuelMaster
{
   public class CookingFuelMasterVM
    {
        public IList<CookingFuelMasterDto> Lists { get; set; }
        public CreateCookingFuelMasterCommand Command { get; set; }
        public int fuelid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Fuel Name")]
      
        [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Fuel Name.")]
        public string fuelname { get; set; }


        //[DataMember]
        [Display(Name = "Description")]
        [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
