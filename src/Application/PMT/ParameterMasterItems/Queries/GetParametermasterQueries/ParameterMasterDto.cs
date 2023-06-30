using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.PMT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.PMT.ParameterMasterItems.Queries.GetParametermasterQueries
{
    public class ParameterMasterDto: IMapFrom<ParameterMasterItem>
    {
        [Key]
        public int pmtmasterid { get; set; }
        public string parametername { get; set; }
        public int moduleid { get; set; }
        public int questionnaireid { get; set; }
    }
}
