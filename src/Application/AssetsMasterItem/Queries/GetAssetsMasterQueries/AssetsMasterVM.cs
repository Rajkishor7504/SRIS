using SRIS.Application.AssetsMasterItem.Command.CreateAsstesMasterItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AssetsMasterItem.Queries.GetAssetsMasterQueries
{
    public class AssetsMasterVM
    {
        public IList<AssetsMasterDto> Lists { get; set; }
        public CreateAssetsMasterCommand command { get; set; }
        public int assetid { get; set; }
        public string Assetname { get; set; }
        public string description { get; set; }
    }
}
