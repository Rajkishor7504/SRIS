using SRIS.Application.Feedback.Benificiary.Queries;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IFeedbackService
    {
        Task<List<BenificiaryDto>> GetBenificiary(BenificiaryDto benificiaryDto);
        Task<int> AddBeneficiaryNotification(NotificationMasterDto objPaymentDto);
        Task<int> UpdateBeneficiaryNotification(NotificationMasterDto objPaymentDto);
        Task<int> AddBenificiaryDetails(BenificiaryDto objBenificiaryDto);

    }
}
