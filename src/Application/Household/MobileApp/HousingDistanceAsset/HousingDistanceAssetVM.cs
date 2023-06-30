using FluentValidation;
using SRIS.Application.Household.DemographicMember.CommandsMobile;
using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.MobileApp.HousingDistanceAsset
{
   public class HousingDistanceAssetVM: CommonMobileApiStatus
    {
        public IList<ValidationFailuremodel> housingerror { get; set; }
        public IList<distanceValidationFailuremodel> distanceerror { get; set; }
        public IList<assetValidationFailuremodel> assseterror { get; set; }
    }
   
    #region-----------Housing-------
    public class HHHousingDto
    {
        public string housingInfoId { get; set; } //for update purpose
        public string occupancyStatusId { get; set; }
        public string wallMaterialId { get; set; }
        public string otherWallMaterial { get; set; }
        public string roofingMaterialId { get; set; }
        public string roofingMaterialOther { get; set; }
        public string flooringMaterialId { get; set; }
        public string flooringMaterialOther { get; set; }
        public string lightingSourceId { get; set; }
        public string lightingSourceOther { get; set; }
        public string cookingFuelId { get; set; }
        public string cookingFuelOther { get; set; }
        public string typeOfToiletId { get; set; }
        public string typeOfToiletOther { get; set; }
        public string isSharedToilet { get; set; }
        public string totalUseToilet { get; set; }
        public string drinkingWaterSourceId { get; set; }
        public string drinkingWaterSourceOther { get; set; }

        public string disposeRubbishId { get; set; }
        public string disposeRubbishOther { get; set; }

    }
     

    public class housingValidator : AbstractValidator<HHHousingDto>
    {
        public housingValidator()
        {
           
            RuleFor(x => x.occupancyStatusId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.wallMaterialId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.wallMaterialId == "1001", () => {
                RuleFor(x => x.otherWallMaterial).NotNull().WithMessage("{PropertyName} is required."); //if wallMaterialId is 1001 then
            });
            RuleFor(x => x.roofingMaterialId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.roofingMaterialId == "1001", () => {
                RuleFor(x => x.roofingMaterialOther).NotNull().WithMessage("{PropertyName} is required."); //if roofingMaterialId is 1001 then
            });
            RuleFor(x => x.flooringMaterialId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.flooringMaterialId == "1001", () => {
                RuleFor(x => x.flooringMaterialOther).NotNull().WithMessage("{PropertyName} is required."); //if flooringMaterialId is 1001 then
            });
            RuleFor(x => x.lightingSourceId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.lightingSourceId == "1001", () => {
                RuleFor(x => x.lightingSourceOther).NotNull().WithMessage("{PropertyName} is required."); //if lightingSourceId is 1001 then
            });
            RuleFor(x => x.cookingFuelId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.cookingFuelId == "1001", () => {
                RuleFor(x => x.cookingFuelOther).NotNull().WithMessage("{PropertyName} is required."); //if cookingFuelId is 1001 then
            });
            RuleFor(x => x.typeOfToiletId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.typeOfToiletId == "1001", () => {
                RuleFor(x => x.typeOfToiletOther).NotNull().WithMessage("{PropertyName} is required."); //if typeOfToiletId is 1001 then
            });
            RuleFor(x => x.drinkingWaterSourceId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.drinkingWaterSourceId == "1001", () => {
                RuleFor(x => x.drinkingWaterSourceOther).NotNull().WithMessage("{PropertyName} is required."); //if mainsourceofdrinkingwater is 1001 then
            });
            RuleFor(x => x.disposeRubbishId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.disposeRubbishId == "1001", () => {
                RuleFor(x => x.disposeRubbishOther).NotNull().WithMessage("{PropertyName} is required."); //if howhhdisposerubbish is 1001 then
            });


        }
    }
    #endregion
    #region-----------Distance-------
    public class HHDistanceDto
    {
        
        public string distanceid { get; set; }//for update purpose      
        public string serviceid { get; set; }
        public string transportationmodeid { get; set; }
        public string othertransportation { get; set; }
        public string distanceinkm { get; set; }
        public string timeinmin { get; set; }

    }
    public class distanceValidator : AbstractValidator<HHDistanceDto>
    {
        public distanceValidator()
        {
            RuleFor(x => x.serviceid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.transportationmodeid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            When(x => x.transportationmodeid == "1001", () => {
                RuleFor(x => x.othertransportation).NotNull().WithMessage("{PropertyName} is required."); //if transportationmodeid is 1001 then
            });
            RuleFor(x => x.distanceinkm).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.timeinmin).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
    public class distanceValidationFailuremodel
    {
        public IList<ValidationFailuremodel> errors { get; set; }
    }


    #endregion
    #region-----------Asset-------
    public class HHAssetDto
    {
        public string assetdetailid { get; set; }//for update purpose
        public string mediumid { get; set; }
        public string isavailable { get; set; }
        public string totalno { get; set; }
        public string item1age { get; set; }
        public string item2age { get; set; }

    }
    public class asssetValidator : AbstractValidator<HHAssetDto>
    {
        public asssetValidator()
        {
            RuleFor(x => x.mediumid).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.isavailable).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.totalno).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.item1age).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.item2age).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
    public class assetValidationFailuremodel
    {
        public IList<ValidationFailuremodel> errors { get; set; }
    }


    #endregion
}
