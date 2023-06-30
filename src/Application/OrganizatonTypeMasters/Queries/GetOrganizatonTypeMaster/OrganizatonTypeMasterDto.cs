using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.OrganizatonTypeMasters.Queries.GetOrganizatonTypeMaster
{
  public class OrganizatonTypeMasterDto : IMapFrom<OrganizatonType>
    {
        public OrganizatonTypeMasterDto()
        {
        }
        public string description { get; set; }
        public string organizationtypename { get; set; }
        public int organizationtypeid { get; set; }
        public bool deletedflag { get; set; }
    }
}
