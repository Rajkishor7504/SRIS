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

namespace SRIS.Application.Household.HousingInfo.Commands
{
   public class DeleteHousingInfoCommand:IRequest<HousingInfoList>
    {
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int housinginfoid { get; set; }
    }
    public class DeleteHousingInfoCommandHandler : IRequestHandler<DeleteHousingInfoCommand,HousingInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteHousingInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HousingInfoList> Handle(DeleteHousingInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            HousingInfoList obj = new HousingInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteHousingInfo(request.housinginfoid, request.createdby, request.apptypeid);
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
