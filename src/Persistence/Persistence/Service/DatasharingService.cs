using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.DataSharing.Queries;
using SRIS.Application.Feedback.Payment.Queries;
using SRIS.Application.Feedback.UpdateBenificiaryExit.Queries;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
    class DatasharingService : BaseRepository, IDatasharingService
    {
        private readonly IConnectionFactory _connectionFactory;
        public DatasharingService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> addexitbenificiarymember(ExitBenificiaryDto obj)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("P_programcode", obj.programmecode);
                objParam.Add("P_benificiarynumber", obj.benificiarynumber);
                objParam.Add("P_exittype", obj.exittype );
                objParam.Add("P_exitdate", obj.exiteddate);
                objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_benificiary_exit", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<string>("p_output");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<GetHouseholdVM>> DatasharingList(DataSharingQuery dataSharinglist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_datasharing_gethouseholdlist";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("P_programcode", dataSharinglist.programcode);
                    param.Add("p_rid", dataSharinglist.lga == "" ? "" : dataSharinglist.lga);
                    param.Add("p_did", dataSharinglist.district == "" ? "" : dataSharinglist.district);
                    param.Add("p_wid", dataSharinglist.ward == "" ? "" : dataSharinglist.ward);
                    param.Add("p_sid", dataSharinglist.town == "" ? "" : dataSharinglist.town);
                    param.Add("p_restdatareq", dataSharinglist.restdatarequired);
                    var result = await con.QueryAsync<GetHouseholdVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<GetGouseholdrestdataVM>> HouseholdrestdataList(DataSharingQuery dataSharinglist)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_datasharing_gethouseholdlist";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("P_programcode", dataSharinglist.programcode);
                    param.Add("p_rid", dataSharinglist.lga);
                    param.Add("p_did", dataSharinglist.district);
                    param.Add("p_wid", dataSharinglist.ward);
                    param.Add("p_sid", dataSharinglist.town);
                    param.Add("p_restdatareq", dataSharinglist.restdatarequired);
                    var result = await con.QueryAsync<GetGouseholdrestdataVM>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Updatehouseholdbenificiary(ExternalPaymentDto obj)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("P_programname", obj.programname);
                objParam.Add("P_programcode", obj.programcode);
                objParam.Add("P_username", obj.username);
                objParam.Add("P_remark",obj.remark );
                objParam.Add("P_filename",obj.filename );
                objParam.Add("P_documentType", obj.documentType);
                objParam.Add("p_output", null, DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_datasharing_updatehouseholdbenificiary", objParam, null, null,CommandType.StoredProcedure);
                return objParam.Get<string>("p_output");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

