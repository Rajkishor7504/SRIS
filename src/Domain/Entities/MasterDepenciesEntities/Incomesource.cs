using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SRIS.Domain.Entities.MasterDepenciesEntities
{
    public class Incomesource : BaseEntity
    {
        [Key]
        public int incomesourceid { get; set; }
        public int hhid { get; set; }
        public int mainincomesourceofhh { get; set; }
        public string otherincomesource { get; set; }
        public int secodincomesourceofhh { get; set; }
        public string othersecondincomesourceofhh { get; set; }
        public bool didhhreceivemonetaryhelp { get; set; }
        public int howmanytimesreceivedmonhelp { get; set; }
        public int amountreceivedinlastoneyear { get; set; }
        public int hashhcollectedanyaidinoneyear { get; set; }
        public int freequencyofaidreceived { get; set; }
        public string otherfreequencyofaidreceived { get; set; }
        public int apptypeid { get; set; }
    }
}