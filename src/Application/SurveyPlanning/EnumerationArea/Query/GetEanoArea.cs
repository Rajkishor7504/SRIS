using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumerationArea.Query
{
  public  class GetEanoArea : IRequest<EnumerationAreaVM>
    {
        public string action { get; set; }
        public int eaid { get; set; }
        public int planid { get; set; }
        public int searchid { get; set; }



    }
    public class GetEanoAreaQueryHandler : IRequestHandler<GetEanoArea, EnumerationAreaVM>
    {
        private readonly ISurveyPlanService _iSurveyPlanService;
        private readonly IMapper _mapper;

        public GetEanoAreaQueryHandler(ISurveyPlanService iSurveyPlanService, IMapper mapper)
        {
            _iSurveyPlanService = iSurveyPlanService;
            _mapper = mapper;
        }

        public async Task<EnumerationAreaVM> Handle(GetEanoArea request, CancellationToken cancellationToken)
        {
            EnumerationAreaVM objVM = new EnumerationAreaVM();

            try
            {               
                    objVM.status = "200";
                    objVM.list = await _iSurveyPlanService.GetEnumerationArea(request);
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
