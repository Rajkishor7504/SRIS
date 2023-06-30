using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.CookingFuelMaster.Queries.GetCookingFuelMaster
{
   public class CookingFuelMasterDto : IMapFrom<CookingFuel>
    {
        public CookingFuelMasterDto()
        {
        }
        public string fuelname { get; set; }
        public string description { get; set; }
        public int fuelid { get; set; }
        public bool deletedflag { get; set; }
    }
}