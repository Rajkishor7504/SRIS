using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.AllMaster.NationalityMaster.Queries.GetNationalityListMaster
{
   
    public class NationalityMasterDto
    {
        public int id { get; set; }

        [Required]
        [MaxLength(45)]
        public string name { get; set; }
    }
    public class NationalityMasterVM
    {
        public IList<NationalityMasterDto> Lists { get; set; }
    }
}
