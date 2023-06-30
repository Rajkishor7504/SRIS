using Dapper;
using SRIS.Application.AssignLinkToRoleMasters.Queries.GetAssignLinkToRoleMaster;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class AssignLinkToRoleService : BaseRepository, IAssignLinkToRoleService
    {
        private readonly IConnectionFactory _connectionFactory;
        public AssignLinkToRoleService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<AssignLinkToRoleMasterDto>> IAssignLinkToRoleService.GetUserAccessLinks(int roleid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getassignlinksToRole";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("pint_userid", roleid);
                    var result = await con.QueryAsync<AssignLinkToRoleMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
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
