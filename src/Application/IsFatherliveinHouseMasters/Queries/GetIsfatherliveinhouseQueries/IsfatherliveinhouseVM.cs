using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsFatherliveinHouseMasters.Queries.GetIsfatherliveinhouseQueries
{
    public  class IsfatherliveinhouseVM
    {
        public IList<IsfatherliveinhouseDto> Lists { get; set; }
        public int id { get; set; }
        public string isfatherliveinhouse { get; set; }
        public string description { get; set; }
    }
}
