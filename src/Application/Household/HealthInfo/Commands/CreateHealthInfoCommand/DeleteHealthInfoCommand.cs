using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.EducationInfo.Commands;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.HealthInfo.Commands
{
   public class DeleteHealthInfoCommand: IRequest<HealthInfoList>
    {
        public int memberid { get; set; }
        public int createdby { get; set; }
        public int healthinfoid { get; set; }
        public int apptypeid { get; set; }
        public string action { get; set; }
    }
    public class DeleteHealthInfoCommandHandler : IRequestHandler<DeleteHealthInfoCommand, HealthInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteHealthInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HealthInfoList> Handle(DeleteHealthInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            HealthInfoList obj = new HealthInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteHealthInfo(request.healthinfoid, request.createdby, request.apptypeid,request.action);
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
