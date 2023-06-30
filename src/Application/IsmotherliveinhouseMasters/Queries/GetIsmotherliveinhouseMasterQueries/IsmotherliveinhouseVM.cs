using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsmotherliveinhouseMasters.Queries.GetIsmotherliveinhouseMasterQueries
{
    public class IsmotherliveinhouseVM
    {
        public IList<IsmotherliveinhouseDto> Lists { get; set; }
        public int id { get; set; }
        public string ismotherliveinhouse { get; set; }
        public string description { get; set; }
    }
}
