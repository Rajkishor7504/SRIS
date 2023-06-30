using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class ReporthhidService : BaseRepository, IReporthhidService
    {
        private readonly IConnectionFactory _connectionFactory;
        public ReporthhidService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        async Task<List<HouseholdcatagoryDto>> IReporthhidService.Gethhcatagory(HouseholdcatagoryDto hhcatagory)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_hhcatagory";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("action", grievance.action);
                    //param.Add("searchid", grievance.p_id);
                    //param.Add("leveldtlsid", 0);
                    //param.Add("puserId", grievance.userid);

                    var result = await con.QueryAsync<HouseholdcatagoryDto>(Query, param, commandType: CommandType.StoredProcedure);
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
