using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsFatherliveinHouseMasters.Queries.GetIsfatherliveinhouseQueries
{
    public class IsfatherliveinhouseDto : IMapFrom<Isfatherliveinhouse>
    {
        public int id { get; set; }
        public string isfatherliveinhouse { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
