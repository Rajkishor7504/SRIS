using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery;
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
    public class CreateEmploymentInfoCommand:IRequest<EmploymentInfoList>
    {
        public string action { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int employmentinfoid { get; set; }
        public int mainjobactivitylastthirtydays { get; set; }
        public int howfreequentlyworking { get; set; }
        public int workinginwhichsector { get; set; }
        public string othersector { get; set; }
        public int workingstatus { get; set; }
        public int reasonfornotworking { get; set; }
        public string othereasonfornotworking { get; set; }
        public int createdby { get; set; }

        public int apptypeid { get; set; }
    }
    public class CreateEmpInfoCommandHandler : IRequestHandler<CreateEmploymentInfoCommand, EmploymentInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateEmpInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<EmploymentInfoList> Handle(CreateEmploymentInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            EmploymentInfoList objEmpList = new EmploymentInfoList();
            try
            {
                if ((request.employmentinfoid == 0 && request.action == "U") /*|| (request.reasonfornotworking == 0 || request.howfreequentlyworking == 0 || request.workinginwhichsector == 0 || request.workingstatus == 0)*/)
                {
                    objEmpList.status = "400";
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new EmploymentInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.memberid = request.memberid;
                    entity.employmentinfoid = request.employmentinfoid;
                    entity.mainjobactivitylastthirtydays = request.mainjobactivitylastthirtydays;
                    entity.howfreequentlyworking = request.howfreequentlyworking;
                    entity.workinginwhichsector = request.workinginwhichsector;
                    entity.othersector = request.othersector;
                    entity.workingstatus = request.workingstatus;
                    entity.reasonfornotworking = request.reasonfornotworking;
                    entity.othereasonfornotworking = request.othereasonfornotworking;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddEmploymentInfo(entity);
                    objEmpList.status = retval.ToString();
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objEmpList.status = "500";
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objEmpList.errorMessage = ex.Message;
            }
            return objEmpList;

        }
    }
}
