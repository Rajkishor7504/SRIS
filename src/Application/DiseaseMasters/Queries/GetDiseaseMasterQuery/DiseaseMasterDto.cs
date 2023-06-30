using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DiseaseMasters.Queries.GetDiseaseMasterQuery
{
    public class DiseaseMasterDto: IMapFrom<Disease>
    {

        public int diseaseid { get; set; }
        public string diseasename { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }

    }
}
