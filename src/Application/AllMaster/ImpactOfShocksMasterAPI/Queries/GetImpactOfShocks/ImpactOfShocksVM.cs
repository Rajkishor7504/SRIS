using SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster;
using SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.ImpactOfShocksMasterAPI.Queries.GetImpactOfShocks
{
   public class ImpactOfShocksVM
    {
        public List<CommonImpactOfShocksDto> livelihoodType { get; set; }
        public List<CommonImpactOfShocksDto> affectedShocksType { get; set; }
        public List<CommonImpactOfShocksDto> shocksSeverityType { get; set; }      
      
    }
    public class ImpactOfShocksResponse : CommonMobileApiStatus
    {
        public ImpactOfShocksVM ImpactOfShocksMaster { get; set; }
    }
    public class ImpactOfShocksWebResponse
    {
        public ImpactOfShocksVM Master { get; set; }
        public ImpactDto Impact { get; set; }
        public int hhid { get; set; }
        public int lockstatus { get; set; }
        public string encrypthhid { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
        public List<commonlistmodel> livestocks { get; set; }
}
}
