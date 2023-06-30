using SRIS.Application.SurveyPlanning.EnumeratorProfile.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IEnumeratorProfileService
    {
        Task<int> AddEnumerator(EnumeratorProfileDto MyUser);
        Task<List<EnumeratorProfileDto>> GetEnumerator(EnumeratorProfileDto SurveyPlanning);
    }
}
