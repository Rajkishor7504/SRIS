using SRIS.Application.GlobalLinkSlNoMasters.Queries.GetGlobalLinkSlNoMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IGlobalLinkSlNoService
    {
        Task<List<GlobalLinkSlNoMasterDto>> GetGlobalLinks();
        Task<int> UpdateGlobalLinkSlNo(GlobalLinkSlNoMasterDto GlobalLinkSlNo);
    }
}
