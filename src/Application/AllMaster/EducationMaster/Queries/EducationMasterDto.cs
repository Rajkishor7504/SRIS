using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.EducationMaster.Queries
{
    public class EducationMasterDto
    {
    }
    public class EducationMasterVM
    {      

        public List<CommonEducationMasterDto> neverAttendSchool { get; set; }
        public List<CommonEducationMasterDto> levelGrade { get; set; }
        public List<CommonEducationMasterDto> stopGoingScl { get; set; }

        public List<CommonEducationMasterDto> schoolattended { get; set; }
        public List<CommonEducationMasterDto> levelGradecompleted { get; set; }
        public List<CommonEducationMasterDto> readwrite { get; set; }
    }
    public class EducationMasterResponse : CommonMobileApiStatus
    {
        public EducationMasterVM educationMaster { get; set; }
    }
}
