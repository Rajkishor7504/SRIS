using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ResidenceMasters.Queries.GetResidenceMaster
{
    public class ResidenceMasterDto : IMapFrom<ResidenceMaster>
    {
        public ResidenceMasterDto()
        {
        }

        public string residencename { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public bool deletedflag { get; set; }
    }
}
