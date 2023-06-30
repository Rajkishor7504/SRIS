using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Queries;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class LocationStatusUpdateService : BaseRepository, ILocationStatusUpdateService
    {
        private readonly IConnectionFactory _connectionFactory;
        public LocationStatusUpdateService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<StatusUpdateDto>> ILocationStatusUpdateService.GetStatus(StatusUpdateDto statusupdate)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_surveylocationstatus";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", statusupdate.action);
                    param.Add("p_searchid", statusupdate.searchid);
                    var result = await con.QueryAsync<StatusUpdateDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateStatus(StatusUpdateDto statusupdate)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", statusupdate.action);
            objParam.Add("p_planid", statusupdate.planid);
            objParam.Add("p_regionid", statusupdate.regionid);
            objParam.Add("p_distid", statusupdate.distid);
            objParam.Add("p_wardid", statusupdate.wardid);
            objParam.Add("p_settlementid", statusupdate.settlementid);
            objParam.Add("p_status", statusupdate.status);
            objParam.Add("p_createdby", statusupdate.createdby);

            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_surveylocationwisestatus_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_output");
        }

    }
}
