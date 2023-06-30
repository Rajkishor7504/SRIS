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

namespace SRIS.Application.Household.EmploymentInfo.Commands.CreateEmpInfoCommand
{
   public class DeleteEmploymentInfoCommand:IRequest<EmploymentInfoList>
    {
        public int employmentinfoid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string action { get; set; }
    }
    public class DeleteEmploymentInfoCommandHandler : IRequestHandler<DeleteEmploymentInfoCommand, EmploymentInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteEmploymentInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<EmploymentInfoList> Handle(DeleteEmploymentInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            EmploymentInfoList obj = new EmploymentInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteEmploymentInfo(request.employmentinfoid, request.createdby, request.apptypeid);
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
