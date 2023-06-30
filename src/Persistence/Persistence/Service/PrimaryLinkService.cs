using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PrimaryLinkMasters.Queries.GetPrimaryLinkMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    class PrimaryLinkService : BaseRepository, IPrimaryLinkService
    {
        private readonly IConnectionFactory _connectionFactory;
        public PrimaryLinkService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<PrimaryLinkMasterDto>> IPrimaryLinkService.GetPrimaryLinks()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getprimarylinks";
                    con.Open();                    
                    var result = await con.QueryAsync<PrimaryLinkMasterDto>(Query, commandType: CommandType.StoredProcedure);
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
