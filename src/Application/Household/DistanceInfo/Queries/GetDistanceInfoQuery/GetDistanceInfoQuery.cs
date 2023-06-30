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

namespace SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery
{
    public class GetDistanceInfoQuery : IRequest<DistanceInfoVM>
    {
        public string action { get; set; }
        public int hhid { get; set; }
    }
    public class GetDistanceInfoQueryHandler : IRequestHandler<GetDistanceInfoQuery, DistanceInfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetDistanceInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<DistanceInfoVM> Handle(GetDistanceInfoQuery request, CancellationToken cancellationToken)
        {
            DistanceInfoVM objVM = new DistanceInfoVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetDistanceInfo(request);
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
