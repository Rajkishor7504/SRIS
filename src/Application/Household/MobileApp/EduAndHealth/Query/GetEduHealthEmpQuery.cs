using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.EduAndHealth.Query
{
   public class GetEduHealthEmpQuery:IRequest<EduHealthEmpQueryVM>
    {
        public string hhid { get; set; }
    }
    public class GetEduHealthEmpQueryHandler : IRequestHandler<GetEduHealthEmpQuery, EduHealthEmpQueryVM>
    {


        private readonly IHouseholdServiceMobile _iHouseholdService;

        public GetEduHealthEmpQueryHandler(IHouseholdServiceMobile iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<EduHealthEmpQueryVM> Handle(GetEduHealthEmpQuery request, CancellationToken cancellationToken)
        {
            EduHealthEmpQueryVM objVM = new EduHealthEmpQueryVM();
            try
            {              
                objVM.education = await _iHouseholdService.GetEducationList(request); 
                objVM.employment = await _iHouseholdService.GetEmployementList(request); 
                objVM.health = await _iHouseholdService.GetHealthList(request); 
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                objVM.errorMessage = "";
            }

            catch (Exception ex)
            {
                objVM.education = null;
                objVM.employment = null;
                objVM.health = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;

        }
    }
}
