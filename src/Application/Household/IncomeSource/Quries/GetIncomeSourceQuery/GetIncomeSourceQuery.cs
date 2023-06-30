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

namespace SRIS.Application.Household.IncomeSource.Quries.GetIncomeSourceQuery
{
   public class GetIncomeSourceQuery : IRequest<IncomeSourceVM>
    {
        public string action { get; set; }
        public int copingid { get; set; }
        public int hhid { get; set; }

    }
    public class GetIncomeSourceInfoQueryHandler : IRequestHandler<GetIncomeSourceQuery, IncomeSourceVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetIncomeSourceInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<IncomeSourceVM> Handle(GetIncomeSourceQuery request, CancellationToken cancellationToken)
        {
            IncomeSourceVM objVM = new IncomeSourceVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetIncomeSource(request);
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
