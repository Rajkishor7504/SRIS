using SRIS.Application.AidFreequencyMasters.Commands.CreateAidFreequencyMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.AidFreequencyMasters.Queries.GeteAidFreequencyMaster
{
   public  class AidFreequencyMasterVM
    {
        public IList<AidFreequencyMasterDto> Lists { get; set; }
        public CreateAidFreequencyMasterCommand Command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name="Name")]

       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Name.")]
        public string name { get; set; }


        //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}

