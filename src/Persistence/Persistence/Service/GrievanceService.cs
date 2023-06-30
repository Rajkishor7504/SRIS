using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.ConfigureCommiteeMasterItems.Queries.GetConfigureCommitee;
using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using SRIS.Application.Grievances.Queries.GetAssignSurveyManager;
using SRIS.Application.Grievances.Queries.GetRegisterMember;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class GrievanceService : BaseRepository,IGrievanceService
    {
        private readonly IConnectionFactory _connectionFactory;
        public GrievanceService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public Task<int> AddConfigureCommitee(ConfigureCommiteeDto objConfigureCommitee)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GrievanceDetailDto>> GetGrievanceDetail(int grievanceId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "GTD");
                    param.Add("p_userId", 0);
                    param.Add("p_grievanceId", grievanceId);
                    param.Add("p_locationid", 0);
                    var result = await con.QueryAsync<GrievanceDetailDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
           public async Task<List<GrievanceDetailticketDto>> GetGrievanceticketdetailsDetail(int grievanceId)
            {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "D");
                    param.Add("p_userId", 0);
                    param.Add("p_grievanceId", grievanceId);
                    param.Add("p_locationid", 0);
                    var result = await con.QueryAsync<GrievanceDetailticketDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<HouseholdDetailsDto>> GetHouseholddetails(int grievanceId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "HD");
                    param.Add("p_userId", 0);
                    param.Add("p_grievanceId", grievanceId);
                    param.Add("p_locationid", 0);
                    var result = await con.QueryAsync<HouseholdDetailsDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RegisterMemberDto>> GetRegisterMembers()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_RegisterMember_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "V");                    
                    var result = await con.QueryAsync<RegisterMemberDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> RegisterMember(RegisterMemberDto objRegisterMember)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "A");
            objParam.Add("p_memberid",0 );
            objParam.Add("p_comitteid",objRegisterMember.comitteid);
            objParam.Add("p_commiteemembername", objRegisterMember.commiteemembername);
            objParam.Add("p_fathername", objRegisterMember.fathername);
            objParam.Add("p_memberpositionid", objRegisterMember.memberpositionid);
            objParam.Add("p_email", objRegisterMember.email);
            objParam.Add("p_contactnumber", objRegisterMember.contactnumber);
            objParam.Add("p_regionid", objRegisterMember.regionid);            
            objParam.Add("p_districtid", objRegisterMember.districtid);           
            objParam.Add("p_wardid", objRegisterMember.wardid);
            objParam.Add("p_settlementid", objRegisterMember.settlementid);
            objParam.Add("p_password", objRegisterMember.password);
            objParam.Add("p_Secretkey", objRegisterMember.Secretkey);
            objParam.Add("p_createdby", objRegisterMember.createdby);
            objParam.Add("p_rolename", objRegisterMember.rolename);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_Grievance_RegisterMember", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }
        
        async Task<List<GrievanceRegisteredDto>> IGrievanceService.RegisteredGrievanceView(int userId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "V");
                    param.Add("p_userId", userId);
                    param.Add("p_grievanceId", 0);
                    param.Add("p_locationid", 0);
                    var result = await con.QueryAsync<GrievanceRegisteredDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<List<GrievanceRegisteredDto>> IGrievanceService.GrievanceView(string action, int locationid, int userId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";
                    if (locationid == 0 && (action == "P" || action == "F"))
                    {
                        Query = "usp_Grievance_View_NSPS";
                    }
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_userId", userId);
                    param.Add("p_grievanceId", 0);
                    param.Add("p_locationid", locationid);
                    var result = await con.QueryAsync<GrievanceRegisteredDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GrievanceStatusDto>> GetGrievanceStatusDetail(int grievanceId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "S");
                    param.Add("p_userId", 0);
                    param.Add("p_grievanceId", grievanceId);
                    param.Add("p_locationid", 0);
                    var result = await con.QueryAsync<GrievanceStatusDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SurveyManagerDto>> GetSurveyDetails(string action, int locationid, int userId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_getassignsurveymanager";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_userId", userId);                   
                    param.Add("p_locationId", locationid);
                    param.Add("p_pkid", 0);
                    var result = await con.QueryAsync<SurveyManagerDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<AssignSurveyManagerDto>> GetGrievanceBySurveyManagerId(int userId)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_View";                    
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "SMV");
                    param.Add("p_userId", userId);
                    param.Add("p_grievanceId", 0);
                    param.Add("p_locationid", 0);
                    var result = await con.QueryAsync<AssignSurveyManagerDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateGrievanceNotification(NotificationMasterDto objnotificstionmaster)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "ND");
            objParam.Add("p_requestId", objnotificstionmaster.refNo);
            objParam.Add("p_requeststatus", 1);
            objParam.Add("p_remarks", objnotificstionmaster.ModuleName);
            objParam.Add("p_information", objnotificstionmaster.Information);
            objParam.Add("p_destinationURL", "");
            objParam.Add("p_createdby", 0);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.QueryAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }
        public async Task<int> AddQAOfficerNotification(NotificationMasterDto objaddQaNotification)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "QA");
            objParam.Add("p_requestId", objaddQaNotification.CreatedBy);
            objParam.Add("p_requeststatus", 0);
            objParam.Add("p_information", objaddQaNotification.Information);
            objParam.Add("p_remarks", objaddQaNotification.DestinationURL);
            objParam.Add("p_destinationURL", "");
            objParam.Add("p_createdby", 19);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = await Connection.ExecuteAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
            return result;
        }
        public async Task<int> AddUpdateOfficerNotification(NotificationMasterDto objaddQaNotification)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "UO");
            objParam.Add("p_requestId", 0);
            objParam.Add("p_requeststatus", 0);
            objParam.Add("p_information", objaddQaNotification.Information);
            objParam.Add("p_remarks", objaddQaNotification.DestinationURL);
            objParam.Add("p_destinationURL", "");
            objParam.Add("p_createdby", 30);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = await Connection.ExecuteAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
            return result;
        }
        public async Task<int> UpdateQAOfficerNotification(NotificationMasterDto objqanotification)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "QN");
            objParam.Add("p_requestId", objqanotification.refNo);
            objParam.Add("p_requeststatus", 1);
            objParam.Add("p_remarks", objqanotification.ModuleName);
            objParam.Add("p_information", objqanotification.Information);
            objParam.Add("p_destinationURL", objqanotification.DestinationURL);
            objParam.Add("p_createdby", objqanotification.CreatedBy);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }
        public async Task<int> UpdateqasupervisorNotification(NotificationMasterDto objqasupervisornotification)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "SN");
            objParam.Add("p_requestId", objqasupervisornotification.refNo);
            objParam.Add("p_requeststatus", 1);
            objParam.Add("p_remarks", objqasupervisornotification.ModuleName);
            objParam.Add("p_information", "");
            objParam.Add("p_destinationURL", "");
            objParam.Add("p_createdby", objqasupervisornotification.CreatedBy);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.QueryAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }
        public async Task<List<NotificationMasterDto>> GetNotificationDetails(NotificationMasterDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_allnotification_data";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "GD");
                    param.Add("p_requestId", obj.refNo);
                    param.Add("p_requeststatus", 0);
                    param.Add("p_remarks", "");
                    param.Add("p_information", "");
                    param.Add("p_destinationURL", "");
                    param.Add("p_createdby", 0);
                    param.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = await con.QueryAsync<NotificationMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<NotificationMasterDto>> GetNotificationCount(NotificationMasterDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_allnotification_data";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_requestId", obj.refNo);
                    param.Add("p_requeststatus", 0);
                    param.Add("p_remarks", "");
                    param.Add("p_information", "");
                    param.Add("p_destinationURL", "");
                    param.Add("p_createdby", obj.CreatedBy);
                    param.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = await con.QueryAsync<NotificationMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<AssignSurveyManagerDto>> ViewTaggedSurveyManager(int pkid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_Grievance_getassignsurveymanager";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", "VT");
                    param.Add("p_locationid", 0);
                    param.Add("p_userId", 0);
                    param.Add("p_pkid", pkid);                    
                    var result = await con.QueryAsync<AssignSurveyManagerDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
