using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DisposeRubbishMasters.Queries.GetDisposeRubbishMaster
{
   public  class DisposeRubbishMasterDto : IMapFrom<DisposeRubbish>
    {
        public DisposeRubbishMasterDto()
        {
        }
        public string disposename { get; set; }
        public string description { get; set; }
        public int disposeid { get; set; }
        public bool deletedflag { get; set; }
    }
}