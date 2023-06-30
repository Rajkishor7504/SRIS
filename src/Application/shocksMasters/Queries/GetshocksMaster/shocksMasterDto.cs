using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.shocksMasters.Queries.GetshocksMaster
{
    public class shocksMasterDto : IMapFrom<Shocks>
    {
        public shocksMasterDto()
        {
        }
        public int shockid { get; set; }
        public string shockname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}