using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SRIS.Application.Household.Registerhousehold.Commands.CreateRegisterHousehold
{
    public class ApproveRejectRegisterHouseholdCommand : IRequest<RegisterHouseholdList>
    {
        public int hhid { get; set; }
        public int createdby { get; set; }
        public string ActionType { get; set; }
        public string Remark { get; set; }
        public int Gregid { get; set; }
    }
    public class ApproveRegisterHouseholdCommandHandler : IRequestHandler<ApproveRejectRegisterHouseholdCommand, RegisterHouseholdList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public ApproveRegisterHouseholdCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }
        public async Task<RegisterHouseholdList> Handle(ApproveRejectRegisterHouseholdCommand request, CancellationToken cancellationToken)
        {
            RegisterHouseholdList obj = new RegisterHouseholdList();
            int retval = 0;
            try
            {

                retval = await _iHouseholdService.ApproveRejectRegisterHousehold(request.hhid, request.createdby,request.ActionType,request.Remark,request.Gregid);
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
