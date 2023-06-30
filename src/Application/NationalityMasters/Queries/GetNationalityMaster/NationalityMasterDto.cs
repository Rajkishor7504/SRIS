using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.NationalityMasters.Queries.GetNationalityMaster
{
    public  class NationalityMasterDto : IMapFrom<NationalityMaster>
    {
        public NationalityMasterDto()
        {
        }      
        public string nationality { get; set; }
        public string description { get; set; }
        public int nationalityid { get; set; }
        public bool deletedflag { get; set; }

    }
}
