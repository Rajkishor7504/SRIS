using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsMotherstillaliveItems.Queries.GetIsmotherstillalivequeries
{
   public  class IsmotherstillaliveDto : IMapFrom<Ismotherstillalive>
    {
        public int id { get; set; }
        public string ismotherstillalive { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
