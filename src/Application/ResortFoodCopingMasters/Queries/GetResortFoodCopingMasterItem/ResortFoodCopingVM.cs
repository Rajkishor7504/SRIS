using SRIS.Application.ResortFoodCopingMasters.Command.CreateResortFoodCopingMasterItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ResortFoodCopingMasters.Queries.GetResortFoodCopingMasterItem
{
    public class ResortFoodCopingVM
    {
        public IList<ResortFoodCopingDto> Lists { get; set; }
        public CreateResortFoodCopingMasterItemCommand command { get; set; }
        public int resortfoodcopingid { get; set; }
        public string resortfoodcoping { get; set; }
        public string description { get; set; }
    }
}
