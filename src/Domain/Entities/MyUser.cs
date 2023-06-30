using SRIS.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SRIS.Domain.Entities
{
   public class MyUser : AuditableEntity{
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userfullname { get; set; }
        public string usermobile { get; set; }
        public int userroleid { get; set; }
        public string deleted { get; set; }        
        public string Secretkey { get; set; }
        [DataMember]
        [NotMapped]
        public string otp { get; set; }
        public bool passwordreset { get; set; }
        public string organisationname { get; set; }

        public string startdate { get; set; }
        public string enddate { get; set; }
        public string gendername { get; set; }
        public bool deletedflag { get; set; }
        public int spotchecker { get; set; }
        public string spotcheckerstatus { get; set; }
        public string eano { get; set; }
        public string districtId { get; set; }
        public int surveyplanId { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public int registrationpurpose { get; set; }
        public string surveyPlanName { get; set; } // Newly added
        public int teamid { get; set; }
        public IList<EnumeratorList> enumerator { get; set; }
    }

    public class EnumeratorList
    {
        [Key]
        public int EnumeratorId { get; set; }
        public string EnueratorName { get; set; }
    }

    public class ChangePassword
    {
        [DataMember]
        [NotMapped]
        [DataType(DataType.Password)]
        public string vchOldPassword { get; set; }

        [DataMember]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        public string vchPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Compare("vchPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string vchConfirmPassword { get; set; }
    }

    //public class UserResult
    //{
    //    public int Status { get; set; }
    //    public string Massage { get; set; }
    //    public List<User> ListUser { get; set; }
    //}
}
