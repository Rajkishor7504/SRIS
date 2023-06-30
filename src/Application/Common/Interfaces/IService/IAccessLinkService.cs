using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster;

namespace SRIS.Application.Common.Interfaces
{
    public interface IAccessLinkService
    {
        Task<List<AccessLinkMasterDto>> GetUserAccessLinks(int userid);

        Task<int> AddAccessLinks(AccessLinkMasterDto AccessLink);

        Task<AccessLinkMasterDto> GetUserAccessLink(int? AccessLinkId);

        Task<int> DeleteAccessLink(int? AccessLinkId);

        Task UpdateAccessLink(AccessLinkMasterDto AccessLink);
    }
}
