using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class CopingStrategyMaster : BaseEntity
    {
        [Key]
        public int copingid { get; set; }
        public string copingname { get; set; }  
        public string description { get; set; }        
        public int copingtypeid { get; set; }       
        public string copingtypename { get; set; }

    }
}
