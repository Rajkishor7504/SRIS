using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities
{
  public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string userfullname { get; set; }
        [Required]
        public string useremail { get; set; }
        [Required]
        public bool usermobile { get; set; }
        [Required]
        public int userroleid { get; set; }
        [Required]
        public string createdby { get; set; }
        [Required]
        public string updatedby { get; set; }
        [Required]
        public bool deletedflag { get; set; }
       
    }
}
