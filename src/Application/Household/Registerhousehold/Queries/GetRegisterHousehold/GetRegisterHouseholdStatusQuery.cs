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
    public class GetRegisterHouseholdStatusQuery : IRequest<RegisterHouseholdVM>
    {

        public string householdno { get; set; }
        public string eano { get; set; }
        public string hhheadname { get; set; }
        public int hhid { get; set; }
        public int locationid { get; set; }
        public int pageno { get; set; }
        public int pagesize { get; set; }
        public string action { get; set; }
        public int allverifiedstatus { get; set; }
        public int allapprovedstatus { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
    public class GetRegisterHouseholdStatusQueryHandler : IRequestHandler<GetRegisterHouseholdStatusQuery, RegisterHouseholdVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetRegisterHouseholdStatusQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<RegisterHouseholdVM> Handle(GetRegisterHouseholdStatusQuery request, CancellationToken cancellationToken)
        {
            RegisterHouseholdVM objVM = new RegisterHouseholdVM();
            try
            {

                objVM.Lists = await _iHouseholdService.GetRegisterHouseholdStatus(request);
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
