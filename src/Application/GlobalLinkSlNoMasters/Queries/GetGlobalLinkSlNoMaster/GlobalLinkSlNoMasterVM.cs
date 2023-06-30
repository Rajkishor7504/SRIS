using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GlobalLinkSlNoMasters.Queries.GetGlobalLinkSlNoMaster
{
    public class GlobalLinkSlNoMasterVM
    {
        public string action;
        public GlobalLinkSlNoMasterVM()
        {
            Lists = new List<GlobalLinkSlNoMasterDto>();
        }
        public IList<GlobalLinkSlNoMasterDto> Lists { get; set; }      
        public int glinkid { get; set; }
        public string glinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
        public int gslno { get; set; }
        public int createdby { get; set; }
    }
}
