using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.WallCategoryMasters.Queries.GetWallCategoryMaster
{
   public class WallCategoryMasterDto : IMapFrom<WallCategory>
    {
        public WallCategoryMasterDto()
        {
        }
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public bool deletedflag { get; set; }
    }
}
