using SRIS.Application.PMT.PMTExecution.Queries.GetParameterItem;
using SRIS.Application.PMT.PMTExecution.Queries.GetPMTResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IPMTService
    {
        Task<int> PMTExecution(ParameterDto objPMT);
        Task<List<PMTResultDto>> GetPMTResult(string action, string locationid, int surveyid, int pmtconfigureid);
        Task<List<PMTCategoryWiseCountDto>> GetPMTCategoryWiseCount(string action, string locationid, int surveyid,  int pmtconfigureid);
        Task<List<PMTResultParameterDto>> GetParameterWisePMTResult(int resultid);
        Task<List<PMTReportWiseCountDto>> GetPMTReport(string action, string locationid, int surveyid, int pmtconfigureid);
    }
}
