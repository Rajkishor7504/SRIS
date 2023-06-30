using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Chronicediseasedetails : BaseEntity
    {
        [Key]
        public int diseasedetailid { get; set; }
        public int healthid { get; set; }
        public int diseaseid { get; set; }     
        public int status { get; set; }       
    }
}