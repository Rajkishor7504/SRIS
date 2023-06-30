using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.UpdateHousehold.Queries;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class UpdateHouseholdService : BaseRepository, IUpdateHouseholdService
    {
        private readonly IConnectionFactory _connectionFactory;
        public UpdateHouseholdService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<UpdateHouseholdDto>> IUpdateHouseholdService.GetHouseholdDetails(UpdateHouseholdDto objUpdateHouseholdDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_update_gethousehold";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", objUpdateHouseholdDto.action);
                    param.Add("searchid", objUpdateHouseholdDto.p_id);
                    param.Add("leveldtlsid", 0);
                    param.Add("p_hhno", objUpdateHouseholdDto.hhnumber);
                    param.Add("p_hholdno", objUpdateHouseholdDto.hholdnumber);
                    var result = await con.QueryAsync<UpdateHouseholdDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateHousehold(UpdateHouseholdDto objUpdateHouseholdDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objUpdateHouseholdDto.action);
                objParam.Add("p_householdid", objUpdateHouseholdDto.hhid);
                objParam.Add("p_householdno", objUpdateHouseholdDto.householdno);
                objParam.Add("p_updatepriorityid", objUpdateHouseholdDto.updatepriorityid);
                objParam.Add("p_hhheadname", objUpdateHouseholdDto.hhheadname);
                objParam.Add("p_updatedate", objUpdateHouseholdDto.updatedate);
                objParam.Add("p_updatecategoryid", objUpdateHouseholdDto.updatecategoryid);
                objParam.Add("p_contactno", objUpdateHouseholdDto.contactno);
                objParam.Add("p_updatesourceid", objUpdateHouseholdDto.updatesourceid);
                objParam.Add("p_updatedescription", objUpdateHouseholdDto.updatedescription);
                objParam.Add("p_createdby", objUpdateHouseholdDto.createdby);
                objParam.Add("p_status", objUpdateHouseholdDto.status);
                objParam.Add("p_updatereason", objUpdateHouseholdDto.updatereason);
                objParam.Add("p_requestid", objUpdateHouseholdDto.requestid);
                objParam.Add("p_grievancrregistrationid", objUpdateHouseholdDto.grievanceregistrationid);
                objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_update_household", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_output");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
