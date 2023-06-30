using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.IncomeSourceMasters.Queries.GetIncomeSourceMaster
{
    public class IncomeSourceMasterDto : IMapFrom<MainIncomeSource>
    {
        public IncomeSourceMasterDto()
        {
        }
        public bool deletedflag { get; set; }
        public string description { get; set; }
        public string incomesourcename { get; set; }
        public int incomesourceid { get; set; }
    }
}