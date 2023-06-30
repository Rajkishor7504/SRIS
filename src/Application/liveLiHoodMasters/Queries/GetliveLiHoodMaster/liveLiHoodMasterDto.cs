using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.liveLiHoodMasters.Queries.GetliveLiHoodMaster
{
    public class liveLiHoodMasterDto : IMapFrom<LiveliHood>
    {
        public liveLiHoodMasterDto()
        {
        }
        public int livelihoodid { get; set; }
        public string livelihoodname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}