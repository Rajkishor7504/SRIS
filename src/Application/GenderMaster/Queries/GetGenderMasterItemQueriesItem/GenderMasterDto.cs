using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GenderMaster.Queries.GetGenderMasterItemQueriesItem
{
    public class GenderMasterDto: IMapFrom<Gender>
    {
        public int genderid { get; set; }
        public string gendername { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
