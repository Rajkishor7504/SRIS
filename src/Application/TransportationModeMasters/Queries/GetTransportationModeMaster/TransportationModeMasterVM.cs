using SRIS.Application.TransportationModeMasters.Commands.CreateTransportationModeList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.TransportationModeMasters.Queries.GetTransportationModeMaster
{
   public class TransportationModeMasterVM
    {
        public IList<TransportationModeMasterDto> Lists { get; set; }
        public CreateTransportationModeMasterCommand Command { get; set; }
        public int modeid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Transportation Mode Name")]
        //var dataFull = data.replace(/[^0 - 9a - zA - Z\- \/ _ ?: ()[]{};+|~`=.,\s]/g, '');
        [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Transportation Mode Name.")]
        public string modename { get; set; }


        //[DataMember]
        [Display(Name = "description")]
        [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid description")]
        public string description { get; set; }
    }
}
