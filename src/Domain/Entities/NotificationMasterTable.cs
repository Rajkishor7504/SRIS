using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
    public class NotificationMasterTable
    {
        [Key]
        public int Id { get; set; }
        public int NotificationStatus { get; set; }
        public string Information { get; set; }
        public int refNo { get; set; }
        public string DestinationURL { get; set; }
        public string ModuleName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
