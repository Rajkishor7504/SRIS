using SRIS.Application.ToiletTypeMasters.Commands.CreateToiletTypeMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.ToiletTypeMasters.Queries.GetToiletTypeMaster
{
   public class ToiletTypeMasterVM
    {
        public IList<ToiletTypeMasterDto> Lists { get; set; }
        public CreateToiletTypeMasterCommand Command { get; set; }
        public int typeid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Toilet Type Name")]

      //  [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter Toilet Type Name.")]
        public string typename { get; set; }


        //[DataMember]
        [Display(Name = "Description")]
      //  [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
