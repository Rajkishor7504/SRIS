using SRIS.Application.PrimaryLinkAllMastersMasters.Queries.GetPrimaryLinkAllMastersMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IPrimaryLinkAllMastersService
    {
        Task<List<PrimaryLinkAllMastersMasterDto>> GetPrimaryLinks();
    }
}
