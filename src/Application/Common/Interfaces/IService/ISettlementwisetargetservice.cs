using SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Queries.GetSettlementWiseTargetMasterQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface ISettlementwisetargetservice
    {
        Task<List<SettlementWiseTargetDto>> Geteanumber(SettlementWiseTargetDto eano);
        Task<int> Createsettlementwisetarget(SettlementWiseTargetDto obj);
        Task<int> Updatesettlementwisetarget(SettlementWiseTargetDto obj);
    }
}
