using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ReadWriteAnyLanguageMaster.Queries.GetReadWriteAnyLanguageMasterQuery
{
    public class ReadWriteAnyLanguageMasterDto : IMapFrom<ReadWriteAnyLanguageMasterEntity>
    {
        public int readwriteid { get; set; }
        public string typeofreadwrite { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
