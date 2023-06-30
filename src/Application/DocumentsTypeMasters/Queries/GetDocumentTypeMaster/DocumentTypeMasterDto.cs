using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.DocumentsTypeMasters.Queries.GetDocumentTypeMaster
{
   public class DocumentTypeMasterDto : IMapFrom<DocumentTypeMaster>
    {
        public DocumentTypeMasterDto()
        {
        }
        public string documentType { get; set; }
        public string description { get; set; }        
        public int id { get; set; }
        public bool deletedflag { get; set; }
    }
}
