using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.RoffingMaterialCategoryMaster.Queries.GetRoffingMaterialCategoryMaster
{
   public class RoffingMaterialCategoryMasterDto : IMapFrom<RoffingMaterialCategory>
    {
        public RoffingMaterialCategoryMasterDto()
        {
        }
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public bool deletedflag { get; set; }
    }
}
