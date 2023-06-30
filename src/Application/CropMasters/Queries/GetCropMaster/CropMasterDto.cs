using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.CropMasters.Queries.GetCropMaster
{
   public class CropMasterDto : IMapFrom<Crop>
    {
        public CropMasterDto()
        {
        }
        public int cropid { get; set; }
        public string cropname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}