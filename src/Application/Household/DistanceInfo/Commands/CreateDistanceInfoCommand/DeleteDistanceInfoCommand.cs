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

namespace SRIS.Application.Household.DistanceInfo.Commands
{
    public class DeleteDistanceInfoCommand: IRequest<DistanceInfoList>
    {
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
    }
    public class DeleteDistanceInfoCommandHandler : IRequestHandler<DeleteDistanceInfoCommand, DistanceInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteDistanceInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<DistanceInfoList> Handle(DeleteDistanceInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            DistanceInfoList obj = new DistanceInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteDistanceInfo(request.hhid, request.createdby,request.apptypeid);
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
