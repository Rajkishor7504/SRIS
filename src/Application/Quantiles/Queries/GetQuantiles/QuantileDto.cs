using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Quantiles.Queries.GetQuantiles
{
   public class QuantileDto : IMapFrom<Quantile>
    {
        public QuantileDto()
        {
        }
        public int id { get; set; }
        public string quantile { get; set; }
    }
}
