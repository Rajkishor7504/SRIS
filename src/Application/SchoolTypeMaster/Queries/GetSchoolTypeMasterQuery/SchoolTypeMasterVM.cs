using SRIS.Application.SchoolTypeMaster.Commands.CreateSchoolTypeMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.SchoolTypeMaster.Queries.GetSchoolTypeMasterQuery
{
    public class SchoolTypeMasterVM
    {
        public IList<SchoolTypeMasterDto> Lists { get; set; }
        public int schooltypeid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "School Type")]
        public string typeofschool { get; set; }
        public string description { get; set; }
    }
}
