using SRIS.Application.shocksSeverityMasters.Commands.CreateshocksSeverityMasterList;
using System;//
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.shocksSeverityMasters.Queries.GetshocksSeverityMaster
{
   public class shocksSeverityMasterVM
    {
        public IList<shocksSeverityMasterDto> Lists { get; set; }
        public CreateshocksSeverityMasterCommand command { get; set; }
        public int severityid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Shock Severity Name")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid ShocksSeverity Name")]
        public string severityname { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
      //   [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
