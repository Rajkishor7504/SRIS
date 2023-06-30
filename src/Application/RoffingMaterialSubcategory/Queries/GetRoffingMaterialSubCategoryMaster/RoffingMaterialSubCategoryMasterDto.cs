using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.RoffingMaterialSubcategory.Queries.GetRoffingMaterialSubCategoryMaster
{
    public class RoffingMaterialSubCategoryMasterDto : IMapFrom<RoffingMaterialSubCategory>
    {
        public RoffingMaterialSubCategoryMasterDto()
        {

        }
        [Key]
        public int subcategoryid { get; set; }
        public string subcategoryname { get; set; }
        public int categoryid { get; set; }
        //[Column("categoryid")]
        //public int categoryid { get; set; }
        public string categoryname { get; set; }
        public bool deletedflag { get; set; }
    }
}
