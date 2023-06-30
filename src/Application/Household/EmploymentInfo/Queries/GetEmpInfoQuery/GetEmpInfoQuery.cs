
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;

using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.EmploymentInfo.Queries.GetEmpInfoQuery
{
    public class GetEmploymentInfoQuery: IRequest<EmploymentInfoVM>
    {
        public string action { get; set; }
        public int employmentinfoid { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
    }
    public class GetEducationInfoQueryHandler : IRequestHandler<GetEmploymentInfoQuery, EmploymentInfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetEducationInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<EmploymentInfoVM> Handle(GetEmploymentInfoQuery request, CancellationToken cancellationToken)
        {
            EmploymentInfoVM objVM = new EmploymentInfoVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetEmploymentInfo(request);
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);


            }

            catch (Exception ex)
            {
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;


        }
    }
}
