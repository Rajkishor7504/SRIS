using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ResortFoodCopingMasters.Queries.GetResortFoodCopingMasterItem
{
    public class ResortFoodCopingDto :IMapFrom<ResortFoodCoping>
    {
        public ResortFoodCopingDto()
    {
    }
        public int resortfoodcopingid { get; set; }
        public string resortfoodcoping { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
