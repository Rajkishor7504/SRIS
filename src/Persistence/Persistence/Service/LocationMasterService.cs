using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.LocationMaster.Queries.GetLocationMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
    #region------------------location using Linq------------------------
    public class LocationMasterService :  ILocationMasterService
    {
        private readonly IApplicationDbContext _context;

        public LocationMasterService(IApplicationDbContext context)
        {
            _context = context;
        }
      
      public  async Task<List<lgaDto>> GetLevelData()
        {
            try
            {
                var lgaData = await _context.m_adm_leveldetails.Where(g => !g.deletedflag && g.levelid == 1)
                    .Select(a => new lgaDto {
                        id = a.leveldetailid,
                        lgaName = a.levelname })
                    .OrderBy(t => t.lgaName).ToListAsync();
                return lgaData;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DistrictDto>> GetDistrictData()
        {
            try
            {
                var lgaData = await _context.m_adm_leveldetails.Where(g => !g.deletedflag && g.levelid == 2)
                .Select(a => new  { 
                    id = a.leveldetailid, 
                    lgaName = a.levelname,
                    parentid=a.parentid})
                .ToListAsync();
          
                var distdata = (from a in  lgaData                             
                            select new DistrictDto
                            {
                                distId = a.id,
                                lgaId = a.parentid,
                                //distName = GetLevelNameById(a.id),
                                distName = !string.IsNullOrEmpty(a.lgaName) ? a.lgaName : "",
                            }).ToList();
                if(distdata!=null)
                {
                    return distdata;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       

      

       

    public  async  Task<List<WardDto>> GetWardData()
        {
            try
            {
                var leveldetails = await _context.m_adm_leveldetails.Where(g => !g.deletedflag).ToListAsync();
            var lgaData =  leveldetails.Where(g => g.levelid == 3).ToList();
            var dist  = leveldetails.Where(g => g.levelid == 2).ToList();

            var distdata = (from a in lgaData   
                           join b in dist on a.parentid equals b.leveldetailid
                            select new WardDto
                            {
                                id=a.leveldetailid      ,                         
                                distId = a.parentid,
                                lgaId= GetDistParentIdBylvelId(b.leveldetailid),
                                wardName = !string.IsNullOrEmpty(a.levelname) ? a.levelname : "",
                            }).ToList();
            return distdata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
     public async  Task<List<SettlementDto>> GetSettlementData()
        {
            try
            {
                var leveldetails = await _context.m_adm_leveldetails.Where(g => !g.deletedflag).ToListAsync();
            var lgaData = leveldetails.Where(g =>  g.levelid == 4).ToList();
            var ward = leveldetails.Where(g =>  g.levelid == 3).ToList();
           
            var distdata = (from a in lgaData
                            join b in ward on a.parentid equals b.leveldetailid                           
                            select new SettlementDto
                            {
                                id = a.leveldetailid,
                                wardId = a.parentid,
                                distId = GetDistParentIdBylvelId(b.leveldetailid),
                               lgaId= GeLeveldataById(b.leveldetailid),
                                settlementName = !string.IsNullOrEmpty(a.levelname) ? a.levelname : "",
                            }).ToList();
            return distdata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region-------Method-------------
        public int GetDistParentIdBylvelId(int id)
        {
            var leveldetails = _context.m_adm_leveldetails.Where(g => !g.deletedflag).ToList();
            var levelid = leveldetails.Where(g => g.leveldetailid == id).FirstOrDefault();   
            if(levelid!=null)
            {
                return levelid.parentid;
            }
            return 0;

        }
       
        public int GeLeveldataById(int id)
        {
            var leveldetails =  _context.m_adm_leveldetails.Where(g => !g.deletedflag).ToList();
            var distparentid = leveldetails.Where(g => g.leveldetailid == id).FirstOrDefault().parentid;
            var levelid = leveldetails.Where(g => g.leveldetailid == distparentid).FirstOrDefault();  
            if(levelid!=null)
            {
                return levelid.parentid;
            }
            return  0;
        }

        //public string GetLevelNameById(int id)
        //{
        //    var DistrictId = _context.m_adm_leveldetails.Where(g => !g.deletedflag && g.leveldetailid == id).FirstOrDefault();

        //    return !string.IsNullOrEmpty(DistrictId.levelname) ? DistrictId.levelname : "";

        //}
        #endregion
    }
    #endregion

    #region------------------location using Store procedure------------------------

    public class LocationMasterServiceM : BaseRepository, ILocationMasterServiceM
    {
        private readonly Application.Common.Interfaces.IConnectionFactory _connectionFactory;
        public LocationMasterServiceM(Application.Common.Interfaces.IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<List<lgaDto>> GetLevelData()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_locationmasterM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", 'L');
                    var result = await con.QueryAsync<lgaDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DistrictDto>> GetDistrictData()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_locationmasterM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", 'D');
                    var result = await con.QueryAsync<DistrictDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

       

        public async Task<List<WardDto>> GetWardData()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_locationmasterM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", 'W');
                    var result = await con.QueryAsync<WardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SettlementDto>> GetSettlementData()
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_locationmasterM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", 'S');
                    var result = await con.QueryAsync<SettlementDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    #endregion
    
        #region
    public class EnumeratorLocationMasterServiceCM : BaseRepository, IEnumeratorLocationMasterServiceCM
    {
        private readonly Application.Common.Interfaces.IConnectionFactory _connectionFactory;
        public EnumeratorLocationMasterServiceCM(Application.Common.Interfaces.IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<lgaDto>> GetClusterLevelData(int planid, int clno)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    //string Query = "usp_hhr_enumeratorlocationM_v";
                    string Query = "Usp_GetLocationM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_planid", planid);
                    param.Add("p_cn", clno);
                    var result = await con.QueryAsync<lgaDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DistrictDto>> GetClusterDistrictData(int planid, int clno, int lga)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    //string Query = "usp_hhr_enumeratorlocationM_v";
                    string Query = "Usp_GetDistrictM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_planid", planid);
                    param.Add("p_cno", clno);
                    param.Add("p_lga", lga);
                    var result = await con.QueryAsync<DistrictDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<WardDto>> GetClusterWardData(int clno, int lga, int dis)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    //string Query = "usp_hhr_enumeratorlocationM_v";
                    string Query = "Usp_GetWardM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_cno", clno);
                    param.Add("p_lga", lga);
                    param.Add("p_dis", dis);
                    var result = await con.QueryAsync<WardDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SettlementDto>> GetClusterSettlementData(int clno, int lga, int dis, int ward)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    //string Query = "usp_hhr_enumeratorlocationM_v"
                    string Query = "Usp_GetSettlementM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_cno", clno);
                    param.Add("p_lga", lga);
                    param.Add("p_dis", dis);
                    param.Add("p_wad", ward);
                    var result = await con.QueryAsync<SettlementDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EnumerationSurveyPlan>> GetEnumerationData(string action, int userid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_enumeratorlocationM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_euserid", userid);
                    var result = await con.QueryAsync<EnumerationSurveyPlan>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ClusterNumber>> GetClusterNo(string action, int planid)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_hhr_enumeratorlocationM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", action);
                    param.Add("p_euserid", planid);
                    var result = await con.QueryAsync<ClusterNumber>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EnumerationEAModel>> GetEnumerationEAData(int clno, int lga, int dis, int ward, int settlement)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "Usp_GetEnumerationM_v";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_cno", clno);
                    param.Add("p_lga", lga);
                    param.Add("p_dis", dis);
                    param.Add("p_wad", ward);
                    param.Add("p_set", settlement);
                    var result = await con.QueryAsync<EnumerationEAModel>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
        #endregion
    }
