using Dapper;
using SRIS.Application.Common.Interfaces;

using SRIS.Application.SurveyPlanning.AssignEA.Queries;
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
    public class AssignEAService : BaseRepository, IAssignEAService
    {
        private readonly IConnectionFactory _connectionFactory;
        public AssignEAService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AssignEA(AssignEADto AssignEA)
        {
            string AssignEAXML = CommonHelper.SerializeToXMLString(AssignEA.Lists);
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", AssignEA.action);
            objParam.Add("p_planid", AssignEA.planid);
            objParam.Add("p_eanumber", AssignEA.eanumber);
            objParam.Add("p_createdby", AssignEA.createdby);
            objParam.Add("p_userid", AssignEA.userid);
            objParam.Add("p_assigneaid", AssignEA.assigneaid);
            objParam.Add("p_regionid", AssignEA.regionid);
            objParam.Add("p_distid", AssignEA.distid);
            objParam.Add("p_wardid", AssignEA.wardid);
            objParam.Add("p_settlementid", AssignEA.settlementid);
            objParam.Add("p_supervisorlocationid", AssignEA.supervisorlocationid);
            objParam.Add("p_ealocationid", AssignEA.ealocationid);
            objParam.Add("p_assignEAXML", AssignEAXML);
            objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
            var result = Connection.ExecuteAsync("usp_assignea_aed", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_output");
        }
        async Task<List<AssignEADto>> IAssignEAService.GetAssignEA(AssignEADto AssignEA)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_assignea";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", AssignEA.action);
                    param.Add("p_id", AssignEA.levelid);
                    param.Add("p_rid", AssignEA.planid);
                    param.Add("p_did", AssignEA.regionid);
                    param.Add("p_wid", AssignEA.wardid);
                    param.Add("p_sid", AssignEA.settlementid);
                    var result = await con.QueryAsync<AssignEADto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddEaList(IList<AssignEADto> AssignEAlist)
        {
            int result = 0;
            foreach (var location in AssignEAlist)
            {
                result = await AssignEA(location);
            }
            return result;
        }

    }
}
