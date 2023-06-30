using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PurposeMaster.Queries.GetPurposeMaster
{
   public class PurposeMasterDto : IMapFrom<Purpose>
    {
        public PurposeMasterDto()
        {
        }
        public int purposeid { get; set; }
        public string purposename { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}