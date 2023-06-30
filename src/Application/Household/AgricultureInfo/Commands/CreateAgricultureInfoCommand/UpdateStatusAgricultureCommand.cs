using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.AgricultureInfo.Queries.GetAgricultureInfoQuery;
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
  public  class UpdateStatusAgricultureCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int agricultureid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
    }

    public class UpdateStatusAgricultureCommandHandler : IRequestHandler<UpdateStatusAgricultureCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusAgricultureCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusAgricultureCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objAgriList = new CommonMobileApiStatus();
          
            try
            {
                if (request.hhid == 0 && request.action == "A")
                {
                    objAgriList.status = "400";
                    objAgriList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new AgricultureStatusinfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;                 
                    entity.agricultureid = request.agricultureid;
                    entity.id = request.id;
                    entity.parameterid = request.parameterid;
                    entity.remark = request.remark;
                    entity.createdby = request.createdby;
                    retval = await _iHouseholdService.UpdateAgricultureStatusInfo(entity);
                    objAgriList.status = retval.ToString();
                    objAgriList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objAgriList.status = "500";
                objAgriList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objAgriList.errorMessage = ex.Message;
            }
            return objAgriList;

        }
    }
}
