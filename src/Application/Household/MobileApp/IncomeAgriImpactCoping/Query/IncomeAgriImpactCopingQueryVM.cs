using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.IncomeAgriImpactCoping.Query
{
   public class IncomeAgriImpactCopingQueryVM:CommonMobileApiStatus
    {
        public IncomeModelVM incomeSource { get; set; }
        public AgriCulturalModelVM agriCultural { get; set; }
        public ImpactOfShocksModelVM impactOfShock { get; set; }
        public CopingModelVM copingStrategies { get; set; }
    }
    public class IncomeModelVM
    {
        public string incomeSourceId { get; set; }//for update purpose
        
        public string hhid { get; set; }
        public string mainIncomeSourceId { get; set; }
        public string mainIncomeSource { get; set; }
        public string otherincomesource { get; set; }//not mentaion new
        public string secondIncomeSourceId { get; set; }
        public string secondIncomeSource { get; set; }
        public string othersecondincomesourceofhh { get; set; }//new

        public string rcvMnyfrm12MntInd { get; set; }
        public string ifYesTotalAmount { get; set; }
        public string ifYesHowManyTimes { get; set; }

        public string rcvAidLst12MntFrmOrg { get; set; }
        public string ifYesWhichTypeOrgId { get; set; }
        public string ifYesWhichTypeOrg { get; set; }
        public string ifYesWhatTypeAidId { get; set; }
        public string ifYesWhatTypeAid { get; set; }
        public string ifYesHowFrequently { get; set; }       
        public string ifYesHowFrequentlyId { get; set; }
        public string ifYesHowFrequentlyOther { get; set; }//new



        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }
    }
    public class AgriCulturalModelVM
    {
        public string agricultureId { get; set; }//for update purpose
        public string doescultivateland { get; set; }
        public string ownedland { get; set; }
        public string rentedland { get; set; }
        public string freeland { get; set; }
        public string ownedbywhom { get; set; }
        public string rainfedlow { get; set; }
        public string rainfedhigh { get; set; }
        public string irrigated { get; set; }

        public string pasture { get; set; }
        public string wasanyhhcatchingfish { get; set; }
        public string nooffemalecatching { get; set; }
        public string noofmalecatching { get; set; }
        public string anyonehhownlivestock { get; set; }
        
        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }

        ////Ecology Part
        //public string ecologynamee { get; set; }
        //public string ecologyiid { get; set; }
        //public string ecologyinhectaress { get; set; }
        //public string eclidd { get; set; }

        public List<CultivationModelVM> cultivation { get; set; }
        public List<CultivationResponsbiliityModelVM> cultivationresponsibility { get; set; }
        public List<OwnLiveStockModelVM> ownlivestock { get; set; }
        public List<BreedingLiveStockModelVM> breedinglivestock { get; set; }
        public List<EcologyModelVM> ecology { get; set; }
    }
   public class CommonAgriModel
    {
        public int querytype { get; set; }
        public int agricultureid { get; set; }
        public int hhid { get; set; }
        public string transid { get; set; }
        public string doescultivateland { get; set; }
        public string ownedland { get; set; }
        public string rentedland { get; set; }
        public string freeland { get; set; }
        public string ownedbywhom { get; set; }
        public string rainfedlow { get; set; }
        public string rainfedhigh { get; set; }
        public string irrigated { get; set; }

        public string pasture { get; set; }
        public string wasanyhhcatchingfish { get; set; }
        public string nooffemalecatching { get; set; }
        public string noofmalecatching { get; set; }
        public string anyonehhownlivestock { get; set; }

        ////Ecology Part

        //public string ecologyName { get; set; }
        //public string ecologyid { get; set; }
        //public string ecologyinhectares { get; set; }
        //public string eclid { get; set; }

        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }
    }

    public class CultivationModelVM
    {
        public string cultivationid { get; set; }
        public string cropid { get; set; }
        public string cultivatedinhectares { get; set; }
        public string cropName { get; set; }
    }
    public class CultivationResponsbiliityModelVM
    {       
        public string cropid { get; set; }
        public string cropName { get; set; }
        public string responsibilityid { get; set; }
        public string noofmale { get; set; }
        public string nooffemale { get; set; }
    }
    //public class EcologyLiveModelVM
    //{
    //    public string ecologyName { get; set; }
    //    public string ecologyid { get; set; }
    //    public string ecologyinhectares { get; set; }
    //    public string eclid { get; set; }
    //}
    public class OwnLiveStockModelVM
    {
       public string ownid { get; set; }
        public string livestockid { get; set; }
        public string nooflivestockown { get; set; }
        public string liveStockName { get; set; }
    }

    public class BreedingLiveStockModelVM
    {
         public string breedid { get; set; }
        public string livestockid { get; set; }
        public string responsibilityNms { get; set; }
        public string liveStockName { get; set; }
        public string responsibilityids { get; set; }          
    }
    //Ecology Part
    public class EcologyModelVM
    {
        public string ecologyName { get; set; }
        public string ecologyid { get; set; }
        public string ecologyinhectares { get; set; }
        public string eclid { get; set; }
    }
    //End Ecology Part

    public class ImpactOfShocksModelVM
    {
        public string impactId { get; set; }//for update purpose
        public string ishhaffectedbyevent { get; set; }

        public string livelyhoodaffectedids { get; set; }
        public string livelyhoodaffected { get; set; }

        public string otherLiveHood { get; set; }


        public string shockforlivestock { get; set; }
        public string shockforlivestockid { get; set; }
        public string othershockforlivestock { get; set; }


        public string shockforlabour { get; set; }
        public string shockforlabourid { get; set; }
        public string othershockforlabour { get; set; }


        public string shockforother { get; set; }
        public string shockforotherid { get; set; }
        public string othershockforother { get; set; }

        public string shockforcrop { get; set; }
        public string shockforcropid { get; set; }
        public string othershockforcrop { get; set; }    
      
       
        public string typeofserveritylivestockNm { get; set; }
        public string typeofserveritylivestock { get; set; }
        public string typeofseveritycropsNm { get; set; }
        public string typeofseveritycrops { get; set; }
        public string typeofseverityotherNm { get; set; }
        public string typeofseverityother { get; set; }

        public string  typeofseveritylabourNm  { get; set; }
        public string typeofseveritylabour { get; set; }

        






        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public string completedStatus { get; set; }
    }


    public class CopingModelVM
    {
        public string copingId { get; set; }//for update purpose
        public string rejected_status { get; set; }
        public string reject_message { get; set; }
        public string statusid { get; set; }
        public IList<CopingStrategiesModelVM> livehlihoodcoping { get; set; }
        public IList<CopingStrategiesModelVM> foodcoping { get; set; }
        public string completedStatus { get; set; }

    }

    public class CopingStrategiesModelVM
    {
       public string lcopingdetailid { get; set; }
        public string lcopingid { get; set; }
        public string lcopingName { get; set; }
        public string lresortingneedid { get; set; }
        public string lresortingneedName { get; set; }
        public string strategyid { get; set; }
   

    }
   

}
