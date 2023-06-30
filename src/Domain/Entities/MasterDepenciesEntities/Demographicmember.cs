using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Demographicmember : BaseEntity
    {
        [Key]
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int hhsize { get; set; }
        public int sex { get; set; }
        public int b04_relationwithhh { get; set; }
        public int b05_residencestatus { get; set; }
        public DateTime b06_arrivaldate { get; set; }
        public DateTime dob { get; set; }
        public int age { get; set; }
        public int placeofbirth { get; set; }
        public int nationality { get; set; }
        public string othernationality { get; set; }
        public string identificationdocs { get; set; }
        public Boolean noidentitydoc { get; set; }
        public Boolean nationidcard { get; set; }
        public Boolean birthcertificate { get; set; }
        public Boolean infantwelfarecard { get; set; }
        public Boolean passport { get; set; }
        public Boolean votingcard { get; set; }
        public Boolean aliencard { get; set; }
        public Boolean residentialpermit { get; set; }
        public Boolean drivinglicense { get; set; }
        public int otherspecify_document { get; set; }
        public string  otherspecify_other { get; set; }
        public string  uploadphoto { get; set; }
        public Boolean havebirthcert { get; set; }
        public string uploadbirthcert { get; set; }
        public int ethnicgroup { get; set; }
        public string otherethnicgroup { get; set; }
        public int maritalstatus { get; set; }
        public int b15a_isfatherstillalive { get; set; }
        public Boolean b15b_doesfatherliveinhousehold { get; set; }
        public Boolean b16a_ismotherstillalive { get; set; }
        public Boolean b16b_doesmotherliveinhousehold { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string membercode { get; set; }
        public int apptypeid { get; set; }
        public string identificationno { get; set; }
        public string uploadidproof { get; set; }
       
    }
}