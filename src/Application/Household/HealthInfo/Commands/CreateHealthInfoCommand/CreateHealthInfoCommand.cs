using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.EducationInfo.Commands;
using SRIS.Application.Household.HealthInfo.Queries.GetHealthInfo;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.HealthInfo.Commands
{
   public class CreateHealthInfoCommand:IRequest<HealthInfoList>
    {
        public int healthinfoid { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public string action { get; set; }
        public int doessufferanychronicillness { get; set; }
        public int dohavediffwearingglass { get; set; }
        public int dohavediffhearing { get; set; }

        public int dohavediffwalking { get; set; }
        public int dohavediffremembering { get; set; }
        public int dohavediffselfcare { get; set; }
        public int dohavediffcommunicate { get; set; }


        public string createdby { get; set; }
        public int apptypeid { get; set; }
        public string whatchronicillnesssuffer { get; set; }
        public string otherillness { get; set; }
    }
    public class CreateHealthInfoCommandHandler : IRequestHandler<CreateHealthInfoCommand, HealthInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateHealthInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HealthInfoList> Handle(CreateHealthInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            HealthInfoList objHealthList = new HealthInfoList();
            try
            {
                //if ((request.healthinfoid == 0 && request.action == "U") || (request.doessufferanychronicillness == 0 || request.dohavediffcommunicate == 0 || request.dohavediffhearing == 0 || request.dohavediffwalking == 0 || request.dohavediffselfcare == 0 || request.dohavediffwearingglass == 0))
                //{
                //    objHealthList.status = "400";
                //    objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                //}
                //else
                //{
                    var entity = new HealthInfoDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.memberid = request.memberid;
                    entity.healthinfoid = request.healthinfoid;
                    entity.doessufferanychronicillness = request.doessufferanychronicillness;
                    entity.dohavediffwearingglass = request.dohavediffwearingglass;
                    entity.dohavediffhearing = request.dohavediffhearing;
                    entity.dohavediffwalking = request.dohavediffwalking;
                    entity.dohavediffremembering = request.dohavediffremembering;
                    entity.dohavediffselfcare = request.dohavediffselfcare;
                    entity.dohavediffcommunicate = request.dohavediffcommunicate;
                    entity.whatchronicillnesssuffer = request.whatchronicillnesssuffer;
                    entity.otherillness = request.otherillness;
                    entity.createdby = request.createdby;
                    entity.apptypeid = request.apptypeid;
                    retval = await _iHouseholdService.AddHealthInfo(entity);
                    objHealthList.status = retval.ToString();
                    objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                //}
            }
            catch (Exception ex)
            {
                objHealthList.status = "500";
                objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objHealthList.errorMessage = ex.Message;
            }
            return objHealthList;

        }
    }
}
