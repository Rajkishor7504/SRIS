using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.QASurvey.Query;
using SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.QASurvey.Command
{
   public class UpdateVerifyStatusHouseholdCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public string remarks { get; set; }
        public int moduleid { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int verifystatus { get; set; }
      
    }
    public class UpdateStatusRegisterHouseholdCommandHandler : IRequestHandler<UpdateVerifyStatusHouseholdCommand, CommonMobileApiStatus>
    {
        private readonly IApplicationDbContext _context;


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusRegisterHouseholdCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateVerifyStatusHouseholdCommand request, CancellationToken cancellationToken)
        {
            CommonMobileApiStatus obj = new CommonMobileApiStatus();
            int retval = 0;
            try
            {
                if (request.hhid == 0  && request.moduleid == 0 )
                {
                    obj.status = "400";
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new AllHouseholdStatusDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.moduleid = request.moduleid;
                    entity.verifystatus = request.verifystatus;                  
                    entity.remarks = request.remarks;
                    entity.createdby = request.createdby;                   
                    retval = await _iHouseholdService.UpdateStatusOfHousehold(entity);
                    obj.status = retval.ToString();
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
            }
            return obj;
        }
    }
}
