using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IsMotherstillaliveItems.Queries.GetIsmotherstillalivequeries
{
    public class IsmotherstillaliveVM
    {
        public IList<IsmotherstillaliveDto> Lists { get; set; }
        public int id { get; set; }
        public string ismotherstillalive { get; set; }
        public string description { get; set; }
    }
}
