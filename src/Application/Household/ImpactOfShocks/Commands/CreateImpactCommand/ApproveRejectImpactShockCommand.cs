using MediatR;
using SRIS.Application.Common.Interfaces;
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
   public  class ApproveRejectImpactShockCommand: IRequest<ImpactOfShocksList>
    {
        public int createdby { get; set; }
        public int hhid { get; set; }
        public int impactid { get; set; }
        public string Action { get; set; }
        public string Remark { get; set; }
        public int Gregid { get; set; }

    }
    public class ApproveRejectImpactShockCommandHandler : IRequestHandler<ApproveRejectImpactShockCommand, ImpactOfShocksList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public ApproveRejectImpactShockCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<ImpactOfShocksList> Handle(ApproveRejectImpactShockCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            ImpactOfShocksList obj = new ImpactOfShocksList();

            try
            {

                retval = await _iHouseholdService.ApproveRejectImpactOfShocks(request.impactid, request.hhid, request.createdby,request.Action, request.Remark, request.Gregid);
                obj.status = Convert.ToString(retval);
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);

            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                obj.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return obj;
        }
    }
}
