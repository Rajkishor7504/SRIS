using System;
using System.ComponentModel.DataAnnotations;

namespace SRIS.Domain.Entities
{
    public class PaymentDetail
    {
        [Key]
        public int paymentid { get; set; }
        public int programdetailsid { get; set; }
        public string benificiaryname { get; set; }
        public string householdnumber { get; set; }
        public string location { get; set; }
        public string paymenttype { get; set; }
        public decimal amounttodate { get; set; }
        public decimal amountinlastcycle { get; set; }
        public DateTime dateofcashtransefer { get; set; }
        public DateTime datesofactualtransefer { get; set; }
        public string proxyrecipientname { get; set; }
        public DateTime dobofproxy { get; set; }
        public string genderofproxy { get; set; }
        public string relationofproxytorecipient { get; set; }
        public string paymentserviceprovider { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public bool deletedflag { get; set; }

        //Newly added on 05-Jan-2021
        public string district { get; set; }
        public string ward { get; set; }
        public string settlement { get; set; }
        public string sector { get; set; }
        public string membercode { get; set; }
        public string enrollmentStatus { get; set; }
        public string benefits { get; set; }
        public string programmcode { get; set; }
        public string programmname { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
        public DateTime enrollmentstartdate { get; set; }
        public DateTime enrollmentenddate { get; set; }
        public decimal amount { get; set; }
        public string transferfreq { get; set; }
        public int documenttype { get; set; }
    }
}
