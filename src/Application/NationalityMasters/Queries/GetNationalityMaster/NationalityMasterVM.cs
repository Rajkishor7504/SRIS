using SRIS.Application.NationalityMasters.Commands.CreateNationalityMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.NationalityMasters.Queries.GetNationalityMaster
{
    public class NationalityMasterVM
    {
        public IList<NationalityMasterDto> Lists { get; set; }
        public CreateNationalityMasterCommand command { get; set; }
        public int nationalityid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Nationality")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Nationality")]
        public string nationality { get; set; }
      
       //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
