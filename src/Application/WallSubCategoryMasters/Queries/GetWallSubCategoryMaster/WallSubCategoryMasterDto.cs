using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRIS.Application.WallSubCategoryMasters.Queries.GetWallSubCategoryMaster
{
    public class WallSubCategoryMasterDto : IMapFrom<WallSubCategory>
    {
        public WallSubCategoryMasterDto()
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
