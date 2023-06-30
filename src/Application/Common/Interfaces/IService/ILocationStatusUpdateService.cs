using SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface ILocationStatusUpdateService
    {
        Task<List<StatusUpdateDto>> GetStatus(StatusUpdateDto statusupdate);
        Task<int> UpdateStatus(StatusUpdateDto statusupdate);

    }
}
