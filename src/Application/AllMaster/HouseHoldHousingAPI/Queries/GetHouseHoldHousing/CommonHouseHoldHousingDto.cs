using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.HouseHoldHousingAPI.Queries.GetHouseHoldHousing
{
   public class CommonHouseHoldHousingDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class CommonHouseHoldHousingSubDto
    {
        public int subcategoryid { get; set; }
        public int categoryid { get; set; }
        public string name { get; set; }
    }
}
