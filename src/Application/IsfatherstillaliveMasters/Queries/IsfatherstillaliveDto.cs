using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsfatherstillaliveMasters.Queries
{
    public class IsfatherstillaliveDto : IMapFrom<Isfatherstillalive>
    {

        public int id { get; set; }
        public string isfatherstillalive { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
