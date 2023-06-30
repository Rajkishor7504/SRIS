using Dapper;
using SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class AccessLinkService : BaseRepository, IAccessLinkService
    {
        private readonly IConnectionFactory _connectionFactory;
        public AccessLinkService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<AccessLinkMasterDto>> IAccessLinkService.GetUserAccessLinks(int userid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getaccesslinks";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("pint_userid", userid);
                    var result = await con.QueryAsync<AccessLinkMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Need to make this async
        public async Task<int> AddAccessLinks(AccessLinkMasterDto AccessLink)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("pchr_action", "a");
            objParam.Add("pchr_myusername", AccessLink.userid);
            var result = Connection.ExecuteAsync("usp_myuser_aed", objParam, null, null, CommandType.StoredProcedure);
            return await result;
        }
        Task<int> IAccessLinkService.DeleteAccessLink(int? AccessLinkId)
        {
            throw new NotImplementedException();
        }

        Task<AccessLinkMasterDto> IAccessLinkService.GetUserAccessLink(int? AccessLinkId)
        {
            throw new NotImplementedException();
        }

        Task IAccessLinkService.UpdateAccessLink(AccessLinkMasterDto AccessLink)
        {
            throw new NotImplementedException();
        }
    }
}
