using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GradeLevelMasters.Queries.GetGradeLevelMaster
{
   public  class GradeMasterDto : IMapFrom<GradeLevelMaster>
    {
        public int gradeid { get; set; }
        public string gradename { get; set; }
        public bool deletedflag { get; set; }
        public string description { get; set; }
    }
}
