using SRIS.Application.ContactTypeMaster.Commands.CreateContactTypeMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.ContactTypeMaster.Queries.GetContactType
{
   public class ContactTypeVM
    {
        public IList<ContactTypeDto> Lists { get; set; }
        public CreateContactTypeCommand command { get; set; }
        public int id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        public string Description { get; set; }
    }
}
