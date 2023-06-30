using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AidTypeMasters.Queries.GetAidTypeMaster
{
    public class AidTypeMasterDto : IMapFrom<AidType>
    {
        public AidTypeMasterDto()
        {
        }
        public string description { get; set; }
        public string aidname { get; set; }
        public int aidid { get; set; }
        public bool deletedflag { get; set; }
    }
}