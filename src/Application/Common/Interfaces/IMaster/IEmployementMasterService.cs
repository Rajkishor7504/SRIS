using SRIS.Application.AllMaster.EmployementMasterAPI.Queries.GetEmployeementAllMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IMaster
{
    public interface IEmployementMasterService
    {
        Task<List<CommonEmployementMasterDto>> GetmainJobActiviyData();
        Task<List<CommonEmployementMasterDto>> GetworkingFrequencyData();
        Task<List<CommonEmployementMasterDto>> GetworkingSectorData();
        Task<List<CommonEmployementMasterDto>> GetworkingStatusData();
        Task<List<CommonEmployementMasterDto>> GetnotWorkingReasonData();
    }
}
