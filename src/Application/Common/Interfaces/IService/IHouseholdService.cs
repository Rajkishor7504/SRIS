using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
using SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery;
using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
using SRIS.Application.Household.DemographicMember.Queries;
using SRIS.Application.Household.DemographicMember.Queries.GetDemographicMember;
using SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery;
using SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo;
using SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery;
using SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo;
using SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery;
using SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery;
using SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery;
using SRIS.Application.Household.QASurvey.Query;
using SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IHouseholdService
    {
        Task<int> AddRegisterHousehold(RegisterHouseholdDto objRegisterhhdto);
        Task<List<RegisterHouseholdDto>> GetRegisterHousehold(GetRegisterHouseholdQuery obj);
        Task<List<RegisterHouseholdDto>> GetRegisterHouseholdList(GetHouseholdQueryFilter obj);
        Task<List<RegisterHouseholdDto>> GetRegisterHouseholdStatus(GetRegisterHouseholdStatusQuery obj);
        Task<int> UpdateStatusOfHousehold(AllHouseholdStatusDto objRegisterhhdto);
        Task<int> verifyHHcomparision(AllHouseholdStatusDto objRegisterhhdto);
        Task<int> UpdateApproveStatusOfHousehold(SurveyApproveStatusDto objRegisterhhdto);

        Task<int> DeleteRegisterHousehold(int hhid,int createdby);

        Task<int> AddDemographicMember(DemographicMemberDto objDemographicdto);
        Task<List<DemographicMemberDto>> GetDemographicMember(GetDemographicMemberQuery obj);
        Task<List<DemographicMemberDto>> GetHouseholdPopup(GetDemographicMemberQuery obj);

        Task<int> DeleteDemographicMember(int memberid, int hhid, int createdby, string action);

        Task<int> AddEducationInfo(EducationInfoDto objEducationDto);
        Task<List<EducationInfoDto>> GetEducationInfo(GetEducationInfoQuery obj);

        Task<int> DeleteEducationInfo(int educationinfoid,string action,int createdby,int apptypeid);

        Task<int> AddHealthInfo(HealthInfoDto objHealthDto);
        Task<List<HealthInfoDto>> GetHealthInfo(GetHealthInfoQuery obj);

        Task<int> DeleteHealthInfo(int healthinfoid, int createdby, int apptypeid,string action);

        Task<int> AddEmploymentInfo(EmploymentInfoDto objEmpInfoDto);
        Task<List<EmploymentInfoDto>> GetEmploymentInfo(GetEmploymentInfoQuery obj);

        Task<int> DeleteEmploymentInfo(int employmentinfoid, int createdby, int apptypeid);

        Task<int> AddHousingInfo(HousingInfoDto objEmpInfoDto);
        Task<List<HousingInfoDto>> GetHousingInfo(GetHousingInfoQuery obj);

        Task<int> DeleteHousingInfo(int housinginfoid, int createdby, int apptypeid);

        Task<int> AddDistanceInfo(DistanceInfoDto objDistanceInfoDto);
        Task<List<HouseholdDistance>> GetDistanceInfo(GetDistanceInfoQuery obj);

        Task<int> DeleteDistanceInfo(int hhid, int createdby, int apptypeid);

        Task<int> AddAssetInfo(AssetInfoDto objAssetInfoDto);
        Task<List<AssetInfoDetail>> GetAssetInfo(GetAssetInfoQuery obj);

        Task<int> DeleteAssetInfo(int assetid, int createdby, int apptypeid);

        Task<int> AddIncomeSource(IncomeSourceDto objIncomeSourceDto);
        Task<List<IncomeSourceDto>> GetIncomeSource(GetIncomeSourceQuery obj);

        Task<int> DeleteIncomeSource(int incomesourceid, int createdby, int hhid);

        Task<int> AddCopingInfo(CopingInfoDto objCopingInfoDto);
        Task<List<LivelihoodCoping>> GetLivelyhoodCopingInfo(GetCopingInfoQuery obj);

        Task<List<FoodCoping>> GetFoodCopingInfo(GetCopingInfoQuery obj);

        Task<int> DeleteCopingInfo(int copingid, int createdby, int hhid);

        Task<int> AddImpactOfShocks(ImpactDto objImpactDto);
        Task<List<ImpactDto>> GetImpactOfShocks(GetImpactQuery obj);

        

        Task<int> DeleteImpactOfShocks(int impactid, int hhid, int createdby);

        Task<int> AddAgricultureInfo(AgricultureinfoDto objImpactDto);
        Task<List<AgricultureinfoDto>> GetAgricultureInfo(GetAgricultureInfoQuery obj);



        Task<int> DeleteAgricultureInfo(int agricultureid, int hhid, int createdby,int apptypeid);
        Task<string> GetAllParentLocation(int locationid);
        Task<List<RegisterHouseholdDto>> GetRegisterHouseholdForPMT(GetRegisterHouseholdQuery obj);
        Task<List<RegisterHouseholdDto>> GetRegisterHHForComparision(GetRegisterHouseholdQuery obj);
        Task<int> ApproveRejectRegisterHousehold(int hhid, int createdby,string ActionType,string Remark,int Gregid);
        Task<int> ApproveRejectDemographicMember(int memberid, int hhid, int createdby, string action, string Remark, int Gregid);
        Task<int> ApproveRejectHousingInfo(int hhid, int createdby,string Action,string Remark, int Gregid);
        Task<int> ApproveRejectImpactOfShocks(int impactid, int hhid, int createdby,string Action, string Remark, int Gregid);

        #region---------qa survey status ---------
        Task<List<HouseholdStatusDto>> GetAllHouseholdstatus(GetAllHouseholdStatusQuery obj);
        #endregion




        #region------------------Rajalaxmi------------------------------------
        Task<int> UpdateEducationStatusInfo(EducationInfoStatusDto objEducationDto);
        Task<int> UpdateHealthStatusInfo(HealthStatusInfoDto objHealthDto);
        Task<int> UpdateEmploymentStatusInfo(EmploymentStatusInfoDto objEmpInfoDto);
        Task<int> UpdateDistanceStatusInfo(DistanceStatusInfoDto objDistanceInfoDto);
        Task<int> UpdateAssetStatusInfo(AssetStatusInfoDto objAssetInfoDto);
        Task<int> UpdateIncomeSourceStatusInfo(IncomeStatusSourceDto objIncomeSourceDto);
        Task<int> UpdateCopingStatusInfo(CopingStatusInfoDto objCopingInfoDto);
        Task<int> UpdateAgricultureStatusInfo(AgricultureStatusinfoDto objImpactDto);
        #endregion

    }
}
