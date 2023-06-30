using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
using SRIS.Application.Household.AssetInfo.Queries.GetAssetInfoQuery;
using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
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
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRIS.Persistence.Service
{
    public class HouseholdService : BaseRepository, IHouseholdService
    {
        private readonly IConnectionFactory _connectionFactory;
        public HouseholdService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #region "Register Household"
        public async Task<int> AddRegisterHousehold(RegisterHouseholdDto objRegisterhhdto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objRegisterhhdto.action);
                objParam.Add("p_hhid", objRegisterhhdto.hhid);
                objParam.Add("p_clusterno", objRegisterhhdto.clusterno);
                objParam.Add("p_teamId", objRegisterhhdto.teamId);
                objParam.Add("p_lgaid", objRegisterhhdto.lgaid);
                objParam.Add("p_districtid", objRegisterhhdto.districtid);
                objParam.Add("p_wardid", objRegisterhhdto.wardid);
                objParam.Add("p_settlementid", objRegisterhhdto.settlementid);
                objParam.Add("p_dateofinterview", Convert.ToDateTime(objRegisterhhdto.dateofinterview).ToString("yyyy-MM-dd"));
                objParam.Add("p_interviewer", objRegisterhhdto.interviewer);
                objParam.Add("p_supervisor", objRegisterhhdto.supervisor);
                objParam.Add("p_areaid", objRegisterhhdto.areaid);
                objParam.Add("p_latitude", objRegisterhhdto.latitude);
                objParam.Add("p_longitude", objRegisterhhdto.longitude);
                objParam.Add("p_hhno", objRegisterhhdto.hhno);
                objParam.Add("p_eano", objRegisterhhdto.eano);
                objParam.Add("p_compoundno", objRegisterhhdto.compoundno);
                objParam.Add("p_isagreed", objRegisterhhdto.isaggreed);
                objParam.Add("p_respondantname", objRegisterhhdto.respondantname);
                objParam.Add("p_telephoneno", objRegisterhhdto.telephoneno.ToString());
                objParam.Add("p_address", objRegisterhhdto.address);
                objParam.Add("p_householdheadname", objRegisterhhdto.householdheadname);
                objParam.Add("p_resultofhhinterview", objRegisterhhdto.resultofhhinterview);
                objParam.Add("p_observation", objRegisterhhdto.observation);
                objParam.Add("p_createdby", objRegisterhhdto.createdby);
                objParam.Add("p_spotcheckerstatus", objRegisterhhdto.spotchecker);
                objParam.Add("p_hhcode", objRegisterhhdto.hhcode);
                objParam.Add("p_surveyplanid", objRegisterhhdto.surveyplanid);              
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_registerhousehold_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> verifyHHcomparision(AllHouseholdStatusDto objRegisterhhdto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objRegisterhhdto.action);
                objParam.Add("p_hhid", objRegisterhhdto.hhid);
                objParam.Add("p_moduleid", objRegisterhhdto.moduleid);
                objParam.Add("p_remarks", objRegisterhhdto.remarks);
                objParam.Add("p_createdby", objRegisterhhdto.createdby);
                objParam.Add("p_verifystatus", objRegisterhhdto.verifystatus);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateStatusOfHousehold(AllHouseholdStatusDto objRegisterhhdto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objRegisterhhdto.action);
                objParam.Add("p_hhid", objRegisterhhdto.hhid);
                objParam.Add("p_moduleid", objRegisterhhdto.moduleid);
                objParam.Add("p_remarks", objRegisterhhdto.remarks);
                objParam.Add("p_createdby", objRegisterhhdto.createdby);
                objParam.Add("p_verifystatus", objRegisterhhdto.verifystatus);              
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                //await Connection.ExecuteAsync("usp_hhr_update_approval", objParam, null, null, CommandType.StoredProcedure);
                await Connection.ExecuteAsync("usp_hhr_status_ae", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<RegisterHouseholdDto>> GetRegisterHousehold(GetRegisterHouseholdQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_registerhousehold_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_householdno", obj.householdno == null ? "" : obj.householdno);
                    param.Add("p_eano", obj.eano == null ? "" : obj.eano);
                    param.Add("p_hhheadname", obj.hhheadname == null ? "" : obj.hhheadname);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_locationid", obj.locationid);
                    //param.Add("p_surveyid", obj.surveyId);
                    param.Add("p_pageno", obj.pageno);
                    param.Add("p_pagesize", obj.pagesize);                 
                    var result = await con.QueryAsync<RegisterHouseholdDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RegisterHouseholdDto>> GetRegisterHouseholdList(GetHouseholdQueryFilter obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_registerhousehold_filter";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_householdno", obj.householdno == null ? "" : obj.householdno);
                    param.Add("p_eano", obj.eano == null ? "" : obj.eano);
                    param.Add("p_hhheadname", obj.hhheadname == null ? "" : obj.hhheadname);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_locationid", obj.locationid);                 
                    param.Add("p_pageno", obj.pageno);
                    param.Add("p_pagesize", obj.pagesize);
                    param.Add("p_userid", obj.userid);

                    var result = await con.QueryAsync<RegisterHouseholdDto>(Query, param, commandType: CommandType.StoredProcedure);
                    
                    return result.ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<RegisterHouseholdDto>> GetRegisterHouseholdStatus(GetRegisterHouseholdStatusQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_householdStatus_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_householdno", obj.householdno == null ? "" : obj.householdno);
                    param.Add("p_eano", obj.eano == null ? "" : obj.eano);
                    param.Add("p_hhheadname", obj.hhheadname == null ? "" : obj.hhheadname);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_locationid", obj.locationid);
                    param.Add("p_pageno", obj.pageno);
                    param.Add("p_pagesize", obj.pagesize);
                    param.Add("p_allverifiedstatus", obj.allverifiedstatus);
                    param.Add("p_allapprovedstatus", obj.allapprovedstatus);
                    param.Add("p_fromdate", obj.fromdate != null ? obj.fromdate : "");
                    param.Add("p_todate", obj.todate != null ? obj.todate : "");
                    var result = await con.QueryAsync<RegisterHouseholdDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteRegisterHousehold(int hhid, int createdby)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_clusterno", 0);
                objParam.Add("p_teamId", 0);
                objParam.Add("p_lgaid", 0);
                objParam.Add("p_districtid", 0);
                objParam.Add("p_wardid", 0);
                objParam.Add("p_settlementid", 0);
                objParam.Add("p_dateofinterview", "");
                objParam.Add("p_interviewer", "");
                objParam.Add("p_supervisor", "");
                objParam.Add("p_areaid", 0);
                objParam.Add("p_latitude", "");
                objParam.Add("p_longitude", "");
                objParam.Add("p_hhno", "");
                objParam.Add("p_eano", "");
                objParam.Add("p_compoundno", "");
                objParam.Add("p_isagreed", 0);
                objParam.Add("p_respondantname", "");
                objParam.Add("p_telephoneno", "");
                objParam.Add("p_address", "");
                objParam.Add("p_householdheadname", "");
                objParam.Add("p_resultofhhinterview", "");
                objParam.Add("p_observation", "");
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_spotcheckerstatus", 0);
                objParam.Add("p_hhcode","");
                objParam.Add("p_surveyplanid",0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_registerhousehold_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> ApproveRejectRegisterHousehold(int hhid, int createdby,string ActionType,string Remark,int Gregid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", ActionType);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_remark", Remark);
                objParam.Add("p_grivanceregid", Gregid);
                objParam.Add("p_parameterid", 0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_registerhousehold_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region "Demographic Member"
        //For CRUD operation of Demographic member
        public async Task<int> AddDemographicMember(DemographicMemberDto objDemoDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objDemoDto.action);
                objParam.Add("p_memberid", objDemoDto.memberid);
                objParam.Add("p_hhid", objDemoDto.hhid);
                objParam.Add("p_firstname", objDemoDto.firstname);
                objParam.Add("p_lastname", objDemoDto.lastname);
                objParam.Add("p_sex", objDemoDto.sex);
                objParam.Add("p_relationshiptohhid", objDemoDto.relationshiptohhid);
                objParam.Add("p_uploadphotopath", objDemoDto.uploadphotopath);
                objParam.Add("p_uploadphotoname", objDemoDto.uploadphotoname);
                objParam.Add("p_residencestatusid", objDemoDto.residencestatusid);
                objParam.Add("p_dohavebirthcertificate", objDemoDto.dohavebirthcertificate);
                objParam.Add("p_dateofarrival", objDemoDto.dateofarrival);
                objParam.Add("p_uploadbirthcertificate", objDemoDto.uploadbirthcertificate);
                objParam.Add("p_dateofbirth", objDemoDto.dateofbirth);
                objParam.Add("p_ethnicityid", objDemoDto.ethnicityid);
                objParam.Add("p_otherethnicgroup", objDemoDto.otherethnicgroup);
                objParam.Add("p_age", objDemoDto.age);
                objParam.Add("p_maritalstatusid", objDemoDto.maritalstatusid);
                objParam.Add("p_placeofbirthid", objDemoDto.placeofbirthid);
                objParam.Add("p_isfatherstillalive", objDemoDto.isfatherstillalive);
                objParam.Add("p_nationalityid", objDemoDto.nationalityid);
                objParam.Add("p_othernationality", objDemoDto.othernationality);
                objParam.Add("p_identificationdocids", objDemoDto.identificationdocids.TrimStart(',').TrimEnd(','));
                objParam.Add("p_fatherliveinhousehold", objDemoDto.fatherliveinhousehold);
                objParam.Add("p_recrdlineoffather", objDemoDto.recrdlineoffather);//Add By Rajkishor Patra(04-Nov-2022)
                objParam.Add("p_identificationno", objDemoDto.identificationno);
                objParam.Add("p_ismotherstillalive", objDemoDto.ismotherstillalive);
                objParam.Add("p_uploadidproof", objDemoDto.uploadidproof);
                objParam.Add("p_motherliveinhousehold", objDemoDto.motherliveinhousehold);
                objParam.Add("p_recrdlineofmother", objDemoDto.recrdlineofmother);//Add By Rajkishor Patra(04-Nov-2022)
                objParam.Add("p_createdby", objDemoDto.createdby);
                objParam.Add("p_membercode", objDemoDto.membercode!=null? objDemoDto.membercode:"");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_demographicmember_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<DemographicMemberDto>> GetDemographicMember(GetDemographicMemberQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_demographicmember_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_memberid", obj.memberid);

                    var result = await con.QueryAsync<DemographicMemberDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<DemographicMemberDto>> GetHouseholdPopup(GetDemographicMemberQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_household_popup";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_memberid", obj.memberid);
                    var result = await con.QueryAsync<DemographicMemberDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteDemographicMember(int memberid, int hhid, int createdby, string action)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_memberid", memberid);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_firstname", "");
                objParam.Add("p_lastname", "");
                objParam.Add("p_sex", 0);
                objParam.Add("p_relationshiptohhid", 0);
                objParam.Add("p_uploadphotopath", "");
                objParam.Add("p_uploadphotoname", "");
                objParam.Add("p_residencestatusid", 0);
                objParam.Add("p_dohavebirthcertificate", 0);
                objParam.Add("p_dateofarrival", "");
                objParam.Add("p_uploadbirthcertificate", "");
                objParam.Add("p_dateofbirth", "");
                objParam.Add("p_ethnicityid", 0);
                objParam.Add("p_otherethnicgroup", "");
                objParam.Add("p_age", 0);
                objParam.Add("p_maritalstatusid", 0);
                objParam.Add("p_placeofbirthid", 0);
                objParam.Add("p_isfatherstillalive", 0);
                objParam.Add("p_recrdlineoffather", 0);//Add By Rajkishor Patra(04-Nov-2022)
                objParam.Add("p_nationalityid", 0);
                objParam.Add("p_othernationality", "");
                objParam.Add("p_identificationdocids", "");
                objParam.Add("p_fatherliveinhousehold", 0);
                objParam.Add("p_identificationno", "");
                objParam.Add("p_ismotherstillalive", 0);
                objParam.Add("p_uploadidproof", "");
                objParam.Add("p_motherliveinhousehold", 0);
                objParam.Add("p_recrdlineofmother", 0);//Add By Rajkishor Patra(04-Nov-2022)
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_membercode", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_demographicmember_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        public async Task<int> ApproveRejectDemographicMember(int memberid, int hhid, int createdby, string action, string Remark, int Gregid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_memberid", memberid);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_createdby", createdby);
                 objParam.Add("p_remark", Remark);
                objParam.Add("p_grivanceregid", Gregid);
                objParam.Add("p_parameterid", 0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_demographicmember_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        #endregion
        #region "Education Info"
        //For CRUD operation of Education info
        public async Task<int> AddEducationInfo(EducationInfoDto objEducationDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objEducationDto.action);
                objParam.Add("p_memberid", objEducationDto.memberid);
                objParam.Add("p_hhid", objEducationDto.hhid);
                objParam.Add("p_educationinfoid", objEducationDto.educationinfoid);
                objParam.Add("p_isCurrentlyAttendingSchool", objEducationDto.isCurrentlyAttendingSchool);
                objParam.Add("p_age", objEducationDto.age);
                objParam.Add("p_whystoppedgoingschool", objEducationDto.whystoppedgoingschool);
                objParam.Add("p_otherreasonfornotgoingschool", objEducationDto.otherreasonfornotgoingschool);
                objParam.Add("p_typeofschoolattended", objEducationDto.typeofschoolattended);
                objParam.Add("p_canreadwriteanylanguage", objEducationDto.canreadwriteanylanguage);
                objParam.Add("p_haseverattendedschool", objEducationDto.haseverattendedschool);
                objParam.Add("p_whyneverattendedschool", objEducationDto.whyneverattendedschool);
                objParam.Add("p_otherreasonnotattendedschool", objEducationDto.otherreasonnotattendedschool);
                objParam.Add("p_lastlevelcompleted", objEducationDto.lastlevelcompleted);
                objParam.Add("p_lastgradecompleted", objEducationDto.lastgradecompleted);
                objParam.Add("p_levelattended", objEducationDto.levelattended);
                objParam.Add("p_gradeattended", objEducationDto.gradeattended);
                objParam.Add("p_createdby", objEducationDto.createdby);
                objParam.Add("p_apptypeid", objEducationDto.apptypeid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_educationinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<EducationInfoDto>> GetEducationInfo(GetEducationInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_educationinfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_educationinfoid", obj.educationinfoid);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_memberid", obj.memberid);
                    var result = await con.QueryAsync<EducationInfoDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteEducationInfo(int educationinfoid,string action, int createdby, int apptypeid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_memberid", 0);
                objParam.Add("p_hhid", 0);
                objParam.Add("p_educationinfoid", educationinfoid);
                objParam.Add("p_isCurrentlyAttendingSchool", 0);
                objParam.Add("p_age", 0);
                objParam.Add("p_whystoppedgoingschool", 0);
                objParam.Add("p_otherreasonfornotgoingschool", 0);
                objParam.Add("p_typeofschoolattended", 0);
                objParam.Add("p_canreadwriteanylanguage", 0);
                objParam.Add("p_haseverattendedschool", 0);
                objParam.Add("p_whyneverattendedschool", 0);
                objParam.Add("p_otherreasonnotattendedschool", "");
                objParam.Add("p_lastlevelcompleted", 0);
                objParam.Add("p_lastgradecompleted", 0);
                objParam.Add("p_levelattended", 0);
                objParam.Add("p_gradeattended", 0);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_educationinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        #endregion
        //For CRUD operation of Health info
        public async Task<int> AddHealthInfo(HealthInfoDto objHealthDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objHealthDto.action);
                objParam.Add("p_memberid", objHealthDto.memberid);
                objParam.Add("p_hhid", objHealthDto.hhid);
                objParam.Add("p_healthid", objHealthDto.healthinfoid);
                objParam.Add("p_doessufferanychronicillness", objHealthDto.doessufferanychronicillness);
                objParam.Add("p_dohavediffwearingglass", objHealthDto.dohavediffwearingglass);
                objParam.Add("p_dohavediffhearing", objHealthDto.dohavediffhearing);
                objParam.Add("p_dohavediffwalking", objHealthDto.dohavediffwalking);
                objParam.Add("p_dohavediffremembering", objHealthDto.dohavediffremembering);
                objParam.Add("p_dohavediffselfcare", objHealthDto.dohavediffselfcare);
                objParam.Add("p_dohavediffcommunicate", objHealthDto.dohavediffcommunicate);
                objParam.Add("p_whatchronicillnesssuffer", objHealthDto.doessufferanychronicillness==1?objHealthDto.whatchronicillnesssuffer.TrimStart(',').TrimEnd(','):"");
                objParam.Add("p_createdby", objHealthDto.createdby);
                objParam.Add("p_apptypeid", objHealthDto.apptypeid);
                objParam.Add("p_otherillness", objHealthDto.otherillness);

                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_healthinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<HealthInfoDto>> GetHealthInfo(GetHealthInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_healthinfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_healthinfoid", obj.healthinfoid);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<HealthInfoDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteHealthInfo(int healthinfoid, int createdby, int apptypeid,string action)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_memberid", 0);
                objParam.Add("p_hhid", 0);
                objParam.Add("p_healthid", healthinfoid);
                objParam.Add("p_doessufferanychronicillness", 0);
                objParam.Add("p_dohavediffwearingglass", 0);
                objParam.Add("p_dohavediffhearing", 0);
                objParam.Add("p_dohavediffwalking", 0);
                objParam.Add("p_dohavediffremembering", 0);
                objParam.Add("p_dohavediffselfcare", 0);
                objParam.Add("p_dohavediffcommunicate", 0);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);
                objParam.Add("p_whatchronicillnesssuffer", "");
                objParam.Add("p_otherillness", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_healthinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //For CRUD operation of Health info
        public async Task<int> AddEmploymentInfo(EmploymentInfoDto objEmpInfoDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objEmpInfoDto.action);
                objParam.Add("p_employmentid", objEmpInfoDto.employmentinfoid);
                objParam.Add("p_memberid", objEmpInfoDto.memberid);
                objParam.Add("p_hhid", objEmpInfoDto.hhid);
                objParam.Add("p_mainjobactivitylastthirtydays", objEmpInfoDto.mainjobactivitylastthirtydays);
                objParam.Add("p_howfreequentlyworking", objEmpInfoDto.howfreequentlyworking);
                objParam.Add("p_workinginwhichsector", objEmpInfoDto.workinginwhichsector);
                objParam.Add("p_othersector", objEmpInfoDto.othersector);
                objParam.Add("p_workingstatus", objEmpInfoDto.workingstatus);
                objParam.Add("p_reasonfornotworking", objEmpInfoDto.reasonfornotworking);
                objParam.Add("p_othereasonfornotworking", objEmpInfoDto.othereasonfornotworking);
                objParam.Add("p_createdby", objEmpInfoDto.createdby);
                objParam.Add("p_apptypeid", objEmpInfoDto.apptypeid);


                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_employmentinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<EmploymentInfoDto>> GetEmploymentInfo(GetEmploymentInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_employmentinfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_employmentinfoid", obj.employmentinfoid);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_memberid", obj.memberid);
                    var result = await con.QueryAsync<EmploymentInfoDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteEmploymentInfo(int employmentinfoid, int createdby, int apptypeid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_employmentid", employmentinfoid);
                objParam.Add("p_memberid", 0);
                objParam.Add("p_hhid", 0);
                objParam.Add("p_mainjobactivitylastthirtydays", 0);
                objParam.Add("p_howfreequentlyworking", 0);
                objParam.Add("p_workinginwhichsector", 0);
                objParam.Add("p_workingstatus", 0);
                objParam.Add("p_reasonfornotworking", 0);
                objParam.Add("p_othereasonfornotworking", "");
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);
                objParam.Add("p_othersector", "");


                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_employmentinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //For CRUD operation of Health info
        public async Task<int> AddHousingInfo(HousingInfoDto objEmpInfoDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objEmpInfoDto.action);
                objParam.Add("p_housingid", objEmpInfoDto.housinginfoid);
                objParam.Add("p_hhid", objEmpInfoDto.hhid);
                objParam.Add("p_occupancystatusofdwelling", objEmpInfoDto.occupancystatusofdwelling);
                objParam.Add("p_mainconstructionmaterial", objEmpInfoDto.mainconstructionmaterial);
                objParam.Add("p_otherconstructionmaterial", objEmpInfoDto.otherconstructionmaterial);
                objParam.Add("p_mainmaterialusedforroofing", objEmpInfoDto.mainmaterialusedforroofing);
                objParam.Add("p_othermaterialroofing", objEmpInfoDto.othermaterialroofing);
                objParam.Add("p_mainmaterialusedforflooring", objEmpInfoDto.mainmaterialusedforflooring);
                objParam.Add("p_othermaterialflooring", objEmpInfoDto.othermaterialflooring);
                objParam.Add("p_mainsourceoflighting", objEmpInfoDto.mainsourceoflighting);
                objParam.Add("p_othersourceoflighting", objEmpInfoDto.othersourceoflighting);
                objParam.Add("p_maincookingfuel", objEmpInfoDto.maincookingfuel);
                objParam.Add("p_othermaincookingfuel", objEmpInfoDto.othermaincookingfuel);
                objParam.Add("p_typeoftoiletfacility", objEmpInfoDto.typeoftoiletfacility);
                objParam.Add("p_othertoiletfacility", objEmpInfoDto.othertoiletfacility);
                objParam.Add("p_toiletsharedwithotherhh", objEmpInfoDto.toiletsharedwithotherhh);
                objParam.Add("p_howmanyhhusetoiletfacility", objEmpInfoDto.howmanyhhusetoiletfacility);
                objParam.Add("p_mainsourceofdrinkingwater", objEmpInfoDto.mainsourceofdrinkingwater);
                objParam.Add("p_othersourceofdrinkingwater", objEmpInfoDto.othersourceofdrinkingwater);
                objParam.Add("p_howhhdisposerubbish", objEmpInfoDto.howhhdisposerubbish);
                objParam.Add("p_otherwayforrubbish", objEmpInfoDto.otherwayforrubbish);
                objParam.Add("p_createdby", objEmpInfoDto.createdby);
                objParam.Add("p_apptypeid", objEmpInfoDto.apptypeid);


                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_housinginfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<HousingInfoDto>> GetHousingInfo(GetHousingInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_housinginfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                     param.Add("p_housinginfoid", obj.housinginfoid);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<HousingInfoDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteHousingInfo(int housinginfoid, int createdby, int apptypeid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_housingid", housinginfoid);
                objParam.Add("p_hhid", 0);
                objParam.Add("p_occupancystatusofdwelling", 0);
                objParam.Add("p_mainconstructionmaterial", 0);
                objParam.Add("p_otherconstructionmaterial", "");
                objParam.Add("p_mainmaterialusedforroofing", 0);
                objParam.Add("p_othermaterialroofing", "");
                objParam.Add("p_mainmaterialusedforflooring", 0);
                objParam.Add("p_othermaterialflooring", "");
                objParam.Add("p_mainsourceoflighting", 0);
                objParam.Add("p_othersourceoflighting", "");
                objParam.Add("p_maincookingfuel", 0);
                objParam.Add("p_othermaincookingfuel", "");
                objParam.Add("p_typeoftoiletfacility", 0);
                objParam.Add("p_othertoiletfacility", "");
                objParam.Add("p_toiletsharedwithotherhh", 0);
                objParam.Add("p_howmanyhhusetoiletfacility", 0);
                objParam.Add("p_mainsourceofdrinkingwater", 0);
                objParam.Add("p_othersourceofdrinkingwater", "");
                objParam.Add("p_howhhdisposerubbish", 0);
                objParam.Add("p_otherwayforrubbish", "");
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);


                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_housinginfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> ApproveRejectHousingInfo(int hhid, int createdby,string action, string Remark, int Gregid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_remark", Remark);
                objParam.Add("p_grivanceregid", Gregid);
                objParam.Add("p_parameterid", 0);
               
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_housinginfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //for crud operation of Distance info
        public async Task<int> AddDistanceInfo(DistanceInfoDto objDistanceInfoDto)
        {
            try
            {
                string distancexml = CommonHelper.SerializeToXMLString(objDistanceInfoDto.hhDistance);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objDistanceInfoDto.action);
                objParam.Add("p_hhid", objDistanceInfoDto.hhid);
                objParam.Add("p_createdby", objDistanceInfoDto.createdby);
                objParam.Add("p_apptypeid", objDistanceInfoDto.apptypeid);
                objParam.Add("p_distancexml", distancexml);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_distanceinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       public async Task<List<HouseholdDistance>> GetDistanceInfo(GetDistanceInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_distanceinfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<HouseholdDistance>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteDistanceInfo(int hhid, int createdby, int apptypeid)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);
                objParam.Add("p_distancexml", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_distanceinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //for crud operation of Household asset info
        public async Task<int> AddAssetInfo(AssetInfoDto objAssetInfoDto)
        {
            try
            {
                string assetxml = CommonHelper.SerializeToXMLString(objAssetInfoDto.assetdetail);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objAssetInfoDto.action);
                objParam.Add("p_hhid", objAssetInfoDto.hhid);
                objParam.Add("p_createdby", objAssetInfoDto.createdby);
                objParam.Add("p_apptypeid", objAssetInfoDto.apptypeid);
                objParam.Add("p_assetid", objAssetInfoDto.assetid);
                objParam.Add("p_assetxml", assetxml);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_assetinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<AssetInfoDetail>> GetAssetInfo(GetAssetInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_assetinfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<AssetInfoDetail>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteAssetInfo(int assetid, int createdby, int apptypeid)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", 0);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);
                objParam.Add("p_assetxml", "");
                objParam.Add("p_assetid", assetid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_assetinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //Crud Operation of Income source
        public async Task<int> AddIncomeSource(IncomeSourceDto objIncomeSourceDto)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objIncomeSourceDto.action);
                objParam.Add("p_hhid", objIncomeSourceDto.hhid);
                objParam.Add("p_intcomesourceid", objIncomeSourceDto.incomesourceid);
                objParam.Add("p_mainincomesourceofhh", objIncomeSourceDto.mainincomesourceofhh);
                objParam.Add("p_otherincomesource", objIncomeSourceDto.otherincomesource);
                objParam.Add("p_secodincomesourceofhh", objIncomeSourceDto.secondincomesourceofhh);
                objParam.Add("p_othersecondincomesourceofhh", objIncomeSourceDto.othersecondincomesource);
                objParam.Add("p_didhhreceivemonetaryhelp", objIncomeSourceDto.didhhreceivemonetaryhelp);
                objParam.Add("p_howmanytimesreceivedmonhelp", objIncomeSourceDto.howmanytimesreceivedmonhelp);
                objParam.Add("p_amountreceivedinlastoneyear", objIncomeSourceDto.amountreceivedinlastoneyear);
                objParam.Add("p_hashhcollectedanyaidinoneyear", objIncomeSourceDto.hashhcollectedanyaidinoneyear);
                objParam.Add("p_freequencyofaidreceived", objIncomeSourceDto.freequencyofaidreceived);
                objParam.Add("p_otherfreequencyofaidreceived", objIncomeSourceDto.otherfreequencyofaidreceived);
                objParam.Add("p_organizationtype", objIncomeSourceDto.organizationtype);
                objParam.Add("p_aidids", objIncomeSourceDto.aidids);
                objParam.Add("p_orgtypeids", objIncomeSourceDto.orgtypeids);
                objParam.Add("p_otheraid", objIncomeSourceDto.otheraid);
                objParam.Add("p_otherorgtype", objIncomeSourceDto.otherorgtype);
                objParam.Add("p_createdby", objIncomeSourceDto.createdby);
                objParam.Add("p_apptypeid", objIncomeSourceDto.apptypeid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_incomesource_aed", objParam, null, null, CommandType.StoredProcedure);

                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<IncomeSourceDto>> GetIncomeSource(GetIncomeSourceQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_incomesource_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<IncomeSourceDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteIncomeSource(int incomesourceid, int createdby, int hhid)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_intcomesourceid", incomesourceid);
                objParam.Add("p_mainincomesourceofhh", 0);
                objParam.Add("p_otherincomesource", "");
                objParam.Add("p_secodincomesourceofhh", 0);
                objParam.Add("p_othersecondincomesourceofhh", "");
                objParam.Add("p_didhhreceivemonetaryhelp", 0);
                objParam.Add("p_howmanytimesreceivedmonhelp", 0);
                objParam.Add("p_amountreceivedinlastoneyear", 0);
                objParam.Add("p_hashhcollectedanyaidinoneyear", 0);
                objParam.Add("p_freequencyofaidreceived", 0);
                objParam.Add("p_otherfreequencyofaidreceived", "");
                objParam.Add("p_organizationtype", 0);
                objParam.Add("p_aidids", "");
                objParam.Add("p_orgtypeids", "");
                objParam.Add("p_otheraid", "");
                objParam.Add("p_otherorgtype", 0);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", 0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_incomesource_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //Crud Operation of Coping Strategy
        public async Task<int> AddCopingInfo(CopingInfoDto objCopingDto)
        {

            try
            {
                string livelyhoodxml = CommonHelper.SerializeToXMLString(objCopingDto.livehlihoodcoping);
                string foodxml = CommonHelper.SerializeToXMLString(objCopingDto.foodcoping);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objCopingDto.action);
                objParam.Add("p_hhid", objCopingDto.hhid);
                objParam.Add("p_copingid", objCopingDto.copingid);
                objParam.Add("p_createdby", objCopingDto.createdby);
                objParam.Add("p_livelihoodcopingxml", livelyhoodxml);
                objParam.Add("p_foodcopingxml", foodxml);
                objParam.Add("p_apptypeid", objCopingDto.apptypeid);

                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_copinginfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<LivelihoodCoping>> GetLivelyhoodCopingInfo(GetCopingInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_copinginfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.actionl);
                    param.Add("p_copingid", obj.copingid);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<LivelihoodCoping>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<FoodCoping>> GetFoodCopingInfo(GetCopingInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_copinginfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.actionf);
                    param.Add("p_copingid", obj.copingid);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<FoodCoping>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteCopingInfo(int copingid, int createdby, int hhid)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_copingid", copingid);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_livelihoodcopingxml", "");
                objParam.Add("p_foodcopingxml", "");
                objParam.Add("p_apptypeid", 0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_copinginfo_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end
        //Crud Operation of Impact of Shocks
        public async Task<int> AddImpactOfShocks(ImpactDto objImpactDto)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objImpactDto.action);
                objParam.Add("p_hhid", objImpactDto.hhid);
                objParam.Add("p_impactid", objImpactDto.impactid);
                objParam.Add("p_ishhaffectedbyevent", objImpactDto.ishhaffectedbyevent);
                objParam.Add("p_livelyhoodaffectedids", objImpactDto.livelyhoodaffectedids);
                objParam.Add("p_shockforcropid", objImpactDto.shockforcropid);
                objParam.Add("p_shockforlivestockid", objImpactDto.shockforlivestockid);
                objParam.Add("p_shockforlabourid", objImpactDto.shockforlabourid);
                objParam.Add("p_othershockforcrop", objImpactDto.othershockforcrop);
                objParam.Add("p_othershockforlivestock", objImpactDto.othershockforlivestock);
                objParam.Add("p_othershockforlabour", objImpactDto.othershockforlabour);
                objParam.Add("p_typeofseveritycrops", objImpactDto.typeofseveritycrops);
                objParam.Add("p_typeofserveritylivestock", objImpactDto.typeofserveritylivestock);
                objParam.Add("p_typeofseveritylabour", objImpactDto.typeofseveritylabour);
                objParam.Add("p_apptypeid", objImpactDto.apptypeid);
                objParam.Add("p_shockforotherid", objImpactDto.shockforotherid);
                objParam.Add("p_othershockforother", objImpactDto.othershockforother);
                objParam.Add("p_typeofseverityother", objImpactDto.typeofseverityother);
                objParam.Add("p_createdby", objImpactDto.createdby);
                objParam.Add("p_otheraffectedlivelyhood", objImpactDto.otheraffectedlivelyhood);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_impactofshocks_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ImpactDto>> GetImpactOfShocks(GetImpactQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_impactofshocks_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_impactid", obj.impactid);
                    var result = await con.QueryAsync<ImpactDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteImpactOfShocks(int impactid, int hhid, int createdby)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_impactid", impactid);
                objParam.Add("p_ishhaffectedbyevent", 0);
                objParam.Add("p_livelyhoodaffectedids", "");
                objParam.Add("p_shockforcropid", 0);
                objParam.Add("p_shockforlivestockid", 0);
                objParam.Add("p_shockforlabourid", 0);
                objParam.Add("p_othershockforcrop", "");
                objParam.Add("p_othershockforlivestock", "");
                objParam.Add("p_othershockforlabour", "");
                objParam.Add("p_typeofseveritycrops", 0);
                objParam.Add("p_typeofserveritylivestock", 0);
                objParam.Add("p_typeofseveritylabour", 0);
                objParam.Add("p_apptypeid", 0);
                objParam.Add("p_shockforotherid", 0);
                objParam.Add("p_othershockforother", "");
                objParam.Add("p_typeofseverityother", 0);
                objParam.Add("p_createdby", createdby);

                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_impactofshocks_aed", objParam, null, null, CommandType.StoredProcedure);

                return objParam.Get<int>("p_out");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> ApproveRejectImpactOfShocks(int impactid, int hhid, int createdby,string action, string Remark, int Gregid)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", action);
                objParam.Add("p_impactid", impactid);
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_remark", Remark);
                objParam.Add("p_grivanceregid", Gregid);
                objParam.Add("p_parameterid", 0);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_impactofshocks_ar", objParam, null, null, CommandType.StoredProcedure);

                return objParam.Get<int>("p_out");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //End
        //Crud Operation of Agriculture Info
        public async Task<int> AddAgricultureInfo(AgricultureinfoDto objAgriDto)
        {
            try
            {
                string cultivationxml = CommonHelper.SerializeToXMLString(objAgriDto.cultivation);
                string responsibilityxml = CommonHelper.SerializeToXMLString(objAgriDto.cultivationresponsibility);
                string ownlivestockxml = CommonHelper.SerializeToXMLString(objAgriDto.ownlivestock);
                string breedinglivestockxml = CommonHelper.SerializeToXMLString(objAgriDto.breedinglivestock);
                string ecologylivexml = CommonHelper.SerializeToXMLString(objAgriDto.ecologystock);

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objAgriDto.action);
                objParam.Add("p_hhid", objAgriDto.hhid);
                objParam.Add("p_agricultureid", objAgriDto.agricultureid);
                objParam.Add("p_doescultivateland", objAgriDto.doescultivateland);
                objParam.Add("p_ownedland", objAgriDto.ownedland);
                objParam.Add("p_rentedland", objAgriDto.rentedland);
                objParam.Add("p_freeland", objAgriDto.freeland);
                objParam.Add("p_ownedbywhom", objAgriDto.ownedbywhom);
                objParam.Add("p_rainfedlow", objAgriDto.rainfedlow);
                objParam.Add("p_rainfedhigh", objAgriDto.rainfedhigh);
                objParam.Add("p_irrigated", objAgriDto.irrigated);
                objParam.Add("p_pasture", objAgriDto.pasture);
                objParam.Add("p_wasanyhhcatchingfish", objAgriDto.wasanyhhcatchingfish);
                objParam.Add("p_nooffemalecatching", objAgriDto.nooffemalecatching);
                objParam.Add("p_noofmalecatching", objAgriDto.noofmalecatching);
                objParam.Add("p_anyonehhownlivestock", objAgriDto.anyonehhownlivestock);
                objParam.Add("p_cultivationxml", cultivationxml);
                objParam.Add("p_responsibilityxml", responsibilityxml);
                objParam.Add("p_ownlivestockxml", ownlivestockxml);
                objParam.Add("p_breedinglivestockxml", breedinglivestockxml);
                objParam.Add("p_ecologyxml", ecologylivexml);
                objParam.Add("p_createdby", objAgriDto.createdby);
                objParam.Add("p_apptypeid", objAgriDto.apptypeid);

                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);


                await Connection.ExecuteAsync("usp_hhr_agricultureinfo_aed", objParam, null, null, CommandType.StoredProcedure);
                //string val= objParam.Get<string>("p_out1");
                return objParam.Get<int>("p_out");
                //return objParam.Get<dynamic>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<AgricultureinfoDto>> GetAgricultureInfo(GetAgricultureInfoQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_agricultureinfo_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_agricultureid", obj.agricultureid);
                    var result = await con.QueryAsync<AgricultureinfoDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteAgricultureInfo(int agricultureid, int hhid, int createdby, int apptypeid)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "d");
                objParam.Add("p_hhid", hhid);
                objParam.Add("p_agricultureid", agricultureid);
                objParam.Add("p_doescultivateland", 0);
                objParam.Add("p_ownedland", 0);
                objParam.Add("p_rentedland", 0);
                objParam.Add("p_freeland", 0);
                objParam.Add("p_ownedbywhom", 0);
                objParam.Add("p_rainfedlow", 0);
                objParam.Add("p_rainfedhigh", 0);
                objParam.Add("p_irrigated", 0);
                objParam.Add("p_pasture", 0);
                objParam.Add("p_wasanyhhcatchingfish", 0);
                objParam.Add("p_nooffemalecatching", 0);
                objParam.Add("p_noofmalecatching", 0);
                objParam.Add("p_anyonehhownlivestock", 0);
                objParam.Add("p_cultivationxml", "");
                objParam.Add("p_responsibilityxml", "");
                objParam.Add("p_ownlivestockxml", "");
                objParam.Add("p_breedinglivestockxml", "");
                objParam.Add("p_createdby", createdby);
                objParam.Add("p_apptypeid", apptypeid);

                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                await Connection.ExecuteAsync("usp_hhr_agricultureinfo_aed", objParam, null, null, CommandType.StoredProcedure);

                return objParam.Get<int>("p_out");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> GetAllParentLocation(int locationid)
        {
            try
            {

                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getall_locationparentname";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_locationid", locationid);

                    var result = await con.QueryAsync<string>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList()[0];
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //End
        #region----------household status----------------
        public async Task<List<HouseholdStatusDto>> GetAllHouseholdstatus(GetAllHouseholdStatusQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_status_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_hhid", obj.hhid);
                    var result = await con.QueryAsync<HouseholdStatusDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateApproveStatusOfHousehold(SurveyApproveStatusDto objRegisterhhdto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objRegisterhhdto.action);
                objParam.Add("p_hhid", objRegisterhhdto.hhid);
                objParam.Add("p_moduleid", objRegisterhhdto.moduleid);
                objParam.Add("p_remarks", objRegisterhhdto.remarks);
                objParam.Add("p_createdby", objRegisterhhdto.createdby);
                objParam.Add("p_approvestatus", objRegisterhhdto.approvestatus);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_statusapprove_ae", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region PMT
        public async Task<List<RegisterHouseholdDto>> GetRegisterHouseholdForPMT(GetRegisterHouseholdQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_pmt_registerhousehold_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "PV");                    
                    param.Add("p_locationid", obj.locationid);
                    param.Add("p_surveyid", obj.surveyId);

                    var result = await con.QueryAsync<RegisterHouseholdDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Household Comparision
        public async Task<List<RegisterHouseholdDto>> GetRegisterHHForComparision(GetRegisterHouseholdQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_registerhousehold_ve";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_householdno", obj.householdno == null ? "" : obj.householdno);
                    param.Add("p_eano", obj.eano == null ? "" : obj.eano);
                    param.Add("p_hhheadname", obj.hhheadname == null ? "" : obj.hhheadname);
                    param.Add("p_hhid", obj.hhid);
                    param.Add("p_locationid", obj.locationid);  
                    param.Add("p_pageno", obj.pageno);
                    param.Add("p_pagesize", obj.pagesize);

                    var result = await con.QueryAsync<RegisterHouseholdDto>(Query, param, commandType: CommandType.StoredProcedure);
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
        public async Task<int> UpdateEducationStatusInfo(EducationInfoStatusDto objEducationDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objEducationDto.action);
                objParam.Add("p_memberid", objEducationDto.memberid);
                objParam.Add("p_hhid", objEducationDto.hhid);
                objParam.Add("p_educationinfoid", objEducationDto.educationinfoid);
                objParam.Add("p_remark", objEducationDto.remark);
                objParam.Add("p_id", objEducationDto.id);
                objParam.Add("p_parameterid", objEducationDto.parameterid);
                objParam.Add("p_createdby", objEducationDto.createdby);
                objParam.Add("p_apptypeid", objEducationDto.apptypeid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_educationinfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateHealthStatusInfo(HealthStatusInfoDto objHealthDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objHealthDto.action);
                objParam.Add("p_memberid", objHealthDto.memberid);
                objParam.Add("p_hhid", objHealthDto.hhid);
                objParam.Add("p_healthid", objHealthDto.healthinfoid);                
                objParam.Add("p_createdby", objHealthDto.createdby);
                objParam.Add("p_apptypeid", objHealthDto.apptypeid);
                objParam.Add("p_remark", objHealthDto.remark);
                objParam.Add("p_id", objHealthDto.id);
                objParam.Add("p_parameterid", objHealthDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_healthinfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update Health info
        public async Task<int> UpdateEmploymentStatusInfo(EmploymentStatusInfoDto objEmpInfoDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objEmpInfoDto.action);
                objParam.Add("p_employmentid", objEmpInfoDto.employmentinfoid);
                objParam.Add("p_memberid", objEmpInfoDto.memberid);
                objParam.Add("p_hhid", objEmpInfoDto.hhid);               
                objParam.Add("p_createdby", objEmpInfoDto.createdby);
                objParam.Add("p_apptypeid", objEmpInfoDto.apptypeid);
                objParam.Add("p_remark", objEmpInfoDto.remark);
                objParam.Add("p_id", objEmpInfoDto.id);
                objParam.Add("p_parameterid", objEmpInfoDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_employmentinfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateDistanceStatusInfo(DistanceStatusInfoDto objDistanceInfoDto)
        {
            try
            {
               
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objDistanceInfoDto.action);
                objParam.Add("p_hhid", objDistanceInfoDto.hhid);
                objParam.Add("p_createdby", objDistanceInfoDto.createdby);
                objParam.Add("p_apptypeid", objDistanceInfoDto.apptypeid);
                objParam.Add("p_remark", objDistanceInfoDto.remark);
                objParam.Add("p_id", objDistanceInfoDto.id);
                objParam.Add("p_parameterid", objDistanceInfoDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_distanceinfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateAssetStatusInfo(AssetStatusInfoDto objAssetInfoDto)
        {
            try
            {
             
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objAssetInfoDto.action);
                objParam.Add("p_hhid", objAssetInfoDto.hhid);
                objParam.Add("p_createdby", objAssetInfoDto.createdby);
                objParam.Add("p_apptypeid", objAssetInfoDto.apptypeid);
                objParam.Add("p_assetid", objAssetInfoDto.assetid);
                objParam.Add("p_remark", objAssetInfoDto.remark);
                objParam.Add("p_id", objAssetInfoDto.id);
                objParam.Add("p_parameterid", objAssetInfoDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_assetinfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateIncomeSourceStatusInfo(IncomeStatusSourceDto objIncomeSourceDto)
        {
            try
            {

                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_intcomesourceid", objIncomeSourceDto.incomesourceid);
                objParam.Add("p_action", objIncomeSourceDto.action);
                objParam.Add("p_hhid", objIncomeSourceDto.hhid);               
                objParam.Add("p_createdby", objIncomeSourceDto.createdby);
                objParam.Add("p_apptypeid", objIncomeSourceDto.apptypeid);              
                objParam.Add("p_remark", objIncomeSourceDto.remark);
                objParam.Add("p_id", objIncomeSourceDto.id);
                objParam.Add("p_parameterid", objIncomeSourceDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_incomesource_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateCopingStatusInfo(CopingStatusInfoDto objCopingDto)
        {

            try
            {
              
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objCopingDto.action);
                objParam.Add("p_hhid", objCopingDto.hhid);
                objParam.Add("p_copingid", objCopingDto.copingid);
                objParam.Add("p_createdby", objCopingDto.createdby);              
                objParam.Add("p_apptypeid", objCopingDto.apptypeid);
                objParam.Add("p_remark", objCopingDto.remark);
                objParam.Add("p_id", objCopingDto.id);
                objParam.Add("p_parameterid", objCopingDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_copinginfo_ar", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateAgricultureStatusInfo(AgricultureStatusinfoDto objAgriDto)
        {
            try
            {
              
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objAgriDto.action);
                objParam.Add("p_hhid", objAgriDto.hhid);
                objParam.Add("p_agricultureid", objAgriDto.agricultureid);             
                objParam.Add("p_createdby", objAgriDto.createdby);
                objParam.Add("p_apptypeid", objAgriDto.apptypeid);
                objParam.Add("p_remark", objAgriDto.remark);
                objParam.Add("p_id", objAgriDto.id);
                objParam.Add("p_parameterid", objAgriDto.parameterid);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_hhr_agricultureinfo_ar", objParam, null, null, CommandType.StoredProcedure);             
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
//End

 
