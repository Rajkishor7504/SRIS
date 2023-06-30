using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery
{
    public class GetAgricultureInfoQuery: IRequest<AgricultureinfoVM>
    {
        public string action { get; set; }
        public int hhid { get; set; }

        public int agricultureid { get; set; }
    }
    public class GetDistanceInfoQueryHandler : IRequestHandler<GetAgricultureInfoQuery, AgricultureinfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetDistanceInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<AgricultureinfoVM> Handle(GetAgricultureInfoQuery request, CancellationToken cancellationToken)
        {
            AgricultureinfoVM objVM = new AgricultureinfoVM();
            
            try
            {
                if (request.action == "E")
                {
                    List<AgricultureinfoDto> agrilist = null;
                    List<AgricultureinfoDto> cultivation = null;
                    List<AgricultureinfoDto> responsibility = null;
                    List<AgricultureinfoDto> ownlivestock = null;
                    List<AgricultureinfoDto> breedingstock = null;
                    List<AgricultureinfoDto> ecologydetails = null;
                    List<Cultivation> cultivationlist = new List<Cultivation>();
                    List<CultivationResponsbiliity> cultivationresponsibilitylist = new List<CultivationResponsbiliity>();
                    List<OwnLiveStock> livestocklist = new List<OwnLiveStock>();
                    List<BreedingLiveStock> breedinglist = new List<BreedingLiveStock>();
                    List<ecologyview> ecologydetailslist = new List<ecologyview>();
                    objVM.status = "200";
                    objVM.Lists = await _iHouseholdService.GetAgricultureInfo(request);
                    agrilist = objVM.Lists.Where(x => x.querytype == 1).ToList();

                    cultivation = objVM.Lists.Where(x => x.querytype == 2).ToList();
                    responsibility = objVM.Lists.Where(x => x.querytype == 3).ToList();
                    ownlivestock = objVM.Lists.Where(x => x.querytype == 4).ToList();
                    breedingstock = objVM.Lists.Where(x => x.querytype == 5).ToList();
                    ecologydetails = objVM.Lists.Where(x => x.querytype == 6).ToList();
                    foreach (AgricultureinfoDto agridto in cultivation)
                        cultivationlist.Add(new Cultivation { cropid = agridto.doescultivateland, cultivatedinhectares = agridto.ownedland, cultivationid = agridto.transid });
                    foreach (AgricultureinfoDto agridto in responsibility)
                        cultivationresponsibilitylist.Add(new CultivationResponsbiliity { responsibilityid = agridto.transid, cropid = agridto.doescultivateland, noofmale = agridto.ownedland, nooffemale = agridto.rentedland });
                    foreach (AgricultureinfoDto agridto in ownlivestock)
                        livestocklist.Add(new OwnLiveStock { ownid = agridto.transid, livestockid = agridto.doescultivateland, nooflivestockown = agridto.ownedland });
                    foreach (AgricultureinfoDto agridto in breedingstock)
                        breedinglist.Add(new BreedingLiveStock { livestockid = agridto.doescultivateland, responsibilityids = agridto.action });

                    foreach (AgricultureinfoDto agridto in ecologydetails)
                        ecologydetailslist.Add(new ecologyview { ecologyid = agridto.transid, agricultureid = agridto.agricultureid, ecologyvalue = agridto.doescultivateland });


                    objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                    agrilist[0].cultivation = cultivationlist;
                    agrilist[0].cultivationresponsibility = cultivationresponsibilitylist;
                    agrilist[0].ownlivestock = livestocklist;
                    agrilist[0].breedinglivestock = breedinglist;
                    agrilist[0].cultivation = cultivationlist;
                    agrilist[0].ecologydetails = ecologydetailslist;
                    objVM.Lists = agrilist;
                }

                else if (request.action=="V")
                {
                    objVM.status = "200";
                    objVM.Lists = await _iHouseholdService.GetAgricultureInfo(request);
                    objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                }
                else if (request.action == "UA")
                {
                    objVM.status = "200";
                    objVM.Lists = await _iHouseholdService.GetAgricultureInfo(request);
                    objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                }
                else
                {
                    List<AgricultureinfoDto> agrilist = new List<AgricultureinfoDto>();
                    List<AgricultureinfoDto> cultivation = null;
                    List<AgricultureinfoDto> responsibility = null;
                    List<AgricultureinfoDto> ownlivestock = null;
                    List<AgricultureinfoDto> breedingstock = null;
                    List<CultivationView> cultivationlist = new List<CultivationView>();
                    List<CultivationResponsbiliityView> cultivationresponsibilitylist = new List<CultivationResponsbiliityView>();
                    List<OwnLiveStockView> livestocklist = new List<OwnLiveStockView>();
                    List<BreedingLiveStockView> breedinglist = new List<BreedingLiveStockView>();
                    objVM.status = "200";
                    objVM.Lists = await _iHouseholdService.GetAgricultureInfo(request);
                    agrilist = objVM.Lists.Where(x => x.querytype == 1).ToList();

                    cultivation = objVM.Lists.Where(x => x.querytype == 2).ToList();
                    responsibility = objVM.Lists.Where(x => x.querytype == 3).ToList();
                    ownlivestock = objVM.Lists.Where(x => x.querytype == 4).ToList();
                    breedingstock = objVM.Lists.Where(x => x.querytype == 5).ToList();
                    foreach (AgricultureinfoDto agridto in cultivation)
                    cultivationlist.Add(new CultivationView { cropv = agridto.doescultivatelandv, cultivatedinhectaresv = agridto.ownedlandv});
                    foreach (AgricultureinfoDto agridto in responsibility)
                    cultivationresponsibilitylist.Add(new CultivationResponsbiliityView { cropv = agridto.doescultivatelandv, noofmalev = agridto.ownedlandv, nooffemalev = agridto.rentedlandv });
                    foreach (AgricultureinfoDto agridto in ownlivestock)
                    livestocklist.Add(new OwnLiveStockView { livestockv = agridto.doescultivatelandv, nooflivestockownv = agridto.ownedlandv });
                    foreach (AgricultureinfoDto agridto in breedingstock)
                    breedinglist.Add(new BreedingLiveStockView { livestockv = agridto.doescultivatelandv, responsibilityidsv = agridto.anyonehhownlivestockv });

                    objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                    agrilist[0].cultivationv = cultivationlist;
                    agrilist[0].cultivationresponsibilityv = cultivationresponsibilitylist;
                    agrilist[0].ownlivestockv = livestocklist;
                    agrilist[0].breedinglivestockv = breedinglist;
                    agrilist[0].cultivationv = cultivationlist;
                    objVM.Lists = agrilist;
                }
            }
            catch (Exception ex)
            {
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;
        }
        public async Task<string> getResponsibilityids(List<AgricultureinfoDto> breedinglist,int livestockid)
        {
            StringBuilder responsibilityids =new StringBuilder("");
            breedinglist = breedinglist.Where(x => x.doescultivateland == livestockid).ToList();
            foreach (AgricultureinfoDto objBreeding in breedinglist)
            {
                responsibilityids.Append(Convert.ToString(objBreeding.ownedland)+",");
            }
            return responsibilityids.ToString().TrimEnd(',');
        }
    }
}
