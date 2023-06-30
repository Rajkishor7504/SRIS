using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class LevelDetails :BaseEntity
    {
        [Key]
        public int leveldetailid { get; set; }
        public string levelname { get; set; }
        public int levelid { get; set; }
        public int parentid { get; set; }
        public string code { get; set; }
        public string description { get; set; }        

    }
}
