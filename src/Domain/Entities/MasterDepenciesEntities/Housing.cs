using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Housing : BaseEntity
    {
        [Key]
        public int housingid { get; set; }
        public int hhid { get; set; }
        public int f01_occupancystatusofdwelling { get; set; }
        public int f02_mainconstructionmaterial { get; set; }
        public string f02_otherspecify { get; set; }
        public int f03_mainmaterialusedforroofing { get; set; }
        public string f03os_othermaterialroofing { get; set; }
        public int f04_mainmaterialusedforflooring { get; set; }
        public string f04os_othermaterialflooring { get; set; }
        public int f05_mainsourceoflighting { get; set; }
        public string f05os_otherspecify { get; set; }
        public int f06_maincookingfuel { get; set; }
        public string f06os_othermaincookingfuel { get; set; }
        public int f07_typeoftoiletfacility { get; set; }
        public string f07os_othertoiletfacility { get; set; }
        public bool f08_toiletsharedwithotherhh { get; set; }
        public int f09_howmanyhhusetoiletfacility { get; set; }
        public int f10_mainsourceofdrinkingwater { get; set; }
        public string f10os_othersourceofdrinkingwater { get; set; }
        public int f11_howhhdisposerubbish { get; set; }
        public string f11os_otherwayforrubbish { get; set; }
        public int apptypeid { get; set; }
    }
}