using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.TransportationModeMasters.Queries.GetTransportationModeMaster
{
    public class TransportationModeMasterDto : IMapFrom<TransportationMode>
    {
        public TransportationModeMasterDto()
        {
        }

        public string modename { get; set; }
        public string description { get; set; }
        public int modeid { get; set; }
        public bool deletedflag { get; set; }
    }
}