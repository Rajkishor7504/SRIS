using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.PrimaryLinkAllMastersMasters.Queries.GetPrimaryLinkAllMastersMaster
{
    public class PrimaryLinkAllMastersMasterDto : IMapFrom<PrimaryLinkMaster>
    {
        public string plinkname { get; set; }
        public int plinkid { get; set; }
        public int glinkid { get; set; }

        public string glinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public bool deletedflag { get; set; }
        public string areaname { get; set; }
    }
}
