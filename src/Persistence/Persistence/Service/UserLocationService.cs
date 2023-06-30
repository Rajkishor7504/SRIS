using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class UserLocationService: BaseRepository, IUserLocationService
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserLocationService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> adduserloca(UMUserLocationDto obj)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string adduserlocxml = CommonHelper.SerializeToXMLString(obj.Lists);
                    DynamicParameters objParam = new DynamicParameters();
                    //objParam.Add("p_action", obj.action);
                    //objParam.Add("p_role", obj.roleid);
                    //objParam.Add("p_user", obj.userid);
                    objParam.Add("p_createdby", obj.createdby);
                    //objParam.Add("p_tagloc", "");
                    objParam.Add("p_userlocxml", adduserlocxml);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = Connection.ExecuteAsync("usp_userlocation_add", objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_output");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        async Task<List<UMUserLocationDto>> IUserLocationService.Getuserlocation(UMUserLocationDto userloc)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_userlocation_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", userloc.action);
                    param.Add("searchid", userloc.p_id);
                    param.Add("leveldtlsid", 0);
                    param.Add("puserId", userloc.userid);

                    var result = await con.QueryAsync<UMUserLocationDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        async Task<List<UMUserLocationDto>> IUserLocationService.GetuserlocationByID(int userid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_userlocation_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("action", "gdi");
                    param.Add("searchid", userid);
                    param.Add("leveldtlsid", 0);
                    param.Add("puserId", 0);
                    var result = await con.QueryAsync<UMUserLocationDto>(Query, param, commandType: CommandType.StoredProcedure);
                    //var data = result.Count[0];
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> deleteloc(int? ulocid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    DynamicParameters objParam = new DynamicParameters();
                    //objParam.Add("p_action", "D");
                    objParam.Add("p_ulocid", ulocid);
                    objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                    var result = Connection.ExecuteAsync("usp_deluserloc", objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_output");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}


