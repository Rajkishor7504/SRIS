﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
   public class CommunicatingDifficulty : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
