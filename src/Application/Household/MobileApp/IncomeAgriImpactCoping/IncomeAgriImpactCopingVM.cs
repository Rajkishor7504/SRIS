using FluentValidation;
using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
using SRIS.Application.Household.DemographicMember.CommandsMobile;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.EduAndHealth.IncomeAgriImpactCoping
{
   public class IncomeAgriImpactCopingVM: CommonMobileApiStatus
    {
        public IList<ValidationFailuremodel> incomeerrors { get; set; }
        public IList<ValidationFailuremodel> agricultureerrors { get; set; }
        public IList<ValidationFailuremodel> impacterrors { get; set; }
       
    }
    #region-------------Income-------------------
    public class HHIncomeDto
    {
        public string incomeSourceId { get; set; }//for update purpose
        public string mainIncomeSourceId { get; set; }
        public string otherincomesource { get; set; }
        public string secondIncomeSourceId { get; set; }
        public string othersecondincomesource { get; set; }
        public string rcvMnyfrm12MntInd { get; set; }
        public string ifYesHowManyTimes { get; set; }
        public string ifYesTotalAmount { get; set; }
        public string rcvAidLst12MntFrmOrg { get; set; }
        public string ifYesHowFrequentlyId { get; set; }
        public string otherfreequencyofaidreceived { get; set; }     
        public string ifYesWhatTypeAidId { get; set; }
        public string ifYesWhichTypeOrgId { get; set; }
       

    }
       

    public class incomeValidator : AbstractValidator<HHIncomeDto>
    {
        public incomeValidator()
        {
            RuleFor(x => x.mainIncomeSourceId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.mainIncomeSourceId == "101", () => {
                RuleFor(x => x.otherincomesource).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");              
            });
            RuleFor(x => x.secondIncomeSourceId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.secondIncomeSourceId == "101", () => {
                RuleFor(x => x.otherincomesource).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            });

            RuleFor(x => x.rcvMnyfrm12MntInd).NotNull().WithMessage("{PropertyName} is required.");
            When(x => x.rcvMnyfrm12MntInd == "1", () => {
                RuleFor(x => x.ifYesHowManyTimes).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
                RuleFor(x => x.ifYesTotalAmount).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");//if yes then
            });
            RuleFor(x => x.rcvAidLst12MntFrmOrg).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.rcvAidLst12MntFrmOrg == "1", () => {
                RuleFor(x => x.ifYesHowFrequentlyId).NotNull().NotEmpty().WithMessage("{PropertyName} is required."); //if yes then
                RuleFor(x => x.ifYesWhatTypeAidId).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required.");//multi select
                RuleFor(x => x.ifYesWhichTypeOrgId).NotNull().NotEmpty().NotEqual("string").WithMessage("{PropertyName} is required."); //multi select
            });
            When(x => x.ifYesHowFrequentlyId == "1001", () => {
                RuleFor(x => x.otherfreequencyofaidreceived).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            });

            //RuleFor(x => x.rcvAidLst12MntFrmOrg).NotNull().WithMessage("{PropertyName} is required.");
            //When(x => x.rcvMnyfrm12MntInd == "1", () => {
            //    RuleFor(x => x.ifYesHowManyTimes).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //    RuleFor(x => x.ifYesTotalAmount).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");//if yes then
            //});

            
            //

        }
    }
    #endregion
    #region--------------Agriculture----------------
    public class HHAgricultureDto
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
        public List<EcologyModel> ecology { get; set; }
        public List<CultivationModel> cultivation { get; set; }
        public List<CultivationResponsbiliityModel> cultivationresponsibility { get; set; }
        public List<OwnLiveStockModel> ownlivestock { get; set; }
        public List<BreedingLiveStockModel> breedinglivestock { get; set; }

        // adding 

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

        public int Cerealscultivateinhectares { get; set; }
        public int Cerealscultivateinhectares_spt { get; set; }

        public int Fruittreescultivateinhectares { get; set; }
        public int Fruittreesscultivateinhectares_spt { get; set; }

        public int Groundnutcultivateinhectares { get; set; }
        public int Groundnutcultivateinhectares_spt { get; set; }

        public int Legumescultivateinhectares { get; set; }
        public int Legumescultivateinhectares_spt { get; set; }

        public int vegcultivateinhectares { get; set; }
        public int vegcultivateinhectares_spt { get; set; }

        public int Tuberscultivateinhectares { get; set; }
        public int Tuberscultivateinhectares_spt { get; set; }

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
    }
    public class EcologyModel
    {
        public string ecologyid { get; set; }
        public string ecologyinhectares { get; set; }
        public string ecologyName { get; set; }
        public string eclid { get; set; }
    }
    public class CultivationModel
    {
       // public string cultivationid { get; set; }
        public string cropid { get; set; }
        public string cultivatedinhectares { get; set; }
    }
    public class CultivationResponsbiliityModel
    {
       // public string responsibilityid { get; set; }
        public string cropid { get; set; }
        public string noofmale { get; set; }
        public string nooffemale { get; set; }
    }
    public class OwnLiveStockModel
    {
        //public string ownid { get; set; }
        public string livestockid { get; set; }
        public string nooflivestockown { get; set; }
    }
   
    public class BreedingLiveStockModel
    {
       // public string breedid { get; set; }
        public string livestockid { get; set; }
        public string responsibilityids { get; set; }
     

    }
    public class agricultureValidator : AbstractValidator<HHAgricultureDto>
    {
        public agricultureValidator()
        {
            RuleFor(x => x.doescultivateland).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.ownedland).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.rentedland).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.freeland).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.ownedbywhom).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.rainfedlow).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.rainfedhigh).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.irrigated).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.pasture).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.wasanyhhcatchingfish).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.wasanyhhcatchingfish == "1", () => {
                RuleFor(x => x.nooffemalecatching).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
                RuleFor(x => x.noofmalecatching).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            });
            RuleFor(x => x.anyonehhownlivestock).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
    #endregion
    #region--------------Impact Of Shock------------------
    public class HHImpackOfShockDto
    {
        public string impactId { get; set; }//for update purpose
        public string ishhaffectedbyevent { get; set; }
        public string livelyhoodaffectedids { get; set; }
        public string shockforcropid { get; set; }
        public string shockforlivestockid { get; set; }
        public string shockforlabourid { get; set; }
        public string othershockforcrop { get; set; }
        public string othershockforlivestock { get; set; }
        public string othershockforlabour { get; set; }
        public string typeofserveritylivestock { get; set; }
        public string typeofseveritycrops { get; set; }
        public string typeofseveritylabour { get; set; }
        public string shockforotherid { get; set; }
        public string othershockforother { get; set; }
        public string typeofseverityother { get; set; }
        public string otherLiveHood { get; set; }
        
    }
    public class impactValidator : AbstractValidator<HHImpackOfShockDto>
    {
        public impactValidator()
        {
          
            RuleFor(x => x.ishhaffectedbyevent).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.ishhaffectedbyevent == "1", () =>            {
            RuleFor(x => x.livelyhoodaffectedids).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.shockforcropid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.shockforlivestockid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.shockforlabourid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.shockforotherid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.typeofserveritylivestock).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.typeofseveritylabour).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.typeofseveritycrops).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.typeofseverityother).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.othershockforcrop).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.othershockforlivestock).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.othershockforother).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.otherLiveHood).NotNull().WithMessage("{PropertyName} is required.");
          });
        }
    }

    #endregion
    #region---------------------Coping Startegy-------------------
    public class HHCopingDto
    {
        public string copingId { get; set; }//for update purpose
        public List<LivelihoodCopingModel> livehlihoodcoping { get; set; }
        public List<FoodCopingModel> foodcoping { get; set; }
    }
    public class LivelihoodCopingModel
    {
        //public string lcopingdetailid { get; set; }
        public string lcopingid { get; set; }
        public string lresortingneedid { get; set; }
        //public string strategyid { get; set; }

      
    }
    public class FoodCopingModel
    {
        //public string fcopingdetailid { get; set; }
        public string lcopingid { get; set; }
        public string lresortingneedid { get; set; }
       // public string strategyid { get; set; }
    }

    #endregion
}
