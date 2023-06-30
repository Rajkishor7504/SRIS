using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;

namespace SRIS.Application.Household.Registerhousehold.Commands
{
    public class CreateRegisterHouseholdCommand : IRequest<RegisterHouseholdList>
    {

        public string action { get; set; }
        public int hhid { get; set; }
        public int lgaid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public string dateofinterview { get; set; }
        public string interviewer { get; set; }
        public string supervisor { get; set; }
        public int areaid { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string hhno { get; set; }
        public string eano { get; set; }
        public string compoundno { get; set; }
        public int isaggreed { get; set; }
        public string respondantname { get; set; }
        public string telephoneno { get; set; }
        public string address { get; set; }
        public string householdheadname { get; set; }
        public string resultofhhinterview { get; set; }
        public string observation { get; set; }
        public string createdby { get; set; }
        public string hhcode { get; set; }
        public int surveyplanid { get; set; }
        public int clusterno { get; set; }
    }
    public class CreateRegisterHouseholdCommandHandler : IRequestHandler<CreateRegisterHouseholdCommand, RegisterHouseholdList>
    {
        private readonly IApplicationDbContext _context;


        private readonly IHouseholdService _iHouseholdService; private readonly IGrievanceService _igrievanceService;

        public CreateRegisterHouseholdCommandHandler(IHouseholdService iHouseholdService, IGrievanceService igrievanceService)
        {
            _iHouseholdService = iHouseholdService;
            _igrievanceService = igrievanceService;
        }

        public async Task<RegisterHouseholdList> Handle(CreateRegisterHouseholdCommand request, CancellationToken cancellationToken)
        {
            var entity1 = new NotificationMasterDto();
            RegisterHouseholdList obj = new RegisterHouseholdList();
            int retval = 0;
            try
            {
                if ((request.hhid == 0 && request.action=="U") || request.districtid == 0 || request.wardid == 0 || request.settlementid == 0 || string.IsNullOrEmpty(request.dateofinterview) || string.IsNullOrEmpty(request.interviewer) || string.IsNullOrEmpty(request.supervisor))
                {
                    obj.status = "400";
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                }
                else
                {
                    var entity = new RegisterHouseholdDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.clusterno = request.clusterno;
                    entity.lgaid = request.lgaid;
                    entity.districtid = request.districtid;
                    entity.wardid = request.wardid;
                    entity.settlementid = request.settlementid;
                    entity.dateofinterview = request.dateofinterview;
                    entity.interviewer = request.interviewer;
                    entity.supervisor = request.supervisor;
                    entity.areaid = request.areaid;
                    entity.latitude = request.latitude;
                    entity.longitude = request.longitude;
                    entity.hhno = request.hhno;
                    entity.eano = request.eano;
                    entity.compoundno = request.compoundno;
                    entity.isaggreed = request.isaggreed;
                    entity.respondantname = request.respondantname;
                    entity.telephoneno = request.telephoneno;
                    entity.address = request.address;
                    entity.householdheadname = request.householdheadname;
                    entity.resultofhhinterview = request.resultofhhinterview;
                    entity.observation = request.observation;
                    entity.hhcode= request.hhcode;
                    entity.createdby = request.createdby;
                    entity.surveyplanid = request.surveyplanid;                 
                    retval = await _iHouseholdService.AddRegisterHousehold(entity);
                    obj.status = retval.ToString();
                    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                    //if (retval == 200)
                    //{
                    //    var Hhcode = request.hhcode;
                    //    entity1.CreatedBy = Convert.ToInt32(request.createdby);
                    //    entity1.Information = "The Household Number : " + Hhcode + " , Pending for verify";
                    //    entity1.DestinationURL = "/Household/QASurvey/SurveyDetails";
                    //    await _igrievanceService.AddQAOfficerNotification(entity1);
                    //}
                }
            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                throw new Exception(ex.Message);
            }
            return obj;

        }
    }
}
