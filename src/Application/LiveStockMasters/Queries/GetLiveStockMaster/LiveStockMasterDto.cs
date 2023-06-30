using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.LiveStockMasters.Queries.GetLiveStockMaster
{
    public class LiveStockMasterDto : IMapFrom<LiveStock>
    {
        public LiveStockMasterDto()
        {
        }
        public string description { get; set; }
        public string livestockname { get; set; }
        public int livestockid { get; set; }
        public bool deletedflag { get; set; }
    }
}
