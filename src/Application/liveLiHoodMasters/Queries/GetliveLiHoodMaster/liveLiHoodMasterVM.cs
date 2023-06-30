using SRIS.Application.liveLiHoodMasters.Commands.CreateliveLiHoodMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.liveLiHoodMasters.Queries.GetliveLiHoodMaster
{
   public  class liveLiHoodMasterVM
    {
        public IList<liveLiHoodMasterDto> Lists { get; set; }
        public CreateliveLiHoodMasterCommand command { get; set; }
        public int livelihoodid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Livelihood Name")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid LiveLiHood Name")]
        public string livelihoodname { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
