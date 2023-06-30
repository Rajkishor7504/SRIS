using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AllMaster.HealthMaster.Queries.GetHealthAllMaster
{
   public class HealthMasterDto
    {
    }
    public class HealthMasterVM
    {
        public List<CommonHealthMasterDto> chronicIllness { get; set; }
        public List<CommonHealthMasterDto> seeingDifficulty { get; set; }

        public List<CommonHealthMasterDto> communicatingDifficulty { get; set; }
        public List<CommonHealthMasterDto> selfcareDifficulty { get; set; }
        public List<CommonHealthMasterDto> walkingDifficulty { get; set; }
        public List<CommonHealthMasterDto> hearingDifficulty { get; set; }
        public List<CommonHealthMasterDto> rememberingDifficulty { get; set; }

    }
    public class HealthMasterResponse : CommonMobileApiStatus
    {
        public HealthMasterVM healthMaster { get; set; }
    }
}
