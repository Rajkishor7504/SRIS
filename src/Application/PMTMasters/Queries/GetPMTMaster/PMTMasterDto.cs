using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PMTMasters.Queries.GetPMTMaster
{
    public class PMTMasterDto : IMapFrom<PmtMasterN>
    {
        public PMTMasterDto()
        {

        }
        public int categoryid { get; set; }
        public string category { get; set; }

        public Decimal min_value { get; set; }
        public Decimal max_value { get; set; }
        public Boolean deletedflag { get; set; }

    }
}
