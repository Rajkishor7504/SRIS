using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PrimaryLinkAllMastersMasters.Queries.GetPrimaryLinkAllMastersMaster;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    public class PrimaryLinkAllMastersService : BaseRepository, IPrimaryLinkAllMastersService
    {
        private readonly IConnectionFactory _connectionFactory;
        public PrimaryLinkAllMastersService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<PrimaryLinkAllMastersMasterDto>> IPrimaryLinkAllMastersService.GetPrimaryLinks()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getallmastersprimarylinks";
                    con.Open();
                    var result = await con.QueryAsync<PrimaryLinkAllMastersMasterDto>(Query, commandType: CommandType.StoredProcedure);
                    return result.Where(pl => !pl.deletedflag).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
