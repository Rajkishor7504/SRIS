using Dapper;

using SRIS.Application.Common.Interfaces;

using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class GrievanceResolutionService : BaseRepository, IGrievanceResolutionService
    {
        private readonly IConnectionFactory _connectionFactory;
        public GrievanceResolutionService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<GrievanceResolutionMasterDto>> IGrievanceResolutionService. Getgrievance(GrievanceResolutionMasterDto grievance)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_grievanceregistration_casdropdown";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", grievance.action);
                    param.Add("searchid", grievance.p_id);
                    param.Add("leveldtlsid", 0);
                    param.Add("puserId", grievance.userid);

                    var result = await con.QueryAsync<GrievanceResolutionMasterDto>(Query, param, commandType: CommandType.StoredProcedure);
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

