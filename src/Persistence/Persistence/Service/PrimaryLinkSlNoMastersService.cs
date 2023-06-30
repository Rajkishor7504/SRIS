using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PrimaryLinkSlNoMasters.Queries.GetPrimayLinkSlNoMaster;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 namespace SRIS.Persistence.Service
{
    public class PrimaryLinkSlNoMastersService : BaseRepository, IPrimaryLinkSlNoService
    {
        private readonly IConnectionFactory _connectionFactory;
        public PrimaryLinkSlNoMastersService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// List Based Calls
        /// </summary>
        /// <returns></returns>
        async Task<List<PrimayLinkSlNoMasterDto>> IPrimaryLinkSlNoService.GetPrimaryLinks()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_getprimarylinksslno";
                    con.Open();
                    var result = await con.QueryAsync<PrimayLinkSlNoMasterDto>(Query, commandType: CommandType.StoredProcedure);
                    return result.Where(pl => !pl.deletedflag).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdatePrimayLinkSlNo(PrimayLinkSlNoMasterDto PrimayLinkSlNo)
        {
            string slnoxml = CommonHelper.SerializeToXMLString(PrimayLinkSlNo.Lists);
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", PrimayLinkSlNo.action);
                objParam.Add("p_plinkid", PrimayLinkSlNo.plinkid);
                objParam.Add("p_slno", PrimayLinkSlNo.slno);
                objParam.Add("p_createdby", PrimayLinkSlNo.createdby);
                objParam.Add("p_slnoxml", slnoxml);
                //objParam.Add("p_status", PrimayLinkSlNo.status);
                objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = Connection.ExecuteAsync("usp_primarylink_u", objParam, null, null, CommandType.StoredProcedure);
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
