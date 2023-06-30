using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.CopingTypeMaster.Queries.GetCopingTypeQuery
{
    public class CopingTypeMasterDto : IMapFrom<CopingTypeMasterEntity>
    {
        public int copingtypeid { get; set; }
        public string copingtypename { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
