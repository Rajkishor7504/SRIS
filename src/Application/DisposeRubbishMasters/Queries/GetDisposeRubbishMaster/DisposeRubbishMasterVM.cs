using SRIS.Application.DisposeRubbishMasters.Commands.CreateDisposeRubbishMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.DisposeRubbishMasters.Queries.GetDisposeRubbishMaster
{
   public class DisposeRubbishMasterVM
    {
        public IList<DisposeRubbishMasterDto> Lists { get; set; }
        public CreateDisposeRubbishMasterCommand Command { get; set; }
        public int disposeid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Dispose Rubbish Name")]

        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Dispose Rubbish Name.")]
        public string disposename { get; set; }


        //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
