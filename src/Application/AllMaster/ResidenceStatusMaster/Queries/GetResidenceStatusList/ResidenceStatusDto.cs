using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.ResidenceStatusMaster.Queries.GetResidenceStatusList
{
   
    public class ResidenceStatusDto
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }
    }
    public class ResidenceStatusVM
    {
        public IList<ResidenceStatusDto> Lists { get; set; }
    }

    public class PlaceOfBirthDto
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }
    }
}
