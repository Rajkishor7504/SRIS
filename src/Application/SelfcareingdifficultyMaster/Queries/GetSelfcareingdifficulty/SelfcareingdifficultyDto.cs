using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SelfcareingdifficultyMaster.Queries.GetSelfcareingdifficulty
{
    public class SelfcareingdifficultyDto: IMapFrom<Selfcareingdifficulty>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
