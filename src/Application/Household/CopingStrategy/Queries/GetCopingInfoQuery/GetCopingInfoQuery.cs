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

namespace SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery
{
    public class GetCopingInfoQuery : IRequest<CopingInfoVM>
    {
        public int hhid { get; set; } 
        public int copingid { get; set; }
        public string actionl { get; set; }
        public string actionf { get; set; }
    }
    public class GetCopingInfoQueryHandler : IRequestHandler<GetCopingInfoQuery, CopingInfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetCopingInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<CopingInfoVM> Handle(GetCopingInfoQuery request, CancellationToken cancellationToken)
        {
            CopingInfoVM objVM = new CopingInfoVM();
            try
            {
                objVM.status = "200";
                objVM.livelyhoodLists = await _iHouseholdService.GetLivelyhoodCopingInfo(request);
                objVM.foodLists = await _iHouseholdService.GetFoodCopingInfo(request);
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
