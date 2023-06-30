using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.RelationMasters.Queries.GetRelationMaster
{
  public class RelationMasterDto : IMapFrom<RelationMaster>
    {
        public RelationMasterDto()
        {
        }
        public bool deletedflag { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
        public int id { get; set; }
    }
    
}
