using SRIS.Application.CropMasters.Commands.CreateCropMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.CropMasters.Queries.GetCropMaster
{
    public class CropMasterVM
    {
        public IList<CropMasterDto> Lists { get; set; }
        public CreateCropMasterCommand command { get; set; }
        public int cropid { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Crop Name")]
        // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Income Source Name")]
        public string cropname { get; set; }

        //[DataMember]
        [Display(Name = "Description")]
        // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
