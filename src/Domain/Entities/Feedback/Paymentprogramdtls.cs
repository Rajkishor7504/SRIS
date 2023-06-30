using System;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class Paymentprogramdtls
    {
        [Key]
        public int programdetailsid { get; set; }
        public string programname { get; set; }
        public string programcode { get; set; }
        public int programid { get; set; }
        public string filename { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public bool deletedflag { get; set; }
        public string remark { get; set; }
        public int documentType { get; set; }
        public int? updatedby { get; set; }
        public DateTime? updatedon { get; set; }
        //13 dec extra column add by update approval status
        public int status { get; set; } 
        public string approvalremarks { get; set; }

    }
}
