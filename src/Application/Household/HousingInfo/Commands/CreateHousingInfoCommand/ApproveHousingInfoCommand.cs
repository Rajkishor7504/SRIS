using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.HousingInfo.Commands
{
    public class ApproveHousingInfoCommand : IRequest<HousingInfoList>
    {
        public int createdby { get; set; }
        public int hhid { get; set; }
        public string Action { get; set; }
        public string Remark { get; set; }
        public int Gregid { get; set; }
    }
    public class ApproveHousingInfoCommandHandler : IRequestHandler<ApproveHousingInfoCommand, HousingInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public ApproveHousingInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HousingInfoList> Handle(ApproveHousingInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            HousingInfoList obj = new HousingInfoList();

            try
            {

                retval = await _iHouseholdService.ApproveRejectHousingInfo(request.hhid, request.createdby,request.Action, request.Remark, request.Gregid);
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
