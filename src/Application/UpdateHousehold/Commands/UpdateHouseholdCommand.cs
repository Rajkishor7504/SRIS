using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Application.UpdateHousehold.Queries;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UpdateHousehold.Commands
{
    public class UpdateHouseholdCommand : IRequest<int>
    {
        public string action { get; set; }
        public string householdno { get; set; }
        public int updatepriorityid { get; set; }
        public string hhheadname { get; set; }
        public DateTime updatedate { get; set; }
        public string updatecategoryid { get; set; }
        public string contactno { get; set; }
        public int updatesourceid { get; set; }
        public string updatedescription { get; set; }
        public int createdby { get; set; }
        public int status { get; set; }
        public string updatereason { get; set; }
        public int requestid { get; set; }
        public int updcatagorydetailsid { get; set; }
        public string updatecatagoriesid { get; set; }
        public int grievanceregistrationid { get; set; }
        public int hhid { get;set;}


    }
    public class UpdateHouseholdCommandHandler : IRequestHandler<UpdateHouseholdCommand, int>
    {
        private readonly IUpdateHouseholdService _iUpdateHouseholdService;
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IGrievanceService _igrievanceService;

        public UpdateHouseholdCommandHandler(IUpdateHouseholdService iUpdateHouseholdService, IApplicationDbContext context, IDateTime dateTime, IGrievanceService igrievanceService)
        {
            _iUpdateHouseholdService = iUpdateHouseholdService;
            _context = context;
            _dateTime = dateTime;
            _igrievanceService = igrievanceService;

        }

        public async Task<int> Handle(UpdateHouseholdCommand request, CancellationToken cancellationToken)
        {
            var entity = new UpdateHouseholdDto();
           // var entity1 = new UpdCatagoryDetails();
            int retval = 0;
            try
            {
                
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.householdno = request.householdno;
                    entity.updatepriorityid = request.updatepriorityid;
                    entity.hhheadname = request.hhheadname;
                    entity.updatedate = request.updatedate;
                    entity.updatecategoryid = request.updatecategoryid;
                    entity.contactno = request.contactno;
                    entity.updatesourceid = request.updatesourceid;
                    entity.updatedescription = request.updatedescription;
                    entity.createdby = request.createdby;
                    entity.status = request.status;
                    entity.updatereason = request.updatereason;
                    entity.grievanceregistrationid = request.grievanceregistrationid;
                    entity.requestid = request.requestid;
                    retval = await _iUpdateHouseholdService.UpdateHousehold(entity);
                if (retval == 1 && entity.status == 0)
                {
                    var entity1 = new NotificationMasterDto();
                    var Hhcode = request.householdno;
                    entity1.CreatedBy = request.createdby;
                    //entity1.refNo = Convert.ToInt32(Hhcode);
                    entity1.Information = "The Household Number : " + Hhcode + " , Pending for Approved";
                    entity1.DestinationURL = Hhcode;
                    await _igrievanceService.AddUpdateOfficerNotification(entity1);
                }
                
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return retval;

        }
    }

}
