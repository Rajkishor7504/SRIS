using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem
{
    public class NotificationMasterDto
    {[Key]
        public int Id { get; set; }
        public int NotificationStatus { get; set; }
        public int countstatus { get; set; }
        public string Information { get; set; }
        public int refNo { get; set; }
        public string DestinationURL { get; set; }
        public string ModuleName { get; set; }
        public int? CreatedBy { get; set; }
        public string dateon { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string action { get; set; }
        public int notificationcount { get; set; }
    }
}
