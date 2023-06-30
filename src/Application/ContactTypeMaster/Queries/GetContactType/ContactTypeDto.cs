using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.ContactTypeMaster.Queries.GetContactType
{
   public class ContactTypeDto : IMapFrom<ContactType>
    {
        public int id { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public bool deletedflag { get; set; }
    }
}
