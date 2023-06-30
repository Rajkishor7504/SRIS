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

namespace SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold
{
  public  class GetHouseholdQueryFilter : IRequest<RegisterHouseholdVM>
    {
        public string householdno { get; set; }
        public string eano { get; set; }
        public string hhheadname { get; set; }
        public int hhid { get; set; }
        public int locationid { get; set; }
        public int pageno { get; set; }
        public int pagesize { get; set; }
        public string action { get; set; }
        public int userid { get; set; }

    }
    public class GetHouseholdQueryFilterHandler : IRequestHandler<GetHouseholdQueryFilter, RegisterHouseholdVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetHouseholdQueryFilterHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<RegisterHouseholdVM> Handle(GetHouseholdQueryFilter request, CancellationToken cancellationToken)
        {
            RegisterHouseholdVM objVM = new RegisterHouseholdVM();
            try
            {
                objVM.Lists = await _iHouseholdService.GetRegisterHouseholdList(request);
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
