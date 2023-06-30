using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.SecondIncomeSourceMaster.Queries.GetSecondIncomeSourceMasterQuery
{
    public class SecondIncomeSourceDto : IMapFrom<SecondIncomeSourceMasterEntity>
    {
        public int secondincomesourceid { get; set; }
        public string secondincomesourcename { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
