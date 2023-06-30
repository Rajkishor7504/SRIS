using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GlobalLinkSlNoMasters.Queries.GetGlobalLinkSlNoMaster
{
    public class GlobalLinkSlNoMasterDto : IMapFrom<GlobalLinkSlNoMaster>
    {
        
        public int glinkid { get; set; }

        public string glinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public bool deletedflag { get; set; }
        public string areaname { get; set; }
        public int createdby { get; set; }
        public int gslno { get; set; }
        public string action { get; set; }
        public List<GlobalLinkSlNoMasterDto> Lists { get; set; }
    }
}