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

namespace SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery
{
    public class GetHousingInfoQuery: IRequest<HousingInfoVM>
    {
        public string action { get; set; }
        public int housinginfoid { get; set;}
        public int hhid { get; set; }

    }
    public class GetHousingInfoQueryHandler : IRequestHandler<GetHousingInfoQuery, HousingInfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetHousingInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<HousingInfoVM> Handle(GetHousingInfoQuery request, CancellationToken cancellationToken)
        {
            HousingInfoVM objVM = new HousingInfoVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetHousingInfo(request);
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);


            }

            catch (Exception ex)
            {
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return objVM;


        }
    }
}
