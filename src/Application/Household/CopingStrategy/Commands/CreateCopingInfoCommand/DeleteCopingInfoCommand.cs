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

namespace SRIS.Application.Household.CopingStrategy.Commands
{
    public class DeleteCopingInfoCommand: IRequest<CopingStrategyList>
    {
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int copingid { get; set; }
    }
    public class DeleteCopingInfoCommandHandler : IRequestHandler<DeleteCopingInfoCommand, CopingStrategyList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteCopingInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CopingStrategyList> Handle(DeleteCopingInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            CopingStrategyList obj = new CopingStrategyList();

            try
            {

                retval = await _iHouseholdService.DeleteCopingInfo(request.copingid, request.createdby, request.hhid);
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
