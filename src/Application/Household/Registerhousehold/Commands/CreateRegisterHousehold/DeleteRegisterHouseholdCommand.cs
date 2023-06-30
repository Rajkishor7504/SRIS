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

namespace SRIS.Application.Household.Registerhousehold.Commands
{
   public class DeleteRegisterHouseholdCommand: IRequest<RegisterHouseholdList>
    {
        public int hhid { get; set; }
        public int createdby { get; set; }
    }
    public class DeleteConfigureCommiteeCommandHandler : IRequestHandler<DeleteRegisterHouseholdCommand, RegisterHouseholdList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteConfigureCommiteeCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<RegisterHouseholdList> Handle(DeleteRegisterHouseholdCommand request, CancellationToken cancellationToken)
        {
            RegisterHouseholdList obj = new RegisterHouseholdList();
            int retval = 0;
            try
            {
              
                retval = await _iHouseholdService.DeleteRegisterHousehold(request.hhid, request.createdby);
                obj.status = Convert.ToString(retval);
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                obj.errorMessage = ex.Message;
            }
            return obj;
        }
    }
    }
