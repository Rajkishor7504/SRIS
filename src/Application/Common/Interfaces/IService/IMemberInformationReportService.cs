using SRIS.Application.MemberInformationReport.Queries.GetMemberInformation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
    public interface IMemberInformationReportService
    {
        Task<List<MemberInformationDto>> GetMemberInformation(MemberInformationDto memberReport);
    }
}
