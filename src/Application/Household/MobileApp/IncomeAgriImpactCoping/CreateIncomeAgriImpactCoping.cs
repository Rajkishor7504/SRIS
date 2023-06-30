using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
using SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery;
using SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.EduAndHealth.IncomeAgriImpactCoping
{
    public class CreateIncomeAgriImpactCoping : IRequest<IncomeAgriImpactCopingVM>
    {
        public string hhid { get; set; }
        public string action { get; set; }
        public string createdby { get; set; }
        public string apptypeid { get; set; }
        public  HHIncomeDto incomeSource { get;set;}
        public HHAgricultureDto agriCultural { get; set; }
        public HHImpackOfShockDto impactOfShock { get; set; }
        public HHCopingDto copingStrategies { get; set; }

    }
    public class CreateIncomeAgriImpactCopingHandler : IRequestHandler<CreateIncomeAgriImpactCoping, IncomeAgriImpactCopingVM>
    {


        private readonly IHouseholdService _iHouseholdService;
        private readonly IHouseholdServiceMobile _iHouseholdServiceMobile;

        public CreateIncomeAgriImpactCopingHandler(IHouseholdService iHouseholdService, IHouseholdServiceMobile iHouseholdServiceMobile)
        {
            _iHouseholdService = iHouseholdService;
            _iHouseholdServiceMobile = iHouseholdServiceMobile;
        }

        public async Task<IncomeAgriImpactCopingVM> Handle(CreateIncomeAgriImpactCoping request, CancellationToken cancellationToken)
        {


            IncomeAgriImpactCopingVM objList = new IncomeAgriImpactCopingVM();
            try
            {
                int impactretval = 0;
                int agricultureretval = 0;
                int incomeretval = 0;
                int copingretval = 0;
                int registerhouseholdcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("1", Convert.ToInt32(request.hhid),0);
                if (registerhouseholdcnt == 0)
                {
                    objList.status = "404";
                    objList.message = "Household Not Registerd";
                    objList.errorMessage = "";
                }
                else
                {
                    #region-------------income source-----------
                    if (request.incomeSource != null)
                    {
                        //int incomecnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("9", Convert.ToInt32(request.hhid), 0);//8 for asset
                        //if (incomecnt == 0)
                        //{
                            var entity = new IncomeSourceDto();
                            entity.action = request.action;
                            entity.hhid = Convert.ToInt32(request.hhid);
                            entity.incomesourceid = 0;
                            entity.mainincomesourceofhh = Convert.ToInt32(request.incomeSource.mainIncomeSourceId);
                            entity.otherincomesource = request.incomeSource.otherincomesource;
                            entity.secondincomesourceofhh = Convert.ToInt32(request.incomeSource.secondIncomeSourceId);
                            entity.othersecondincomesource = request.incomeSource.othersecondincomesource;
                            entity.didhhreceivemonetaryhelp = request.incomeSource.rcvMnyfrm12MntInd != "" ? Convert.ToInt32(request.incomeSource.rcvMnyfrm12MntInd) : 0;
                            entity.howmanytimesreceivedmonhelp = request.incomeSource.ifYesHowManyTimes != "" ? Convert.ToInt32(request.incomeSource.ifYesHowManyTimes) : 0;
                            entity.amountreceivedinlastoneyear = request.incomeSource.ifYesTotalAmount != "" ? Convert.ToInt32(request.incomeSource.ifYesTotalAmount) : 0;
                            entity.hashhcollectedanyaidinoneyear = request.incomeSource.rcvAidLst12MntFrmOrg != "" ? Convert.ToInt32(request.incomeSource.rcvAidLst12MntFrmOrg) : 0;
                            entity.freequencyofaidreceived = request.incomeSource.ifYesHowFrequentlyId != "" ? Convert.ToInt32(request.incomeSource.ifYesHowFrequentlyId) : 0;
                            entity.otherfreequencyofaidreceived = request.incomeSource.otherfreequencyofaidreceived;
                            //entity.organizationtype = request.incomeSource.organizationtype;
                            entity.aidids = request.incomeSource.ifYesWhatTypeAidId;
                            entity.orgtypeids = request.incomeSource.ifYesWhichTypeOrgId;
                            entity.otheraid = "";
                            entity.otherorgtype = "";
                            entity.createdby = Convert.ToInt32(request.createdby);
                            entity.apptypeid = Convert.ToInt32(request.apptypeid);
                            incomeretval = await _iHouseholdService.AddIncomeSource(entity);
                        //}
                        //else
                        //{
                        //    incomeretval = 200;
                        //}
                    }
                    #endregion
                    #region-------------Agriculture----------------
                    if (request.agriCultural != null)
                    {
                        //int agricnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("10", Convert.ToInt32(request.hhid), 0);//111 for copng
                        //if (agricnt == 0)
                        //{
                            List<Cultivation> cultivation = new List<Cultivation>();
                            if (request.agriCultural.cultivation.Count > 0)
                            {
                                foreach (var item in request.agriCultural.cultivation)
                                {
                                    cultivation.Add(new Cultivation
                                    {
                                        cropid = Convert.ToInt32(item.cropid),
                                        cultivatedinhectares = Convert.ToInt32(item.cultivatedinhectares),
                                        cultivationid = 0
                                    });
                                }
                            }
                            List<CultivationResponsbiliity> cultivationresponsibility = new List<CultivationResponsbiliity>();
                            if (request.agriCultural.cultivationresponsibility.Count > 0)
                            {
                                foreach (var item in request.agriCultural.cultivationresponsibility)
                                {
                                    cultivationresponsibility.Add(new CultivationResponsbiliity
                                    {
                                        cropid = Convert.ToInt32(item.cropid),
                                        nooffemale = Convert.ToInt32(item.nooffemale),
                                        noofmale = Convert.ToInt32(item.noofmale),
                                        responsibilityid = 0,
                                    });
                                }
                            }
                            List<OwnLiveStock> ownlivestock = new List<OwnLiveStock>();
                            if (request.agriCultural.ownlivestock.Count > 0)
                            {
                                foreach (var item in request.agriCultural.ownlivestock)
                                {
                                    ownlivestock.Add(new OwnLiveStock
                                    {
                                        ownid = 0,
                                        nooflivestockown = Convert.ToInt32(item.nooflivestockown),
                                        livestockid = Convert.ToInt32(item.livestockid)
                                    });
                                }
                            }
                            List<BreedingLiveStock> breedinglivestock = new List<BreedingLiveStock>();
                            if (request.agriCultural.breedinglivestock.Count > 0)
                            {
                                foreach (var item in request.agriCultural.breedinglivestock)
                                {
                                    breedinglivestock.Add(new BreedingLiveStock
                                    {
                                        breedid = 0,
                                        responsibilityids = item.responsibilityids,
                                        livestockid = Convert.ToInt32(item.livestockid)
                                    });
                                }
                            }
                        List<EcologyStock> ecologystock = new List<EcologyStock>();
                        if (request.agriCultural.ecology.Count > 0)
                        {
                            foreach (var item in request.agriCultural.ecology)
                            {
                                ecologystock.Add(new EcologyStock
                                {
                                    ecologyid = Convert.ToInt32(item.ecologyid),
                                    //ecologyinhectares = item.ecologyinhectares != "" ? Convert.ToInt32(item.ecologyinhectares) : 0
                                    ecologyinhectares = Convert.ToInt32(item.ecologyinhectares)                              
                                });
                            }
                        }
                        var entity2 = new AgricultureinfoDto();
                            entity2.action = request.action;
                            entity2.hhid = Convert.ToInt32(request.hhid);
                            entity2.doescultivateland = Convert.ToInt32(request.agriCultural.doescultivateland);
                            entity2.ownedland = Convert.ToInt32(request.agriCultural.ownedland);
                            entity2.rentedland = Convert.ToInt32(request.agriCultural.rentedland);
                            entity2.freeland = Convert.ToInt32(request.agriCultural.freeland);
                            entity2.ownedbywhom = Convert.ToInt32(request.agriCultural.ownedbywhom);
                            entity2.rainfedlow = Convert.ToInt32(request.agriCultural.rainfedlow);
                            entity2.rainfedhigh = Convert.ToInt32(request.agriCultural.rainfedhigh);
                            entity2.irrigated = Convert.ToInt32(request.agriCultural.irrigated);
                            entity2.pasture = Convert.ToInt32(request.agriCultural.pasture);
                            entity2.wasanyhhcatchingfish = Convert.ToInt32(request.agriCultural.wasanyhhcatchingfish);
                            entity2.nooffemalecatching = Convert.ToInt32(request.agriCultural.nooffemalecatching);
                            entity2.noofmalecatching = Convert.ToInt32(request.agriCultural.noofmalecatching);
                            entity2.anyonehhownlivestock = Convert.ToInt32(request.agriCultural.anyonehhownlivestock);
                            entity2.createdby = Convert.ToInt32(request.createdby);
                            entity2.apptypeid = Convert.ToInt32(request.apptypeid);
                            entity2.cultivation = cultivation;
                            entity2.cultivationresponsibility = cultivationresponsibility;
                            entity2.breedinglivestock = breedinglivestock;
                            entity2.ownlivestock = ownlivestock;
                            entity2.ecologystock = ecologystock;
                            entity2.agricultureid = 0;
                            agricultureretval = await _iHouseholdService.AddAgricultureInfo(entity2);
                        //}
                        //else
                        //{
                        //    agricultureretval = 1;
                        //}
                    }
                    #endregion
                    #region-------------impack of shocks-----------
                    if (request.impactOfShock != null)
                    {
                        //int impactcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("11", Convert.ToInt32(request.hhid), 0);//11 for imapct
                        //if (impactcnt == 0)
                        //{
                            var entity3 = new ImpactDto();
                            entity3.action = request.action;
                            entity3.hhid = Convert.ToInt32(request.hhid);
                            entity3.impactid = 0;
                            entity3.ishhaffectedbyevent = request.impactOfShock.ishhaffectedbyevent != "" ? Convert.ToInt32(request.impactOfShock.ishhaffectedbyevent) : 0;
                            entity3.livelyhoodaffectedids = request.impactOfShock.livelyhoodaffectedids;
                            entity3.shockforcropid = request.impactOfShock.shockforcropid != "" ? Convert.ToInt32(request.impactOfShock.shockforcropid) : 0;
                            entity3.shockforlivestockid = request.impactOfShock.shockforlivestockid != "" ? Convert.ToInt32(request.impactOfShock.shockforlivestockid) : 0;
                            entity3.shockforlabourid = request.impactOfShock.shockforlabourid != "" ? Convert.ToInt32(request.impactOfShock.shockforlabourid) : 0;
                            entity3.othershockforcrop = request.impactOfShock.othershockforcrop;
                            entity3.othershockforlivestock = request.impactOfShock.othershockforlivestock;
                            entity3.othershockforlabour = request.impactOfShock.othershockforlabour;
                            entity3.typeofserveritylivestock = request.impactOfShock.typeofserveritylivestock != "" ? Convert.ToInt32(request.impactOfShock.typeofserveritylivestock) : 0;
                            entity3.typeofseveritycrops = request.impactOfShock.typeofseveritycrops != "" ? Convert.ToInt32(request.impactOfShock.typeofseveritycrops) : 0;
                            entity3.typeofseveritylabour = request.impactOfShock.typeofseveritylabour != "" ? Convert.ToInt32(request.impactOfShock.typeofseveritylabour) : 0;
                            entity3.shockforotherid = request.impactOfShock.shockforotherid != "" ? Convert.ToInt32(request.impactOfShock.shockforotherid) : 0;
                            entity3.othershockforother = request.impactOfShock.othershockforother;
                            entity3.typeofseverityother = request.impactOfShock.typeofseverityother != "" ? Convert.ToInt32(request.impactOfShock.typeofseverityother) : 0;
                            entity3.otheraffectedlivelyhood = request.impactOfShock.otherLiveHood;
                            entity3.createdby = Convert.ToInt32(request.createdby);
                            entity3.apptypeid = Convert.ToInt32(request.apptypeid);
                            impactretval = await _iHouseholdService.AddImpactOfShocks(entity3);

                        //}
                        //else
                        //{
                        //    impactretval = 200;
                        //}
                    }
                    #endregion
                    #region-------------coping-----------
                    if (request.copingStrategies != null)
                    {
                        //int copingcnt = await _iHouseholdServiceMobile.CheckRegisterHousehold("12", Convert.ToInt32(request.hhid), 0);//12 for copng
                        //if (copingcnt == 0)
                        //{
                            List<FoodCoping> foodcoping = new List<FoodCoping>();
                            if (request.copingStrategies.foodcoping.Count > 0)
                            {
                                foreach (var item in request.copingStrategies.foodcoping)
                                {
                                    foodcoping.Add(new FoodCoping
                                    {

                                        fcopingid = Convert.ToInt32(item.lcopingid),
                                        fresortingneedid = Convert.ToInt32(item.lresortingneedid)
                                    });
                                }
                            }
                            List<LivelihoodCoping> livehlihoodcoping = new List<LivelihoodCoping>();
                            if (request.copingStrategies.livehlihoodcoping.Count > 0)
                            {
                                foreach (var item1 in request.copingStrategies.livehlihoodcoping)
                                {
                                    livehlihoodcoping.Add(new LivelihoodCoping
                                    {

                                        lcopingid = Convert.ToInt32(item1.lcopingid),
                                        lresortingneedid = Convert.ToInt32(item1.lresortingneedid)
                                    });
                                }
                            }
                            var entity4 = new CopingInfoDto();
                            entity4.action = request.action;
                            entity4.hhid = Convert.ToInt32(request.hhid);
                            entity4.livehlihoodcoping = livehlihoodcoping;
                            entity4.foodcoping = foodcoping;
                            entity4.createdby = Convert.ToInt32(request.createdby);
                            entity4.copingid = 0;
                            entity4.apptypeid = Convert.ToInt32(request.apptypeid);
                            copingretval = await _iHouseholdService.AddCopingInfo(entity4);
                        //}
                        //else
                        //{
                        //    copingretval = 200;
                        //}
                    }
                    #endregion
                    //if (incomeretval == 200 && agricultureretval ==200 && impactretval == 200 && copingretval == 200)
                    if( request.copingStrategies != null 
                    ||  request.impactOfShock != null 
                    ||  request.agriCultural != null 
                    ||  request.incomeSource != null)
                    {
                        objList.status = MobileApiStatusCode.OK;
                        objList.message = "Success";
                        objList.errorMessage = "";
                    }
                    else
                    {
                        objList.status = MobileApiStatusCode.Badrequest;
                        objList.message = "Bad request";
                        objList.errorMessage = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objList.status = "500";
                objList.message = ex.Message;
                objList.errorMessage = ex.Message;
            }
            return objList;

        }
    }
}
