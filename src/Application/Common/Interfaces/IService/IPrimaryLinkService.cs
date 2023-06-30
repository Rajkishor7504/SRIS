using SRIS.Application.PrimaryLinkMasters.Queries.GetPrimaryLinkMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IPrimaryLinkService
    {
        Task<List<PrimaryLinkMasterDto>> GetPrimaryLinks();
    }
}
