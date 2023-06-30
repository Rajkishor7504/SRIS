using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.GenderMaster.Queries.GetGenderMasterItemQueriesItem
{
    public class GenderMasterVM
    {
        public IList<GenderMasterDto> Lists { get; set; }
        public int genderid { get; set; }
        public string gendername { get; set; }
        public string description { get; set; }
    }
}
