using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.IncomeAgriImpactCoping.Query
{
   public class GetIncomeAgriImpactCopingQuery : IRequest<IncomeAgriImpactCopingQueryVM>
    {
        public string hhid { get; set; }
    }
    public class GetIncomeAgriImpactCopingQueryHandler : IRequestHandler<GetIncomeAgriImpactCopingQuery, IncomeAgriImpactCopingQueryVM>
    {


        private readonly IHouseholdServiceMobile _iHouseholdService;

        public GetIncomeAgriImpactCopingQueryHandler(IHouseholdServiceMobile iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<IncomeAgriImpactCopingQueryVM> Handle(GetIncomeAgriImpactCopingQuery request, CancellationToken cancellationToken)
        {
            IncomeAgriImpactCopingQueryVM objVM = new IncomeAgriImpactCopingQueryVM();
            try
            {
                #region
                AgriCulturalModelVM model = new AgriCulturalModelVM();

                List<CultivationModelVM> cultivationm = new List<CultivationModelVM>();
                List<CultivationResponsbiliityModelVM> responsibilitym = new List<CultivationResponsbiliityModelVM>();
                List<OwnLiveStockModelVM> ownlivestockm = new List<OwnLiveStockModelVM>();
                List<BreedingLiveStockModelVM> breedingstockm = new List<BreedingLiveStockModelVM>();
                List<EcologyModelVM> ecologystockm = new List<EcologyModelVM>();

                var agrdetails = await _iHouseholdService.GetAgricuralList(request);

                var agrilist = agrdetails.Where(x => x.querytype == 1).FirstOrDefault();
                var cultivation = agrdetails.Where(x => x.querytype == 2).ToList();
                var responsibility = agrdetails.Where(x => x.querytype == 3).ToList();
                var ownlivestock = agrdetails.Where(x => x.querytype == 4).ToList();
                var breedingstock = agrdetails.Where(x => x.querytype == 5).ToList();
                var ecologystock = agrdetails.Where(x => x.querytype == 6).ToList();

                model.agricultureId = agrilist != null ? agrilist.agricultureid.ToString() : "0";
                model.ownedbywhom = agrilist != null && agrilist.ownedbywhom!=null ? agrilist.ownedbywhom: "0";
                model.ownedland = agrilist!=null && agrilist.ownedland != null ? agrilist.ownedland : "0";
                model.rentedland = agrilist != null && agrilist.rentedland != null ? agrilist.rentedland : "0";
                model.freeland = agrilist != null && agrilist.freeland != null ? agrilist.freeland : "0";
                model.doescultivateland = agrilist != null && agrilist.doescultivateland != null ? agrilist.doescultivateland : "";
                model.rainfedlow = agrilist != null && agrilist.rainfedlow != null ? agrilist.rainfedlow : "0";
                model.rainfedhigh = agrilist != null && agrilist.rainfedhigh != null ? agrilist.rainfedhigh : "0";
                model.irrigated = agrilist != null && agrilist.irrigated != null ? agrilist.irrigated : "0";
                model.pasture = agrilist != null && agrilist.pasture != null ? agrilist.pasture : "0";
                model.wasanyhhcatchingfish = agrilist != null && agrilist.wasanyhhcatchingfish != null ? agrilist.wasanyhhcatchingfish : "";

                model.nooffemalecatching = agrilist != null && agrilist.nooffemalecatching != null ? agrilist.nooffemalecatching : "0";
                model.noofmalecatching = agrilist != null && agrilist.noofmalecatching != null ? agrilist.noofmalecatching : "0";
                model.anyonehhownlivestock = agrilist != null && agrilist.anyonehhownlivestock != null ? agrilist.anyonehhownlivestock : "";
                model.rejected_status = agrilist != null && agrilist.rejected_status != null ? agrilist.rejected_status : "";
                model.reject_message = agrilist != null && agrilist.reject_message != null ? agrilist.reject_message : "";
                model.statusid = agrilist != null && agrilist.statusid != null ? agrilist.statusid : "";
                model.completedStatus = "Completed";

                foreach (var agridto in cultivation)
                    cultivationm.Add(new CultivationModelVM { 
                        cropid = agridto.doescultivateland, 
                        cropName = agridto.freeland,
                        cultivationid= agridto.transid,
                        cultivatedinhectares=agridto.ownedland });

                foreach (var agridto in responsibility)
                    responsibilitym.Add(new CultivationResponsbiliityModelVM {
                        cropid = agridto.doescultivateland, 
                        noofmale = agridto.ownedland, 
                        nooffemale = agridto.rentedland ,
                        cropName= agridto.freeland,
                        responsibilityid= agridto.transid });

                foreach (var agridto in ownlivestock)
                    ownlivestockm.Add(new OwnLiveStockModelVM {
                        livestockid = agridto.doescultivateland, 
                        liveStockName = agridto.freeland,
                        ownid = agridto.transid, 
                        nooflivestockown = agridto.ownedland });

                foreach (var agridto in breedingstock)
                    breedingstockm.Add(new BreedingLiveStockModelVM {
                        livestockid = agridto.doescultivateland,
                        liveStockName= agridto.freeland, 
                        responsibilityids = agridto.rentedland,
                        responsibilityNms= agridto.ownedland,
                        breedid = agridto.transid });

                foreach (var agridto in ecologystock)
                    ecologystockm.Add(new EcologyModelVM
                    {
                        ecologyName = agridto.freeland,
                        ecologyid = agridto.transid,
                        ecologyinhectares = agridto.doescultivateland,
                        eclid = "0"
                    });

                model.cultivation = cultivationm;
                model.cultivationresponsibility = responsibilitym;
                model.ownlivestock = ownlivestockm;
                model.breedinglivestock = breedingstockm;
                model.ecology = ecologystockm;
                #endregion

                objVM.incomeSource = await _iHouseholdService.GetIncomesourceList(request);// Income Source Details
                if (agrdetails.Count > 0)
                {
                    objVM.agriCultural = model;//Agriculture details
                }
                else
                {
                    objVM.agriCultural = null;//Agriculture details
                }
                                
                objVM.impactOfShock = await _iHouseholdService.GetImpactOfShocksList(request);// Impact Of Shocks

                CopingModelVM coping = new CopingModelVM();
                coping.livehlihoodcoping= await _iHouseholdService.GetCopingLivehoodList(request);

                coping.foodcoping = await _iHouseholdService.GetCopingFoodList(request);            
                var copingdetails = await _iHouseholdService.GetCopingDetails(request);
                coping.statusid = copingdetails!= null && copingdetails.statusid != null ? copingdetails.statusid : "";
                coping.rejected_status = copingdetails != null && copingdetails.rejected_status != null ? copingdetails.rejected_status : "";
                coping.reject_message = copingdetails != null && copingdetails.reject_message != null ? copingdetails.reject_message : "";
                coping.copingId = copingdetails != null && copingdetails.copingId != null ? copingdetails.copingId : "0";
                coping.completedStatus = "Completed";

                if(coping.livehlihoodcoping.Count>0)//Coping Strategies
                {
                    objVM.copingStrategies = coping;
                }
                else
                {
                    objVM.copingStrategies = null;
                }
                
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                objVM.errorMessage = "";
            }

            catch (Exception ex)
            {
                objVM.incomeSource = null;
                objVM.agriCultural = null;
                objVM.impactOfShock = null;
                objVM.copingStrategies = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;

        }
    }
}
