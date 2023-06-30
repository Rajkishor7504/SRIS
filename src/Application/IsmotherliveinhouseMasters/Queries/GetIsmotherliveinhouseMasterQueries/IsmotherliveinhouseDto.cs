using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsmotherliveinhouseMasters.Queries.GetIsmotherliveinhouseMasterQueries
{
    public class IsmotherliveinhouseDto : IMapFrom<Ismotherliveinhouse>
    {
        public int id { get; set; }
        public string ismotherliveinhouse { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
