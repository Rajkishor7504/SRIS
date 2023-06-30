using SRIS.Application.FeedbackReport.BenificiaryPaymentReport.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService.Feedback
{
   public interface IBenificiaryPaymentReportService
    {
        Task<List<BenificiaryPaymentReportDto>> BenificiaryPaymentReport(BenificiaryPaymentReportDto benificiaryPaymentReportDto);
       // Task<IList<BenificiaryPaymentReportDto>> BenificiaryPaymentReport(GetBenificiaryPaymentReportQuery benificiaryPaymentReportDto);
    }
}
