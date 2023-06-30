using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IGrievanceResolutionService
    {
        Task<List<GrievanceResolutionMasterDto>> Getgrievance(GrievanceResolutionMasterDto grievance);
    }
}
