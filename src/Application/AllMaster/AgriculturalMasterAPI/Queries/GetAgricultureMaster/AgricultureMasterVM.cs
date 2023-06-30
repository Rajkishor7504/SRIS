using SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster;
using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.AgriculturalMasterAPI.Queries.GetAgricultureMaster
{
   public class AgricultureMasterVM
    {
        public List<CommonAgricultureMasterDto> livestock { get; set; }
        public List<CommonAgricultureMasterDto> crop { get; set; }
        public List<CommonAgricultureMasterDto> breeding { get; set; }
        public List<CommonAgricultureMasterDto> ecology { get; set; }
    }
    public class AgricultureMasterResponse : CommonMobileApiStatus
    {
        public AgricultureMasterVM agriculturalMaster { get; set; }
    }
    public class AgricultureMasterWebResponse 
    {
        public AgricultureMasterResponse Master { get; set; }
        public AgricultureinfoDto Lists { get; set; }
        public int hhid { get; set; }
        public string hhno { get; set; }
        public string householdheadname { get; set; }
        public string encrypthhid { get; set; }
        public int lockstatus { get; set; }


        public List<breedingmodel> breeding { get; set; }
    }
    public class breedingmodel
    {
        public int livestockid { get; set; }
        public string name { get; set; }
        public IList<commonlistmodel> breedingid { get; set; }
       
    }
}
