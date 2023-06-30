using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.LastLevelGradeMaster.Queries.GetLastLevelGradeMasterQuery
{
    public class LastLevelGradeMasterDto : IMapFrom<LastLevelGradeMasterEntity>
    {
        public int lastlevelid { get; set; }
        public string lastlevelname { get; set; }
        public bool deletedflag { get; set; }
    }
}
