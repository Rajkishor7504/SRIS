using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.EmployementMasterAPI.Queries.GetEmployeementAllMaster
{
   public class EmployementMasterVM
    {
        public List<CommonEmployementMasterDto> mainJobActiviy { get; set; }
        public List<CommonEmployementMasterDto> workingFrequency { get; set; }
        public List<CommonEmployementMasterDto> workingSector { get; set; }
        public List<CommonEmployementMasterDto> workingStatus { get; set; }
        public List<CommonEmployementMasterDto> notWorkingReason { get; set; }
    }
    public class EmployementMasterResponse : CommonMobileApiStatus
    {
        public EmployementMasterVM employementMaster { get; set; }
    }
}
