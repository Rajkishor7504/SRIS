using SRIS.Application.SurveyPlanning.AssignEA.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IAssignEAService
    {
        Task<int> AssignEA(AssignEADto AssignEA);
        Task<List<AssignEADto>> GetAssignEA(AssignEADto AssignEA);
        Task<int> AddEaList(IList<AssignEADto> AssignEA);

    }
}
