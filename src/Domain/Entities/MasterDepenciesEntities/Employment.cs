using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Employment : BaseEntity
    {
        [Key]
        public int employmentid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int e02_mainjobactivitylastthirtydays { get; set; }
        public int e03_howfreequentlyworking { get; set; }
        public int e04_workinginwhichsector { get; set; }
        public int e05_workingstatus { get; set; }
        public int e06_reasonfornotworking { get; set; }
        public string e06_othereasonfornotworking { get; set; }
        public int apptypeid { get; set; }
        public string e04_specifyothersector { get; set; }



    }
}