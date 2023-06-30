using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery
{
   public class AgricultureinfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int agricultureid { get; set; }
        public int doescultivateland { get; set; }
        public int ownedland { get; set; }
        public int rentedland { get; set; }
        public int freeland { get; set; }
        public int ownedbywhom { get; set; }
        public int rainfedlow { get; set; }
        public int rainfedhigh { get; set; }
        public int irrigated { get; set; }
        public int pasture { get; set; }
        public int wasanyhhcatchingfish { get; set; }
        public int nooffemalecatching { get; set; }
        public int noofmalecatching { get; set; }
        public int anyonehhownlivestock { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int transid { get; set; }

        public int querytype { get; set; }
        public List<Cultivation> cultivation { get; set; }
        public List<CultivationResponsbiliity> cultivationresponsibility { get; set; }
        public List<OwnLiveStock> ownlivestock { get; set; }
        public List<BreedingLiveStock> breedinglivestock { get; set; }
        public List<EcologyStock> ecologystock { get; set; }

        //for view purpose

        public string doescultivatelandv { get; set; }
        public int ownedlandv { get; set; }
        public int rentedlandv { get; set; }
        public int freelandv { get; set; }
        public string ownedbywhomv { get; set; }
        public int rainfedlowv { get; set; }
        public int rainfedhighv { get; set; }
        public int irrigatedv { get; set; }
        public int pasturev { get; set; }
        public string wasanyhhcatchingfishv { get; set; }
        public int nooffemalecatchingv { get; set; }
        public int noofmalecatchingv { get; set; }
        public string anyonehhownlivestockv { get; set; }

        public List<ecologyview> ecologydetails { get; set; }
        //added by Rajkishor(09-06-23)

        //public int value { get; set; }
        public int ecologyvalue { get; set; }
        public int ecologyid { get; set; }

        //END

        //end

        //Spot Checker
        public int hhid_spt { get; set; }
        public int agricultureid_spt { get; set; }
        public string doescultivatelandv_spt { get; set; }
        public int ownedlandv_spt { get; set; }
        public int rentedlandv_spt { get; set; }
        public int freelandv_spt { get; set; }
        public string ownedbywhomv_spt { get; set; }
        public int rainfedlowv_spt { get; set; }
        public int rainfedhighv_spt { get; set; }
        public int irrigatedv_spt { get; set; }
        public int pasturev_spt { get; set; }
        public string wasanyhhcatchingfishv_spt { get; set; }
        public int nooffemalecatchingv_spt { get; set; }
        public int noofmalecatchingv_spt { get; set; }
        public string anyonehhownlivestockv_spt { get; set; }

        public int cerealscultivateinhectares { get; set; }
        public int cerealscultivateinhectares_spt { get; set; }

        public int fruittreescultivateinhectares { get; set; }
        public int fruittreesscultivateinhectares_spt { get; set; }

        public int groundnutcultivateinhectares { get; set; }
        public int groundnutcultivateinhectares_spt { get; set; }

        public int legumescultivateinhectares { get; set; }
        public int legumescultivateinhectares_spt { get; set; }

        public int vegcultivateinhectares { get; set; }
        public int vegcultivateinhectares_spt { get; set; }

        public int tuberscultivateinhectares { get; set; }
        public int tuberscultivateinhectares_spt { get; set; }

        public int noofmaleworkinginCereals { get; set; }
        public int noofmaleworkinginFruittrees { get; set; }
        public int noofmaleworkinginGroundnut { get; set; }
        public int noofmaleworkinginLegumes { get; set; }
        public int noofmaleworkinginVegetables { get; set; }
        public int noofmaleworkinginTubers { get; set; }

        public int nooffemaleworkinginCereals { get; set; }
        public int nooffemaleworkinginFruittrees { get; set; }
        public int nooffemaleworkinginGroundnut { get; set; }
        public int nooffemaleworkinginLegumes { get; set; }
        public int nooffemaleworkinginVegetables { get; set; }
        public int nooffemaleworkinginTubers { get; set; }

        public int noofmaleworkinginCereals_spt { get; set; }
        public int noofmaleworkinginFruittrees_spt { get; set; }
        public int noofmaleworkinginGroundnut_spt { get; set; }
        public int noofmaleworkinginLegumes_spt { get; set; }
        public int noofmaleworkinginVegetables_spt { get; set; }
        public int noofmaleworkinginTubers_spt { get; set; }

        public int nooffemaleworkinginCereals_spt { get; set; }
        public int nooffemaleworkinginFruittrees_spt { get; set; }
        public int nooffemaleworkinginGroundnut_spt { get; set; }
        public int nooffemaleworkinginLegumes_spt { get; set; }
        public int nooffemaleworkinginVegetables_spt { get; set; }
        public int nooffemaleworkinginTubers_spt { get; set; }


        public int cattle { get; set; }
        public int sheep { get; set; }
        public int goats { get; set; }
        public int pigs { get; set; }
        public int chicken { get; set; }
        public int ducks { get; set; }
        public int donkeys { get; set; }
        public int horses { get; set; }
        public int specifyother { get; set; }
        public int cattle_spt { get; set; }
        public int sheep_spt { get; set; }
        public int goats_spt { get; set; }
        public int pigs_spt { get; set; }
        public int chicken_spt { get; set; }
        public int ducks_spt { get; set; }
        public int donkeys_spt { get; set; }
        public int horses_spt { get; set; }
        public int specifyother_spt { get; set; }

        //Breeding livestock

        public string cattleresponsibility { get; set; }
        public string sheepresponsibility { get; set; }
        public string goatsresponsibility { get; set; }
        public string pigsresponsibility { get; set; }
        public string chickenresponsibility { get; set; }
        public string ducksresponsibility { get; set; }
        public string horsesresponsibility { get; set; }
        public string donkeysresponsibility { get; set; }
        public string responsibilitybyothers { get; set; }
        public string cattleresponsibility_spt { get; set; }
        public string sheepresponsibility_spt { get; set; }
        public string goatsresponsibility_spt { get; set; }
        public string pigsresponsibility_spt { get; set; }
        public string chickenresponsibility_spt { get; set; }
        public string ducksresponsibility_spt { get; set; }
        public string horsesresponsibility_spt { get; set; }
        public string donkeysresponsibility_spt { get; set; }
        public string responsibilitybyothers_spt { get; set; }

        public List<CultivationView> cultivationv { get; set; }
        public List<CultivationResponsbiliityView> cultivationresponsibilityv { get; set; }
        public List<OwnLiveStockView> ownlivestockv { get; set; }
        public List<BreedingLiveStockView> breedinglivestockv { get; set; }
        public int lockstatus { get; set; }
        public int approvestatus { get; set; }
        public string RejectRemark { get; set; }
        public int updatestatus { get; set; }
        
        //end
    }
    public class Cultivation
    {
        public int cultivationid { get; set; }
        public int cropid { get; set; }
        public int cultivatedinhectares { get; set; }
    }
    public class EcologyStock
    {
        public int ecologyid { get; set; }
        public int ecologyinhectares { get; set; }
        public string ecologyName { get; set; }
        public int eclid { get; set; }
    }

    public class ecologyview
    {
        public int transid { get; set; }
        public int agricultureid { get; set; }
        //public string value { get; set; }
        public int ecologyvalue { get; set; }
        public int ecologyid { get; set; }
    }

    public class CultivationResponsbiliity
    {
        public int responsibilityid { get; set; }
        public int cropid { get; set; }
        public int noofmale { get; set; }
        public int nooffemale { get; set; }
    }
    public class OwnLiveStock
    {
        public int ownid { get; set; }
        public int livestockid { get; set; }
        public int nooflivestockown { get; set; }
    }
    public class BreedingLiveStock
    {
        public int breedid { get; set; }
        public int livestockid { get; set; }
        public string responsibilityids { get; set; }
        public int responsibilityid { get; set; }
    }
    //for view purpose
    public class CultivationView
    {
        
        public string cropv { get; set; }
        public int cultivatedinhectaresv { get; set; }
    }
    public class CultivationResponsbiliityView
    {
       
        public string cropv { get; set; }
        public int noofmalev { get; set; }
        public int nooffemalev { get; set; }
    }
    public class OwnLiveStockView
    {
        
        public string livestockv { get; set; }
        public int nooflivestockownv { get; set; }
    }
    public class BreedingLiveStockView
    {
       
        public string livestockv { get; set; }
        public string responsibilityidsv { get; set; }
       

    }
    //end


    public class AgricultureStatusinfoDto
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int agricultureid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
    }
    }
