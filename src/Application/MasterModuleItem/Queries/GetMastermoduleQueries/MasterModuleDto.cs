using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.MasterModuleItem.Queries.GetMastermoduleQueries
{
    public class MasterModuleDto: IMapFrom<MasterModule>
    {
        [Key]
        public int moduleid { get; set; }
        public string modulename { get; set; }
    }
}
