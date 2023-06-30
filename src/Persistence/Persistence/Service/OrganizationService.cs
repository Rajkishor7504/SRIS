using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.OrganizationResistration.Queries.GetOrganization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class OrganizationService : BaseRepository, IOrganizationService
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrganizationService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddOrganization(OrganizationDto organization)
        {
            try 
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "N");
                objParam.Add("p_orgId", organization.organisationid);
                objParam.Add("p_orgname", organization.organisationname);
                objParam.Add("p_orgcategoryId", organization.organisationcategoryid);
                objParam.Add("p_contactname", organization.contactname);
                objParam.Add("p_address", organization.address);
                objParam.Add("p_state", organization.State);
                objParam.Add("p_phoneno", organization.phoneno);
                objParam.Add("p_email", organization.email);
                objParam.Add("p_physicallocation", organization.physicallocation);
                objParam.Add("p_mobileno", organization.mobileno);
                objParam.Add("p_telephoneno", organization.telephoneno);
                objParam.Add("p_officialemail", organization.officialemail);
                objParam.Add("p_contacttype", organization.contacttype);
                objParam.Add("p_registrationpurpose", organization.registrationpurpose);
                objParam.Add("p_status", organization.status);
                objParam.Add("p_password", organization.password);
                objParam.Add("p_Secretkey", organization.Secretkey);
                objParam.Add("p_createdby", 1);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = Connection.ExecuteAsync("usp_OrganizationRegistration", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
                // return await result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
        }

        public async Task<int> Partnernotification(OrganizationDto organization)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "PN");
                objParam.Add("p_orgId", 0);
                objParam.Add("p_orgname", "");
                objParam.Add("p_orgcategoryId", 0);
                objParam.Add("p_contactname", "");
                objParam.Add("p_address", organization.organisationname);
                objParam.Add("p_state", "");
                objParam.Add("p_phoneno", "");
                objParam.Add("p_email", "");
                objParam.Add("p_physicallocation", "");
                objParam.Add("p_mobileno", "");
                objParam.Add("p_telephoneno", "");
                objParam.Add("p_officialemail", "");
                objParam.Add("p_contacttype", 0);
                objParam.Add("p_registrationpurpose", 0);
                objParam.Add("p_status", organization.status);
                objParam.Add("p_password", "");
                objParam.Add("p_Secretkey", organization.Secretkey);
                objParam.Add("p_createdby", 1);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = Connection.ExecuteAsync("usp_OrganizationRegistration", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
                // return await result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public async Task<int> DeleteOrganization(int? organizationId)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "D");
            objParam.Add("p_orgId", organizationId);
            objParam.Add("p_orgname", "");
            objParam.Add("p_orgcategoryId", 0);
            objParam.Add("p_contactname", "");
            objParam.Add("p_address", "");
            objParam.Add("p_state", "");
            objParam.Add("p_phoneno", "");
            objParam.Add("p_email", "");
            objParam.Add("p_physicallocation", "");
            objParam.Add("p_mobileno", "");
            objParam.Add("p_telephoneno", "");
            objParam.Add("p_officialemail", "");
            objParam.Add("p_contacttype", 0);
            objParam.Add("p_registrationpurpose", 0);
            objParam.Add("p_status", 0);
            objParam.Add("p_password", "");
            objParam.Add("p_Secretkey", "");
            objParam.Add("p_createdby", 1);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_OrganizationRegistration", objParam, null, null, CommandType.StoredProcedure);
            return await result;
        }

        public async Task<List<OrganizationDto>> GetOrganization()
        {            
            var result = await Connection.QueryAsync<OrganizationDto>("usp_OrganizationRegistration_View", null, commandType: CommandType.StoredProcedure);
            return  result.ToList();
        }

        public async Task<OrganizationDto> GetOrganizationById(int? organizationId)
        {            
            var result = await Connection.QueryAsync<OrganizationDto>("usp_OrganizationRegistration_View", null, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault(org => org.organisationid == organizationId);
        }

        public async Task<int> ApproveOrRejectOrganization(OrganizationDto organization)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "S");
            objParam.Add("p_orgId", organization.organisationid);
            objParam.Add("p_orgname", organization.organisationname);
            objParam.Add("p_orgcategoryId", 0);
            objParam.Add("p_contactname", organization.contactname);
            objParam.Add("p_address", "");
            objParam.Add("p_state", "");
            objParam.Add("p_phoneno", organization.phoneno);
            objParam.Add("p_email", organization.email);
            objParam.Add("p_physicallocation", organization.physicallocation);
            objParam.Add("p_mobileno", organization.mobileno);
            objParam.Add("p_telephoneno", organization.telephoneno);
            objParam.Add("p_officialemail", organization.officialemail);
            objParam.Add("p_contacttype", organization.contacttype);
            objParam.Add("p_registrationpurpose", organization.registrationpurpose);
            objParam.Add("p_status", organization.status);
            objParam.Add("p_password", organization.password);
            objParam.Add("p_Secretkey", organization.Secretkey);
            objParam.Add("p_createdby", 1);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = await Connection.ExecuteAsync("usp_OrganizationRegistration", objParam, null, null, CommandType.StoredProcedure);
            return result;
        }
        public async Task<int> ApproveOrganization(int? organizationId)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "A");
            objParam.Add("p_orgId", organizationId);
            objParam.Add("p_orgname", "");
            objParam.Add("p_orgcategoryId", 0);
            objParam.Add("p_contactname", "");
            objParam.Add("p_address", "");
            objParam.Add("p_state", "");
            objParam.Add("p_phoneno", "");
            objParam.Add("p_email", "");
            objParam.Add("p_physicallocation", "");
            objParam.Add("p_mobileno", "");
            objParam.Add("p_telephoneno", "");
            objParam.Add("p_officialemail", "");
            objParam.Add("p_contacttype", 0);
            objParam.Add("p_registrationpurpose", 0);
            objParam.Add("p_status", 0);
            objParam.Add("p_password", "");
            objParam.Add("p_Secretkey", "");
            objParam.Add("p_createdby", 1);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_OrganizationRegistration", objParam, null, null, CommandType.StoredProcedure);
            return await result;
        }
    }
}
