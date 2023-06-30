using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold
{
    public class GetRegisterHouseholdQuery : IRequest<RegisterHouseholdVM>
    {
        public string householdno { get; set; }
        public string eano { get; set; }
        public string hhheadname { get; set; }
        public int hhid { get; set; }
        public int locationid { get; set; }
        public int pageno { get; set; }
        public int pagesize { get; set; }
        public string action { get; set; }
        public int surveyId { get; set; }
      
    }
    public class GetRegisterHouseholdQueryHandler : IRequestHandler<GetRegisterHouseholdQuery, RegisterHouseholdVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetRegisterHouseholdQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<RegisterHouseholdVM> Handle(GetRegisterHouseholdQuery request, CancellationToken cancellationToken)
        {
            RegisterHouseholdVM objVM = new RegisterHouseholdVM();
            try
            {
                if (request.action == "PMT")
                    objVM.Lists = await _iHouseholdService.GetRegisterHouseholdForPMT(request);
                else if (request.action == "COM")
                    objVM.Lists = await _iHouseholdService.GetRegisterHHForComparision(request);
                else
                    objVM.Lists = await _iHouseholdService.GetRegisterHousehold(request);
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
            }
            catch(Exception ex)
            {
                objVM.Lists = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return objVM;
        }
    }
}
