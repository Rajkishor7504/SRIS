using SRIS.Application.SurveyPlanning.AssignDevice.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IAssignedDeviceService
    {
        Task<List<AssignDeviceDto>> GetAssignDevice(AssignDeviceDto AssignEA);
        Task<int> AssignDevice(AssignDeviceDto AssignEA);
        Task<int> AssignDeviceList(IList<AssignDeviceDto> AssignEA);
    }
}
