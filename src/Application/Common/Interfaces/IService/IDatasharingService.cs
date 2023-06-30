using SRIS.Application.DataSharing.Queries;
using SRIS.Application.Feedback.Payment.Queries;
using SRIS.Application.Feedback.UpdateBenificiaryExit.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
    public interface IDatasharingService
    {
       
        Task<IList<GetHouseholdVM>> DatasharingList(DataSharingQuery dataSharinglist);
        Task<IList<GetGouseholdrestdataVM>> HouseholdrestdataList(DataSharingQuery dataSharinglist);
        Task<string> Updatehouseholdbenificiary(ExternalPaymentDto obj);
        Task<string> addexitbenificiarymember(ExitBenificiaryDto obj);
    }
}
