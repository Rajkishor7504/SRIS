using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Feedback.Benificiary.Queries;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Common;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Service
{
   public class FeedbackService : BaseRepository, IFeedbackService
    {
        private readonly IConnectionFactory _connectionFactory;
        public FeedbackService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<BenificiaryDto>> IFeedbackService.GetBenificiary(BenificiaryDto benificiaryDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_feedbackdtls";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", benificiaryDto.action);
                    param.Add("p_datarequest_id", benificiaryDto.datarequest_id);
                    param.Add("p_userid", benificiaryDto.userid);
                    var result = await con.QueryAsync<BenificiaryDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddBeneficiaryNotification(NotificationMasterDto objPaymentDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "BF");
                objParam.Add("p_requeststatus", objPaymentDto.NotificationStatus);
                objParam.Add("p_information", objPaymentDto.Information);
                objParam.Add("p_remarks", "");
                objParam.Add("p_createdby", objPaymentDto.CreatedBy);
                objParam.Add("p_destinationURL", objPaymentDto.DestinationURL);
                objParam.Add("p_requestId", objPaymentDto.CreatedBy);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateBeneficiaryNotification(NotificationMasterDto objPaymentDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "BFU");
                objParam.Add("p_requestId", objPaymentDto.refNo);
                objParam.Add("p_requeststatus", objPaymentDto.NotificationStatus);
                objParam.Add("p_createdby", objPaymentDto.CreatedBy);
                objParam.Add("p_remarks", "");
                objParam.Add("p_information", "");
                objParam.Add("p_destinationURL", "");
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                var result = await Connection.ExecuteAsync("usp_allnotification_data", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> AddBenificiaryDetails(BenificiaryDto objBenificiaryDto)
        {
            try
            {
                string benificiaryxml = CommonHelper.SerializeToXMLString(objBenificiaryDto.Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objBenificiaryDto.action);
                objParam.Add("p_createdby", objBenificiaryDto.createdby);
                objParam.Add("p_benificiaryXML", benificiaryxml);
                objParam.Add("p_programname", objBenificiaryDto.programname);
                objParam.Add("p_programcode", objBenificiaryDto.programcode);
                objParam.Add("p_programid", objBenificiaryDto.programid);
                objParam.Add("p_filename", objBenificiaryDto.filename);
                objParam.Add("p_programdid", objBenificiaryDto.programdetailsid);
                objParam.Add("p_remark", objBenificiaryDto.remark);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

              var result= await Connection.ExecuteAsync("usp_feedback_benificiarydtls_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
