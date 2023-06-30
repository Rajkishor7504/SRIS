using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Feedback.Payment.Queries;
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
   public class PaymentService : BaseRepository, IPaymentService
    {
        private readonly IConnectionFactory _connectionFactory;
        public PaymentService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async Task<List<PaymentDto>> IPaymentService.GetPaymentDetails(PaymentDto objPaymentDto)
        {
            try
            {
                using (IDbConnection con = _connectionFactory.GetConnection)
                {
                    string Query = "usp_get_feedbackdtls";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_action", objPaymentDto.action);
                    param.Add("p_datarequest_id", 0);
                    param.Add("p_userid", objPaymentDto.userid);
                    var result = await con.QueryAsync<PaymentDto>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddPaymentNotification(NotificationMasterDto objPaymentDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "PF");
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
        public async Task<int> UpdatePaymentNotification(NotificationMasterDto objPaymentDto)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "PFU");
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
        public async Task<int> AddPayment(PaymentDto objPaymentDto)
        {
            try
            {
                string benificiaryxml = CommonHelper.SerializeToXMLString(objPaymentDto.Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", objPaymentDto.action);
                objParam.Add("p_createdby", objPaymentDto.createdby);
                objParam.Add("p_paymentXML", benificiaryxml);
                objParam.Add("p_programname", objPaymentDto.programname);
                objParam.Add("p_programcode", objPaymentDto.programcode);
                objParam.Add("p_programid", objPaymentDto.programid);
                objParam.Add("p_filename", objPaymentDto.filename);
                objParam.Add("p_programdid", objPaymentDto.programdetailsid);
                objParam.Add("p_remark", objPaymentDto.remark);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);

                var result = await Connection.ExecuteAsync("usp_feedback_paymentdetails_aed", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
