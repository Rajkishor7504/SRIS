using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.WallSubCategoryMasters.Queries.GetWallSubCategoryMaster
{
    public class WallSubCategoryMasterVM
    {
        public IList<WallSubCategoryMasterDto> Lists { get; set; }

        public WallSubCategoryMasterDto WallSubCategoryMasterDto { get; set; }

        public int subcategoryid { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Wall Material Name")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please Enter Valid Wall Material Name.")]
        public string subcategoryname { get; set; }

        [Required]
        [Display(Name = "WallCategory")]
        public int categoryid { get; set; }       
        //public int id { get; set; }
        public string categoryname { get; set; }
    }
}
