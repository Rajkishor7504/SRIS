using SRIS.Application.DiseaseMasters.Commands.CreateDiseaseMasterItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.DiseaseMasters.Queries.GetDiseaseMasterQuery
{
   public class DiseaseMasterVM
    {
        public IList<DiseaseMasterDto> Lists { get; set; }
        public CreateDiseaseCommand command { get; set; }
        public int diseaseid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Disease Name")]
        //[RegularExpression(@"[A-Za-z0-9 ]*", ErrorMessage = "Please enter Disease Name.")]
        public string diseasename { get; set; }
        public string description { get; set; }
    }
}
