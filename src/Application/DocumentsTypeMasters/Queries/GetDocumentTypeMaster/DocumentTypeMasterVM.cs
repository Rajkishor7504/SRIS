using SRIS.Application.DocumentsTypeMasters.Commands.CreateDocumentTypeMasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.DocumentsTypeMasters.Queries.GetDocumentTypeMaster
{
   public class DocumentTypeMasterVM
    {
        public IList<DocumentTypeMasterDto> Lists { get; set; }
        public CreateDocumentTypeMasterCommand Command { get; set; }
        public int id { get; set; }

        [DataMember]
        //[Required]
        [Display(Name = "Document Type")]
        
      //  [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Document Type.")]
        public string documentType { get; set; }

       
        //[DataMember]
        [Display(Name = "Description")]
       // [RegularExpression(@"[A-Za-z0-9,.(){}_?/|=+`~ ]*", ErrorMessage = "Please enter valid Description")]
        public string description { get; set; }
    }
}
