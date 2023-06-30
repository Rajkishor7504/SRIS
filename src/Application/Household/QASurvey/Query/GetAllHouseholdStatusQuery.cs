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

namespace SRIS.Application.Household.QASurvey.Query
{
   public class GetAllHouseholdStatusQuery : IRequest<HouseholdStatusVM>
    {
        public int hhid { get; set; }
        public string action { get; set; }
    }
    public class GGetAllHouseholdStatusQueryHandler : IRequestHandler<GetAllHouseholdStatusQuery, HouseholdStatusVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GGetAllHouseholdStatusQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<HouseholdStatusVM> Handle(GetAllHouseholdStatusQuery request, CancellationToken cancellationToken)
        {
            HouseholdStatusVM objVM = new HouseholdStatusVM();
            try
            {

                objVM.Lists = await _iHouseholdService.GetAllHouseholdstatus(request);
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);

            }

            catch (Exception ex)
            {
                objVM.Lists = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;


        }
    }
}
