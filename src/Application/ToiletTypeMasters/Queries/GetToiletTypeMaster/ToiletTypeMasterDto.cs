using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ToiletTypeMasters.Queries.GetToiletTypeMaster
{
    public class ToiletTypeMasterDto : IMapFrom<ToiletType>
    {
        public ToiletTypeMasterDto()
        {
        }
        public string typename { get; set; }
        public string description { get; set; }
        public int typeid { get; set; }
        public bool deletedflag { get; set; }
    }
}