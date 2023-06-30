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

namespace SRIS.Application.Household.DemographicMember.Queries.GetDemographicMember
{
    public class GetDemographicMemberQuery:IRequest<DemographicMemberVM>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }

    }
    public class GetDemographicMemberQueryHandler : IRequestHandler<GetDemographicMemberQuery, DemographicMemberVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetDemographicMemberQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<DemographicMemberVM> Handle(GetDemographicMemberQuery request, CancellationToken cancellationToken)
        {
            DemographicMemberVM objVM = new DemographicMemberVM();
            if(request.action=="BL")
            {
                try
                {
                    objVM.status = "200";
                    objVM.Lists = await _iHouseholdService.GetHouseholdPopup(request);
                    objVM.message = objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);


                }

                catch (Exception ex)
                {
                    objVM.status = "500";
                    objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                    objVM.errorMessage = ex.Message;
                    throw new Exception(ex.Message);

                }
            }
            else
            {
                try
                {
                    objVM.status = "200";
                    objVM.Lists = await _iHouseholdService.GetDemographicMember(request);
                    objVM.message = objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);


                }

                catch (Exception ex)
                {
                    objVM.status = "500";
                    objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                    objVM.errorMessage = ex.Message;
                    throw new Exception(ex.Message);

                }
            }
            
            return objVM;


        }
    }
}
