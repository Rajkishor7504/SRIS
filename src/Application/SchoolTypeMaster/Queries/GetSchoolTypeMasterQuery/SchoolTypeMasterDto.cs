using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SchoolTypeMaster.Queries.GetSchoolTypeMasterQuery
{
    public class SchoolTypeMasterDto : IMapFrom<TypeOfSchoolEntities>
    {
        public int schooltypeid { get; set; }
        public string typeofschool { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
