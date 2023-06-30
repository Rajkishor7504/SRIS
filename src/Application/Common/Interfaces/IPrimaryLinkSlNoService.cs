using SRIS.Application.PrimaryLinkSlNoMasters.Queries.GetPrimayLinkSlNoMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IPrimaryLinkSlNoService
    {
        Task<List<PrimayLinkSlNoMasterDto>> GetPrimaryLinks();
        Task<int> UpdatePrimayLinkSlNo(PrimayLinkSlNoMasterDto PrimayLinkSlNo);
    }
}
