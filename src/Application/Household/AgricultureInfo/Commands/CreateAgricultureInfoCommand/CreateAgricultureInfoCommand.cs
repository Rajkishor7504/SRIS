using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.AgricultureInfo.Commands
{
  public class CreateAgricultureInfoCommand:IRequest<AgricultureInfoList>
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
        public List<Cultivation> cultivation { get; set; }
        public List<CultivationResponsbiliity> cultivationresponsibility { get; set; }
        public List<OwnLiveStock> ownlivestock { get; set; }
        public List<BreedingLiveStock> breedinglivestock { get; set; }

    }
    public class CreateAgricultureInfoCommandHandler : IRequestHandler<CreateAgricultureInfoCommand, AgricultureInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateAgricultureInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<AgricultureInfoList> Handle(CreateAgricultureInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            AgricultureInfoList objAgriList = new AgricultureInfoList();
            int validationcount = 0;
            try
            {
                if (request.hhid == 0 && request.action == "A")
                {
                    objAgriList.status = "400";
                    objAgriList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new AgricultureinfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.doescultivateland = request.doescultivateland;
                    entity.ownedland = request.ownedland;
                    entity.rentedland = request.rentedland;
                    entity.freeland = request.freeland;
                    entity.ownedbywhom = request.ownedbywhom;
                    entity.rainfedlow = request.rainfedlow;
                    entity.rainfedhigh = request.rainfedhigh;
                    entity.irrigated = request.irrigated;
                    entity.pasture = request.pasture;
                    entity.wasanyhhcatchingfish = request.wasanyhhcatchingfish;
                    entity.nooffemalecatching = request.nooffemalecatching;
                    entity.noofmalecatching = request.noofmalecatching;
                    entity.anyonehhownlivestock = request.anyonehhownlivestock;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    entity.cultivation = request.cultivation;
                    entity.cultivationresponsibility = request.cultivationresponsibility;
                    entity.breedinglivestock = request.breedinglivestock;
                    entity.ownlivestock = request.ownlivestock;
                    entity.agricultureid = request.agricultureid;
                    retval = await _iHouseholdService.AddAgricultureInfo(entity);
                    objAgriList.status = retval.ToString();
                    objAgriList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objAgriList.status = "500";
                objAgriList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objAgriList.errorMessage = ex.Message;
            }
            return objAgriList;

        }
    }
}
