using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.GlobalLinkSlNoMasters.Queries.GetGlobalLinkSlNoMaster;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    public class GlobalLinkSlNoMastersService : BaseRepository, IGlobalLinkSlNoService
    {
        private readonly IConnectionFactory _connectionFactory;
        public GlobalLinkSlNoMastersService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<GlobalLinkSlNoMasterDto>> IGlobalLinkSlNoService.GetGlobalLinks()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getgloballinksslno";
                    con.Open();
                    var result = await con.QueryAsync<GlobalLinkSlNoMasterDto>(Query, commandType: CommandType.StoredProcedure);
                    return result.Where(pl => !pl.deletedflag).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateGlobalLinkSlNo(GlobalLinkSlNoMasterDto GlobalLinkSlNo)
        {
            string slnoxml = CommonHelper.SerializeToXMLString(GlobalLinkSlNo.Lists);
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", GlobalLinkSlNo.action);
                objParam.Add("p_glinkid", GlobalLinkSlNo.glinkid);
                objParam.Add("p_gslno", GlobalLinkSlNo.gslno);
                objParam.Add("p_createdby", GlobalLinkSlNo.createdby);
                objParam.Add("p_slnoxml", slnoxml);
                //objParam.Add("p_status", PrimayLinkSlNo.status);
                objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = Connection.ExecuteAsync("usp_globallink_u", objParam, null, null, CommandType.StoredProcedure);
                // return await result;
                return objParam.Get<int>("p_output");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        //public async Task<int> UpdatePrimayLinkSlNo1(IList<PrimayLinkSlNoMasterDto> PrimayLinkSlNoMasterlist)
        //{
        //    int result = 0;
        //    foreach (var primayLinkSl in PrimayLinkSlNoMasterlist)
        //    {
        //        result += await UpdatePrimayLinkSlNo(primayLinkSl);
        //    }
        //    return result;
        //}
    }
}