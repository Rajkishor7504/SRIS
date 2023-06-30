
using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.MobileApp.DemographicandIdentificationQuery;
using SRIS.Application.Household.MobileApp.EduAndHealth.Query;
using SRIS.Application.Household.MobileApp.HousingDistanceAsset.Query;
using SRIS.Application.Household.MobileApp.IncomeAgriImpactCoping.Query;
using SRIS.Application.Household.MobileApp.QARejectedhhList;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class HouseholdServiceMobile : BaseRepository, IHouseholdServiceMobile
    {
        private readonly IConnectionFactory _connectionFactory;
        public HouseholdServiceMobile(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

       

        public async Task<List<HouseholdRejectedDto>> GetVerifyRejectedHousehold(HouseholdRejectedQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_registerhouseholdM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "V");
                    param.Add("p_userId", (obj.userId == null && obj.userId == "") ? "0" : obj.userId);
                    param.Add("p_districtid", (obj.districtId == null && obj.districtId == "" )? "0" : obj.districtId);
                    param.Add("p_surveyplanid", (obj.surveyPlanId == null && obj.surveyPlanId=="") ? "0" : obj.surveyPlanId);
                    var result = await con.QueryAsync<HouseholdRejectedDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region--------------- Identification and Demographic--------------------
        public async Task<IdentificationModelVM> GetIdentification(GetDemographicandIdentification obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_registerdemographicM_e";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "R");
                    param.Add("p_householdno", (obj.householdNo == null) ? "" : obj.householdNo);
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    param.Add("p_userId", (obj.userId == null && obj.userId == "") ? "0" : obj.userId);
                    var result = await con.QueryAsync<IdentificationModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<DemographicModelVM>> GetDemographicList(GetDemographicandIdentification obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_registerdemographicM_e";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "D");                 
                    param.Add("p_householdno", (obj.householdNo == null ) ? "" : obj.householdNo);
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    param.Add("p_userId", (obj.userId == null && obj.userId == "") ? "0" : obj.userId);
                    var result = await con.QueryAsync<DemographicModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region--------------- Edu Health Emp Query--------------------

        public async Task<IList<EducationModelVM>> GetEducationList(GetEduHealthEmpQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                  
                        string Query = "usp_hhr_educationhealthempM_v";
                        con.Open();
                        DynamicParameters param = new DynamicParameters();
                        param.Add("p_action", "E");                     
                        param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);                    
                        var result = await con.QueryAsync<EducationModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                        return result.ToList();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<HealthModelVM>> GetHealthList(GetEduHealthEmpQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_educationhealthempM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "H");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<HealthModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<EmployementModelVM>> GetEmployementList(GetEduHealthEmpQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_educationhealthempM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "EM");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<EmployementModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
        #region-----------Housing and Distance and Assets--------------------------------------
        public async Task<HousingModelVM> GetHousingList(GetHousingDistanceAssetQuery obj)
        {
            try
            {
               
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_housingdistanceassetM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "H");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<HousingModelVM>(Query, param, commandType: CommandType.StoredProcedure);                    
                    return result.FirstOrDefault();  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<DistanceModelVM>> GetDistanceList(GetHousingDistanceAssetQuery obj)
        {
            try
            {

                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_housingdistanceassetM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "D");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<DistanceModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<AssetModelVM>> GetAssetList(GetHousingDistanceAssetQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_housingdistanceassetM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "A");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<AssetModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region
        public async Task<IncomeModelVM> GetIncomesourceList(GetIncomeAgriImpactCopingQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_IncomeAgriImpactCopingM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "I");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<IncomeModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImpactOfShocksModelVM> GetImpactOfShocksList(GetIncomeAgriImpactCopingQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_IncomeAgriImpactCopingM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "IM");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<ImpactOfShocksModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<CopingStrategiesModelVM>> GetCopingLivehoodList(GetIncomeAgriImpactCopingQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_IncomeAgriImpactCopingM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "CL");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<CopingStrategiesModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<CopingStrategiesModelVM>> GetCopingFoodList(GetIncomeAgriImpactCopingQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_IncomeAgriImpactCopingM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "CF");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<CopingStrategiesModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<CommonAgriModel>> GetAgricuralList(GetIncomeAgriImpactCopingQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_IncomeAgriImpactCopingM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "A");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<CommonAgriModel>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CopingModelVM> GetCopingDetails(GetIncomeAgriImpactCopingQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {

                    string Query = "usp_hhr_IncomeAgriImpactCopingM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "C");
                    param.Add("p_hhid", (obj.hhid == null && obj.hhid == "") ? "0" : obj.hhid);
                    var result = await con.QueryAsync<CopingModelVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CheckRegisterHousehold(string action, int hhid,int? memberid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_memberid", memberid);
                
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_registerhouseholdM_Check", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CheckStatusOfHousehold(string action, int hhid, int createdby)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_overallStatusM_ae", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
