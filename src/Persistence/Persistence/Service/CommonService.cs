using Dapper;
using SRIS.Application.Common.Dropdown.Queries;
using SRIS.Application.Common.Interfaces;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class CommonService : BaseRepository, ICommonService
    {
        private readonly IConnectionFactory _connectionFactory;
        public CommonService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<FillDropdownDto>> GetDropdownData(FillDrodownQuery obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_com_filldropdown";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", obj.action);
                    param.Add("p_item1", obj.item1);
                    param.Add("p_item2", obj.item2);
                    var result = await con.QueryAsync<FillDropdownDto>(Query, param, commandType: CommandType.StoredProcedure);
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
