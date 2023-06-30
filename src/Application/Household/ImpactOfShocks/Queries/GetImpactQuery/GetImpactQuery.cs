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

namespace SRIS.Application.Household.ImpactOfShocks.Queries.GetImpactQuery
{
    public class GetImpactQuery: IRequest<ImpactVM>
    {
        public int hhid { get; set; }
        public int impactid { get; set; }
        public string action { get; set; }
    }
    public class GetImpactQueryHandler : IRequestHandler<GetImpactQuery, ImpactVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetImpactQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<ImpactVM> Handle(GetImpactQuery request, CancellationToken cancellationToken)
        {
            ImpactVM objVM = new ImpactVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetImpactOfShocks(request);
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
