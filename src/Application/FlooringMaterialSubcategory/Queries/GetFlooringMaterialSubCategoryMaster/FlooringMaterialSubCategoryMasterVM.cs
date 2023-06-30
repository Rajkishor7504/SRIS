using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.FlooringMaterialSubcategory.Queries.GetFlooringMaterialSubCategoryMaster
{
   public class FlooringMaterialSubCategoryMasterVM
    {
        public IList<FlooringMaterialSubCategoryMasterDto> Lists { get; set; }

        public FlooringMaterialSubCategoryMasterDto FlooringMaterialSubCategoryMasterDto { get; set; }

        public int subcategoryid { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Floor Material Name")]
        //[RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please Enter Valid Floor Material Name.")]
        public string subcategoryname { get; set; }

        [Required]
        [Display(Name = "FloorfCategory")]
        public int categoryid { get; set; }
        //public int id { get; set; }
        public string categoryname { get; set; }
    }
}
