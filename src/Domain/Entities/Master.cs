using SRIS.Domain.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SRIS.Domain.Entities
{
    public class Master : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //added by jyotishikha for demography master

        public string levelname { get; set; }
        public int levelid { get; set; }
        public int parentid { get; set; }
        public int createdby { get; set; }
        public bool deletedflag { get; set; }

    }
    public class MasterList : CommonMobileApiStatus
    {
        [DataMember]
        public List<Master> MasterdData { get; set; }

    }
}
