using SRIS.Application.AidTypeMasters.Commands.CreateAidTypeMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.AidTypeMasters.Queries.GetAidTypeMaster
{
    public class AidTypeMasterVM
    {
        public IList<AidTypeMasterDto> Lists { get; set; }
        public CreateAidTypeMasterCommand command { get; set; }
        public int aidid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Aid Type Name")]
      //  [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid AidType Name")]
        public string aidname { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
