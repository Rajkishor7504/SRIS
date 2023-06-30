using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.ConfigureGrievanceMaster.Queries.GetConfigureGrievanceItem

{
    public class ConfigureGrievanceDto : IMapFrom<ConfigureGrievance>
    {
        [Key]
        public int grievanceconfigid { get; set; }
        public string grievancename { get; set; }
        public string description { get; set; }
        public bool isForward { get; set; }
    }
}
