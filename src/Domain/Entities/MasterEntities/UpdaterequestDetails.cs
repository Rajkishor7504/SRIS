using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class UpdaterequestDetails:BaseEntity
    {[Key]
    public int requestid { get; set; }
        public string  householdno { get; set; }
        public int updatepriorityid { get; set; }
        public string hhheadname { get; set; }
        public DateTime updatedate { get; set; }
        public string contactno { get; set; }
        public int updatesourceid { get; set; }
       public string updatedescription { get; set; }
        public int status { get; set; }
        public string updatereason { get; set; }
        public int grievanceregistrationid { get; set; }

    }
}
