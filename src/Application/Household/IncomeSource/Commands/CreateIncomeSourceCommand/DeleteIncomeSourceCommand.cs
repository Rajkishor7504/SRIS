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

namespace SRIS.Application.Household.IncomeSource.Commands
{
    public class DeleteIncomeSourceCommand: IRequest<IncomeSourceList>
    {
        public int incomesourceid { get; set; }
        public int createdby { get; set; }
        public int hhid { get; set; }
    }
    public class DeleteIncomeSourceCommandHandler : IRequestHandler<DeleteIncomeSourceCommand, IncomeSourceList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteIncomeSourceCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<IncomeSourceList> Handle(DeleteIncomeSourceCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            IncomeSourceList obj = new IncomeSourceList();

            try
            {

                retval = await _iHouseholdService.DeleteIncomeSource(request.incomesourceid, request.createdby, request.hhid);
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
