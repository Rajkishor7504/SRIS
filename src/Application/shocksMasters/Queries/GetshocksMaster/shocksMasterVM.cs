using SRIS.Application.shocksMasters.Commands.CreateshocksMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.shocksMasters.Queries.GetshocksMaster
{
   public class shocksMasterVM
    {
        public IList<shocksMasterDto> Lists { get; set; }
        public CreateshocksMasterCommand command { get; set; }
        public int shockid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Shock Name")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Shocks Name")]
        public string shockname { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
