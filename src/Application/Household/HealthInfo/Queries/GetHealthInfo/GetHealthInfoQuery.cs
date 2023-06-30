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

namespace SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo
{
   public class GetHealthInfoQuery: IRequest<HealthInfoVM>
    {
        public string action { get; set; }
        public int healthinfoid { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
    }
    public class GetHealthInfoQueryHandler : IRequestHandler<GetHealthInfoQuery, HealthInfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetHealthInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<HealthInfoVM> Handle(GetHealthInfoQuery request, CancellationToken cancellationToken)
        {
            HealthInfoVM objVM = new HealthInfoVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetHealthInfo(request);
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
