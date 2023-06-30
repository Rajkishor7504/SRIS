using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.AllMaster.DocumentTypeMaster.Queries.GetDocumentTypeListMaster
{
    
    public class DocumentTypeMasterDto
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }
    }
    public class DocumentTypeMasterVM
    {
        public IList<DocumentTypeMasterDto> Lists { get; set; }
    }
}
