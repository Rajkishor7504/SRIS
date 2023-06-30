using SRIS.Application.Household.MobileApp.DemographicandIdentificationQuery;
using SRIS.Application.Household.MobileApp.EduAndHealth.Query;
using SRIS.Application.Household.MobileApp.HousingDistanceAsset.Query;
using SRIS.Application.Household.MobileApp.IncomeAgriImpactCoping.Query;
using SRIS.Application.Household.MobileApp.QARejectedhhList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
  public  interface IHouseholdServiceMobile
    {
        Task<List<HouseholdRejectedDto>> GetVerifyRejectedHousehold(HouseholdRejectedQuery obj);
        Task<IdentificationModelVM> GetIdentification(GetDemographicandIdentification obj);
        Task<IList<DemographicModelVM>> GetDemographicList(GetDemographicandIdentification obj);

        #region-------------Education and Health and Emp-----------------
        Task<IList<EducationModelVM>> GetEducationList(GetEduHealthEmpQuery obj);
        Task<IList<HealthModelVM>> GetHealthList(GetEduHealthEmpQuery obj);
        Task<IList<EmployementModelVM>> GetEmployementList(GetEduHealthEmpQuery obj);
        #endregion
        #region-------------Housing and Distance and Asset-----------------
        Task<HousingModelVM> GetHousingList(GetHousingDistanceAssetQuery obj);
        Task<IList<DistanceModelVM>> GetDistanceList(GetHousingDistanceAssetQuery obj);
        Task<IList<AssetModelVM>> GetAssetList(GetHousingDistanceAssetQuery obj);
        #endregion
        #region------Incomesource and impact and coping---------------------------
        Task<IncomeModelVM> GetIncomesourceList(GetIncomeAgriImpactCopingQuery obj);
        Task<ImpactOfShocksModelVM> GetImpactOfShocksList(GetIncomeAgriImpactCopingQuery obj);

        Task<IList<CopingStrategiesModelVM>> GetCopingLivehoodList(GetIncomeAgriImpactCopingQuery obj);
        Task<IList<CopingStrategiesModelVM>> GetCopingFoodList(GetIncomeAgriImpactCopingQuery obj);
        Task<CopingModelVM> GetCopingDetails(GetIncomeAgriImpactCopingQuery obj);

        
        Task<IList<CommonAgriModel>> GetAgricuralList(GetIncomeAgriImpactCopingQuery obj);


        #endregion
        #region------------------CheckRegisterHousehold---------------------------
        Task<int> CheckRegisterHousehold(string action, int hhid,int? memberid);
        #endregion
        #region------------------CheckRegisterHousehold---------------------------
        Task<int> CheckStatusOfHousehold(string action, int hhid, int createdby);
        #endregion
    }
}
