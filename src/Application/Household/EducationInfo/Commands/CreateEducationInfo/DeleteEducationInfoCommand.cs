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

namespace SRIS.Application.Household.EducationInfo.Commands
{
    public class DeleteEducationInfoCommand : IRequest<EducationInfoList>
    {
        public int memberid { get; set; }
        public int createdby { get; set; }
        public int educationinfoid { get; set; }
        public int apptypeid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
    }
    public class DeleteEducationInfoCommandHandler : IRequestHandler<DeleteEducationInfoCommand, EducationInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteEducationInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<EducationInfoList> Handle(DeleteEducationInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            EducationInfoList obj = new EducationInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteEducationInfo(request.educationinfoid,request.action,request.createdby,request.apptypeid);
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
