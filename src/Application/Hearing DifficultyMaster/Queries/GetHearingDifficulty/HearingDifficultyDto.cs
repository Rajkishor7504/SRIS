﻿using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Hearing_DifficultyMaster.Queries.GetHearingDifficulty
{
  public  class HearingDifficultyDto: IMapFrom<HearingDifficulty>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
