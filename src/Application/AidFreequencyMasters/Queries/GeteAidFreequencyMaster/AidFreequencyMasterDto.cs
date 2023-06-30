using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AidFreequencyMasters.Queries.GeteAidFreequencyMaster
{
    public class AidFreequencyMasterDto : IMapFrom<AidFreequency>
    {
        public AidFreequencyMasterDto()
        {
        }
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public bool deletedflag { get; set; }
    }
}
