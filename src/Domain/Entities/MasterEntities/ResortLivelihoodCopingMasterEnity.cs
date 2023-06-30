using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterEntities
{
    public class ResortLivelihoodCopingMasterEnity:BaseEntity
    {
        [Key]
        public int resortlivelyhoodcopingid { get; set; }
        public string resortlivelyhoodcoping { get; set; }
        public string description { get; set; }
    }
}
