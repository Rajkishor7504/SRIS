using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.HousingInfo.Queries.GetHousingInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.HousingInfo.Commands
{
    public class CreateHousingInfoCommand:IRequest<HousingInfoList>
    {
        public string action { get; set; }
        public int memberid { get; set; }
        public int hhid { get; set; }
        public int housinginfoid { get; set; }
        public int occupancystatusofdwelling { get; set; }
        public int mainconstructionmaterial { get; set; }
        public string otherconstructionmaterial { get; set; }
        public int mainmaterialusedforroofing { get; set; }
        public string othermaterialroofing { get; set; }
        public int mainmaterialusedforflooring { get; set; }
        public string othermaterialflooring { get; set; }
        public int mainsourceoflighting { get; set; }
        public string othersourceoflighting { get; set; }
        public int maincookingfuel { get; set; }
        public string othermaincookingfuel { get; set; }
        public int typeoftoiletfacility { get; set; }
        public string othertoiletfacility { get; set; }
        public int toiletsharedwithotherhh { get; set; }
        public int howmanyhhusetoiletfacility { get; set; }
        public int mainsourceofdrinkingwater { get; set; }
        public string othersourceofdrinkingwater { get; set; }
      
        public int howhhdisposerubbish { get; set; }
        public string otherwayforrubbish { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
       
    }
    public class CreateHousingInfoCommandHandler : IRequestHandler<CreateHousingInfoCommand, HousingInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateHousingInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<HousingInfoList> Handle(CreateHousingInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            HousingInfoList objHealthList = new HousingInfoList();
            try
            {
                var entity = new HousingInfoDto();
                entity.action = request.action;
                entity.hhid = request.hhid;
                entity.memberid = request.memberid;
                entity.housinginfoid = request.housinginfoid;
                entity.occupancystatusofdwelling = request.occupancystatusofdwelling;
                entity.mainconstructionmaterial = request.mainconstructionmaterial;
                entity.otherconstructionmaterial = request.otherconstructionmaterial;
                entity.mainmaterialusedforroofing = request.mainmaterialusedforroofing;
                entity.othermaterialroofing = request.othermaterialroofing;
                entity.mainmaterialusedforflooring = request.mainmaterialusedforflooring;
                entity.othermaterialflooring = request.othermaterialflooring;
                entity.mainsourceoflighting = request.mainsourceoflighting;
                entity.othersourceoflighting = request.othersourceoflighting;
                entity.maincookingfuel = request.maincookingfuel;
                entity.othermaincookingfuel = request.othermaincookingfuel;
                entity.typeoftoiletfacility = request.typeoftoiletfacility;
                entity.othertoiletfacility = request.othertoiletfacility;
                entity.toiletsharedwithotherhh = request.toiletsharedwithotherhh;
                entity.howmanyhhusetoiletfacility = request.howmanyhhusetoiletfacility;
                entity.mainsourceofdrinkingwater = request.mainsourceofdrinkingwater;
                entity.othersourceofdrinkingwater = request.othersourceofdrinkingwater;
                entity.howhhdisposerubbish = request.howhhdisposerubbish;
                entity.otherwayforrubbish = request.otherwayforrubbish;


                entity.createdby = request.createdby;
                entity.apptypeid = request.apptypeid;
                retval = await _iHouseholdService.AddHousingInfo(entity);
                objHealthList.status = retval.ToString();
                objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
              
            }
            catch (Exception ex)
            {
                objHealthList.status = "500";
                objHealthList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objHealthList.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return objHealthList;

        }
    }
}
