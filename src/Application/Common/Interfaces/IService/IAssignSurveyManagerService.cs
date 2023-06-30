using SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Query.GetassignSurveyManagerItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IAssignSurveyManagerService
    {
        Task<List<AssignSurveyManagerDto>> Getsurveymanagerdetails(AssignSurveyManagerDto mysurveymangdetails);
        Task<int> Createsurveymanager(AssignSurveyManagerDto obj);
        Task<int> deletesurveymanag(int? asignmangid);
    }
}
