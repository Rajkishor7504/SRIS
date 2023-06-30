using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.MaritalStatusMaster.Queries.GetMaritalStatusListMaster
{
    public class MaritalStatusMasterDto
    {
        public int maritalstatusid { get; set; }

        [Required]
        [MaxLength(50)]
        public string maritalstatusname { get; set; }
        public bool deletedflag { get; set; }
    }
   
    public class MaritalStatusMasterVM
    {
         public IList<MaritalStatusMasterDto> Lists { get; set; }
       
    }
    public class MaritalStatusMasterModel
    {
        public int id { get; set; }       
        public string name { get; set; }
        public bool deletedflag { get; set; }
    }
}


