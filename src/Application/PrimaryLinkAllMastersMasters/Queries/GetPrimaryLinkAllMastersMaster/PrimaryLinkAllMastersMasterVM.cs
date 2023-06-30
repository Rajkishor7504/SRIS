using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PrimaryLinkAllMastersMasters.Queries.GetPrimaryLinkAllMastersMaster
{
   public class PrimaryLinkAllMastersMasterVM
    {
        public IList<PrimaryLinkAllMastersMasterDto> Lists { get; set; }
        public int plinkid { get; set; }
        public string plinkname { get; set; }
        public int glinkid { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
    }
}
