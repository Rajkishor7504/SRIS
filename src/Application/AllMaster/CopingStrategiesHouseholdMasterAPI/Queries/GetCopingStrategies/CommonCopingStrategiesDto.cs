using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.CopingStrategiesHouseholdMasterAPI.Queries.GetCopingStrategies
{
   public class CommonCopingStrategiesDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CommonfoodCopingStrategiesDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CommonCopingStrategiesTypeDto
    {
        public int id { get; set; }
        public int copingytypeid { get; set; }
        public string name { get; set; }
    }
}
