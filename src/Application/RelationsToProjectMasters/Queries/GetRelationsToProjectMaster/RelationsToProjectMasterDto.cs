using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.RelationsToProjectMasters.Queries.GetRelationsToProjectMaster
{
   public class RelationsToProjectMasterDto : IMapFrom<RelationsToProjectMaster>
    {
        public RelationsToProjectMasterDto()
        {

        }
        public int relationid { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
        public bool deletedflag { get; set; }
    }
}
