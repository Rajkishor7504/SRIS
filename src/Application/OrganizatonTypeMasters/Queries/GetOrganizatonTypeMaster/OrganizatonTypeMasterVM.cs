using SRIS.Application.OrganizatonTypeMasters.Commands.CreateOrganizatonTypeMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.OrganizatonTypeMasters.Queries.GetOrganizatonTypeMaster
{
   public class OrganizatonTypeMasterVM
    {
        public IList<OrganizatonTypeMasterDto> Lists { get; set; }
        public CreateOrganizatonTypeMasterCommand command { get; set; }
        public int organizationtypeid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Organizaton Type Name")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid OrganizatonType Name")]
        public string organizationtypename { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
