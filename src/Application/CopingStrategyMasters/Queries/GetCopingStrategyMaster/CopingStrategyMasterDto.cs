using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRIS.Application.CopingStrategyMasters.Queries.GetCopingStrategyMaster
{
   public class CopingStrategyMasterDto
    {
        public int copingid { get; set; }
        public string action { get; set; }
        public string copingname { get; set; }
        public string description { get; set; }
        public int copingtypeid { get; set; }
        public string copingtypename { get; set; }
        public int createdby { get; set; }
    }
}
