using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Entities
{
   public class Quantile
    {
        public int id { get; set; }
        public string quantile { get; set; }
        public int createdby { get; set; }
        public int updatedby { get; set; }

    }
}
