using SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster;
using SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster
{
   public class IncomeSourceApiVM
    {
        public List<CommonIncomeSourceDto> mainIncomeSource { get; set; }
        public List<CommonIncomeSourceDto> secondIncomeSource { get; set; }
        public List<CommonIncomeSourceDto> aidType { get; set; }
        public List<CommonIncomeSourceDto> aidFrequency { get; set; }
        public List<CommonIncomeSourceDto> orgType { get; set; }
    }
    public class IncomeSourceResponse : CommonMobileApiStatus
    {
        public IncomeSourceApiVM incomeSourcesMaster { get; set; }
    }
    public class IncomeSourceWebResponse : CommonMobileApiStatus
    {
        public IncomeSourceApiVM Master { get; set; }
        public IncomeSourceDto info { get; set; }
        public int hhid { get; set; }
        public int lockstatus { get; set; }
        public List<commonlistmodel> orglist { get; set; }
        public List<commonlistmodel> aidlist { get; set; }
        public string hhno { get; set; }
        public string encrypthhid { get; set; }
        public string householdheadname { get; set; }
    }
    public class commonlistmodel
    {
        public int id { get; set; }
    }
}
