using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.EcologyMaster.Queries.GetEcologyTypeMasterQuery
{
    public class EcologyMasterDto:IMapFrom<EcologyMasterEntity>
    {
        public int type_id { get; set; }
        public string type_name { get; set; }
        public bool deletedflag { get; set; }
    }
}
