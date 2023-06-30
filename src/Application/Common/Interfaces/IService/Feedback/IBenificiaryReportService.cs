using SRIS.Application.FeedbackReport.BenificiaryReport.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService.Feedback
{
    public interface IBenificiaryReportService
    {
        Task<List<BenificiaryReportDto>> GetBenificiaryReport(BenificiaryReportDto benificiaryReportDto);
    }
}
