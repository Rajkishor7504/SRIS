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

namespace SRIS.Application.Household.AgricultureInfo.Commands
{
    public class DeleteAgriCultureInfoCommand : IRequest<AgricultureInfoList>
    {
        public int createdby { get; set; }
        public int hhid { get; set; }
        public int agricultureid { get; set; }
        public int apptypeid { get; set; }
    }
    public class DeleteAgriCultureInfoCommandHandler : IRequestHandler<DeleteAgriCultureInfoCommand, AgricultureInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteAgriCultureInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<AgricultureInfoList> Handle(DeleteAgriCultureInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            AgricultureInfoList obj = new AgricultureInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteAgricultureInfo(request.agricultureid,request.hhid, request.createdby,request.apptypeid);
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
