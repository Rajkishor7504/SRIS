using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AssetsMasterItem.Queries.GetAssetsMasterQueries
{
    public class AssetsMasterDto : IMapFrom<Assets>
    {
        public AssetsMasterDto()
        {
        }
        public int assetid { get; set; }
        public string Assetname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
