using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.ImpactOfShocks.Commands
{
   public class CreateImpactCommand:IRequest<ImpactOfShocksList>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int impactid { get; set; }
        public int ishhaffectedbyevent { get; set; }
        public string livelyhoodaffectedids { get; set; }
        public int shockforcropid { get; set; }
        public int shockforlivestockid { get; set; }
        public int shockforlabourid { get; set; }
        public string othershockforcrop { get; set; }
        public string othershockforlivestock { get; set; }
        public string othershockforlabour { get; set; }
        public int typeofserveritylivestock { get; set; }
        public int typeofseveritycrops { get; set; }
        public int typeofseveritylabour { get; set; }
        public int shockforotherid { get; set; }
        public string othershockforother { get; set; }
        public int typeofseverityother { get; set; }
        public string otheraffectedlivelyhood { get; set; }
    }
    public class CreateImpactCommandHandler : IRequestHandler<CreateImpactCommand, ImpactOfShocksList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateImpactCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<ImpactOfShocksList> Handle(CreateImpactCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            ImpactOfShocksList objImpactList = new ImpactOfShocksList();
            try
            {
                if ((request.hhid == 0 && request.action == "U") || request.ishhaffectedbyevent == 0 || request.livelyhoodaffectedids == "")
                {
                    objImpactList.status = "400";
                    objImpactList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new ImpactDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.impactid= request.impactid;
                    entity.ishhaffectedbyevent = request.ishhaffectedbyevent;
                    entity.livelyhoodaffectedids = request.livelyhoodaffectedids;
                    entity.shockforcropid = request.shockforcropid;
                    entity.shockforlivestockid = request.shockforlivestockid;
                    entity.shockforlabourid = request.shockforlabourid;
                    entity.othershockforcrop = request.othershockforcrop;
                    entity.othershockforlivestock = request.othershockforlivestock;
                    entity.othershockforlabour = request.othershockforlabour;
                    entity.typeofserveritylivestock = request.typeofserveritylivestock;
                    entity.typeofseveritycrops = request.typeofseveritycrops;
                    entity.typeofseveritylabour = request.typeofseveritylabour;
                    entity.shockforotherid = request.shockforotherid;
                    entity.othershockforother = request.othershockforother;
                    entity.typeofseverityother = request.typeofseverityother;
                    entity.otheraffectedlivelyhood = request.otheraffectedlivelyhood;
                    
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddImpactOfShocks(entity);
                    objImpactList.status = retval.ToString();
                    objImpactList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objImpactList.status = "500";
                objImpactList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objImpactList.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return objImpactList;

        }
    }
}
