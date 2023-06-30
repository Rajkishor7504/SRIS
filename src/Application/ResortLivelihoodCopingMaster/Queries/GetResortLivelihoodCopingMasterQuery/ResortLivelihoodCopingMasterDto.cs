using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ResortLivelihoodCopingMaster.Queries.GetResortLivelihoodCopingMasterQuery
{
    public class ResortLivelihoodCopingMasterDto : IMapFrom<ResortLivelihoodCopingMasterEnity>
    {
        public int resortlivelyhoodcopingid { get; set; }
        public string resortlivelyhoodcoping { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
