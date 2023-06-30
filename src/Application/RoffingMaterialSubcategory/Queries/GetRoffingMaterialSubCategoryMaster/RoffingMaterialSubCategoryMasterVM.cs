using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.RoffingMaterialSubcategory.Queries.GetRoffingMaterialSubCategoryMaster
{
    public class RoffingMaterialSubCategoryMasterVM
    {
        public IList<RoffingMaterialSubCategoryMasterDto> Lists { get; set; }

        public RoffingMaterialSubCategoryMasterDto RoffingMaterialSubCategoryMasterDto { get; set; }

        public int subcategoryid { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Roof Material Name")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please Enter Valid Roof Material Name.")]
        public string subcategoryname { get; set; }

        [Required]
        [Display(Name = "RoofCategory")]
        public int categoryid { get; set; }
        //public int id { get; set; }
        public string categoryname { get; set; }
    }
}
