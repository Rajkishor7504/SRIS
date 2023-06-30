using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PrimaryLinkSlNoMasters.Queries.GetPrimayLinkSlNoMaster
{
   public class PrimayLinkSlNoMasterVM
    {
        public string action;
        public PrimayLinkSlNoMasterVM()
        {
            Lists = new List<PrimayLinkSlNoMasterDto>();
        }
        public IList<PrimayLinkSlNoMasterDto> Lists { get; set; }
        public int plinkid { get; set; }
        public string plinkname { get; set; }
        public int glinkid { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
        public int slno { get; set; }
        public int createdby { get; set; }
    }
}
