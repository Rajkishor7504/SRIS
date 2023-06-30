using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery;
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
  public  class UpdateStatusIncomeSourceCommand : IRequest<CommonMobileApiStatus>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int incomesourceid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public string remark { get; set; }
        public int id { get; set; }
        public int parameterid { get; set; }
    }
    public class UpdateStatusIncomeSoourceCommandHandler : IRequestHandler<UpdateStatusIncomeSourceCommand, CommonMobileApiStatus>
    {


        private readonly IHouseholdService _iHouseholdService;

        public UpdateStatusIncomeSoourceCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CommonMobileApiStatus> Handle(UpdateStatusIncomeSourceCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objIncomeList = new CommonMobileApiStatus();
            try
            {

                if ((request.hhid == 0 && request.action == "U"))
                {
                    objIncomeList.status = "400";
                    objIncomeList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new IncomeStatusSourceDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.incomesourceid = request.incomesourceid;
                    entity.id = request.id;                 
                    entity.parameterid = request.parameterid;
                    entity.remark = request.remark;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.UpdateIncomeSourceStatusInfo(entity);
                    objIncomeList.status = retval.ToString();
                    objIncomeList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objIncomeList.status = "500";
                objIncomeList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objIncomeList.errorMessage = ex.Message;
            }
            return objIncomeList;

        }
    }
}
