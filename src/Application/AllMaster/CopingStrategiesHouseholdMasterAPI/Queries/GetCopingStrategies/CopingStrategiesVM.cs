using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.CopingStrategiesHouseholdMasterAPI.Queries.GetCopingStrategies
{
    public class CopingStrategiesVM
    {
        public List<CommonCopingStrategiesTypeDto> copingStrategyType { get; set; } 
        public List<CommonCopingStrategiesDto> restoringType { get; set; }
        public List<CommonfoodCopingStrategiesDto> foodrestoringType { get; set; }
    }
    public class CopingStrategiesResponse : CommonMobileApiStatus 

    {
        public CopingStrategiesVM CopingStrategiesHouseholdMaster { get; set; }  
    }
    public class CopingStrategiesWebResponse : CommonMobileApiStatus
    {
        public int hhid { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
        public CopingStrategiesVM Master { get; set; }
        public CopingInfoVM List { get; set; }
        public string encrypthhid { get; set; }
        public int lockstatus { get; set; }
    }
}
