using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.LocationMaster.Queries.GetLocationMaster
{
  public  class LocationMasterDto
    {
    }
    public class lgaDto: eacommonmodel
    {
        public int id { get; set; }
        public string lgaName { get; set; }
      
    }
    public class DistrictDto: eacommonmodel
    {             

        public int distId { get; set; }
        public int lgaId { get; set; }
        public string distName { get; set; }
    }
    public class WardDto: eacommonmodel
    {             
        public int id { get; set; }
        public int lgaId { get; set; }
        public int distId { get; set; }       
        public string wardName { get; set; }
    }
    public class SettlementDto: eacommonmodel
    {              

        public int id { get; set; }
        public int lgaId { get; set; }
        public int distId { get; set; }
        public int wardId { get; set; }
        public string settlementName { get; set; }
        public string settlementCode { get; set; }
        //public string eano { get; set; }


    }
    public class eacommonmodel
    {
        public int eaid { get; set; }
    }
}
