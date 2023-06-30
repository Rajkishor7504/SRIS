using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DrinkingSourceMaster.Queries.GetDrinkingSourceMaster
{
    public class DrinkingSourceMasterDto : IMapFrom<DrinkingSource>
    {
        public DrinkingSourceMasterDto()
        {
        }
        public string description { get; set; }
        public string sourcename { get; set; }
        public int sourceid { get; set; }
        public bool deletedflag { get; set; }
    }
}
