using SRIS.Application.Feedback.Payment.Queries;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IPaymentService
    {
        Task<List<PaymentDto>> GetPaymentDetails(PaymentDto objPaymentDto);
        Task<int> AddPaymentNotification(NotificationMasterDto objPaymentDto);
        Task<int> UpdatePaymentNotification(NotificationMasterDto objPaymentDto);
        Task<int> AddPayment(PaymentDto objPaymentDto);
    }
}
