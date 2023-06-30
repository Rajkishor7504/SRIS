using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.QARejectedhhList
{
   public class HouseholdRejectedQuery : IRequest<HouseholdRejectedVM>
    {
        public string userId { get; set; }
        public string districtId { get; set; }
        public string surveyPlanId { get; set; }
    }
    public class HouseholdRejectedQueryHandler : IRequestHandler<HouseholdRejectedQuery, HouseholdRejectedVM>
    {


        private readonly IHouseholdServiceMobile _iHouseholdService;

        public HouseholdRejectedQueryHandler(IHouseholdServiceMobile iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HouseholdRejectedVM> Handle(HouseholdRejectedQuery request, CancellationToken cancellationToken)
        {
            HouseholdRejectedVM objVM = new HouseholdRejectedVM();
            try
            {

                objVM.rejectedList = await _iHouseholdService.GetVerifyRejectedHousehold(request);
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                objVM.errorMessage = "";

            }

            catch (Exception ex)
            {
                objVM.rejectedList = null;
                objVM.status = "500";
                objVM.message = ex.Message;
                objVM.errorMessage = ex.Message;
            }
            return objVM;

        }
    }
    }
