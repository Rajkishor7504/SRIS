using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.CopingStrategy.Queries.GetCopingInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.CopingStrategy.Commands
{
   public class CreateCopingInfoCommand:IRequest<CopingStrategyList>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }

        public int copingid { get; set; }

        public int apptypeid { get; set; }
        public List<LivelihoodCoping> livehlihoodcoping { get; set; }
        public List<FoodCoping> foodcoping { get; set; }
    }
    public class CreateCopingInfoCommandHandler : IRequestHandler<CreateCopingInfoCommand, CopingStrategyList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateCopingInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<CopingStrategyList> Handle(CreateCopingInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CopingStrategyList objEmpList = new CopingStrategyList();
            int validationcountl = 0;
            int validationcountf = 0;
            try
            {
                if(request.livehlihoodcoping!=null)
                {
                    foreach (LivelihoodCoping lc in request.livehlihoodcoping)
                    {
                        if (lc.lresortingneedid == 0)
                        {
                            validationcountl += 1;
                        }
                    }
                }
                if (request.foodcoping != null)
                {
                    foreach (FoodCoping fc in request.foodcoping)
                    {
                        if (fc.fresortingneedid == 0)
                        {
                            validationcountf += 1;
                        }
                    }
                }
                if ((request.hhid == 0 && request.action == "U") /*|| (validationcountl > 0) || validationcountf>0*/)
                {
                    objEmpList.status = "400";
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new CopingInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.livehlihoodcoping = request.livehlihoodcoping;
                    entity.foodcoping = request.foodcoping;
                    entity.createdby = request.createdby;
                    entity.copingid = request.copingid;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddCopingInfo(entity);
                    objEmpList.status = retval.ToString();
                    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objEmpList.status = "500";
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objEmpList.errorMessage = ex.Message;
            }
            return objEmpList;

        }
    }
}
