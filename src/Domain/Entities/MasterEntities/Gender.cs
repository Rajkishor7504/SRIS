using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class Gender:BaseEntity
    {
        [Key]
    public int genderid { get; set; }
    public string gendername { get; set; }
        public string description { get; set; }
    }   
}
