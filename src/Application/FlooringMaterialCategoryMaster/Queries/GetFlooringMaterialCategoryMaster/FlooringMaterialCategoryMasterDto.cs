using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.FlooringMaterialCategoryMaster.Queries.GetFlooringMaterialCategoryMaster
{
   public class FlooringMaterialCategoryMasterDto : IMapFrom<FlooringMaterialCategory>
    {
        public FlooringMaterialCategoryMasterDto()
        {
        }
        public int categoryid { get; set; }
        public string categoryname { get; set; }
    }
}
