using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class QueryBuilderModel
    {
        public string DMLCode { get; set; }
        public string QueryText { get; set; }
        public string ReturnMsg { get; set; }
    }
}
