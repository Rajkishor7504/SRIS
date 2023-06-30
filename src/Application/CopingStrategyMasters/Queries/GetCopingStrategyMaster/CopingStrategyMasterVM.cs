using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.CopingStrategyMasters.Queries.GetCopingStrategyMaster
{
   public class CopingStrategyMasterVM
    {
        public CopingStrategyMasterVM()
        {
            Lists = new List<CopingStrategyMasterDto>();
        }
        public IList<CopingStrategyMasterDto> Lists { get; set; }
        public int copingid { get; set; }
        public string action { get; set; }
        public string copingname { get; set; }
        public string description { get; set; }
        public int copingtypeid { get; set; }
        public string copingtypename { get; set; }
        public int createdby { get; set; }
    }
}
