using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignDevice.Queries;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Persistence.Service
{
   public class AssignDeviceService : BaseRepository, IAssignedDeviceService
    {
        private readonly IConnectionFactory _connectionFactory;
        public AssignDeviceService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<AssignDeviceDto>> IAssignedDeviceService.GetAssignDevice(AssignDeviceDto AssignEA)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_assigneddevice";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", AssignEA.action);
                    param.Add("p_searchid", AssignEA.searchid);
                    var result = await con.QueryAsync<AssignDeviceDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AssignDevice(AssignDeviceDto assignDevice)
        {
            try
            {
                string AssignDeviceXML = CommonHelper.SerializeToXMLString(assignDevice.Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", assignDevice.action);
                objParam.Add("p_planid", assignDevice.planid);
                objParam.Add("p_regionid", assignDevice.regionid);
                objParam.Add("p_usertypeid", assignDevice.usertypeid);
                objParam.Add("p_userid", assignDevice.userid);
                objParam.Add("p_deviceid", assignDevice.deviceid);
                objParam.Add("p_createdby", assignDevice.createdby);
                objParam.Add("p_assigndeviceid", assignDevice.deviceassignid);
                objParam.Add("p_assignDeviceXML", AssignDeviceXML);
                objParam.Add("p_output", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_assigndevice_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_output");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> AssignDeviceList(IList<AssignDeviceDto> assignDeviceList)
        {
            int result = 0;
            foreach (var location in assignDeviceList)
            {
                result = await AssignDevice(location);
            }
            return result;
        }
    }
}
