using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.WorkingSectors.Queries.GetWorkingSectorMaster
{
    public class WorkingSectorDto : IMapFrom<WorkingSector>
    {
        [Key]
        public int sectorid { get; set; }
        public string sectorname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
