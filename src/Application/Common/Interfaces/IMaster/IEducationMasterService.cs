using SRIS.Application.AllMaster.EducationMaster.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IEducationMasterService
    {
        Task<List<CommonEducationMasterDto>> GetNeverAttendSchoolData();
        Task<List<CommonEducationMasterDto>> GetGradeData();
        Task<List<CommonEducationMasterDto>> GetReasonForStopSchoolData();

        //22-05-23 added
        Task<List<CommonEducationMasterDto>> GetTypeOfSchoolAttendedData();
        Task<List<CommonEducationMasterDto>> GetLevelCompletedData();
        Task<List<CommonEducationMasterDto>> GetTypeOfReadWriteData();

    }
}
