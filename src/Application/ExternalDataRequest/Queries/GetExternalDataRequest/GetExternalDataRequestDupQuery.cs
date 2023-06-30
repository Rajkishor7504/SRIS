
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest
{
  public  class GetExternalDataRequestDupQuery : IRequest<ExternalDataRequestDupVM>
    {
        public string ActionCode { get; set; }
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
    }
    public class GetExternalDataRequestDupQueryHandler : IRequestHandler<GetExternalDataRequestDupQuery, ExternalDataRequestDupVM>
    {
        private readonly IExternalDataRequestServiceDup _iExternalDataRequestService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetExternalDataRequestDupQueryHandler(IApplicationDbContext context, IExternalDataRequestServiceDup iExternalDataRequestService, IMapper mapper)
        {
            _iExternalDataRequestService = iExternalDataRequestService;
            _mapper = mapper;
            _context = context;
        }
        #region "To get the external data"
        ///<summary>
        /// Created By Spandana Ray on 14/07/2021
        /// </summary>
        /// <parameter>Request Object of GetExternalDataRequestQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>ExternalDataRequestVM</returns>
        /// <remarks>To get the external data</remarks>
        public async Task<ExternalDataRequestDupVM> Handle(GetExternalDataRequestDupQuery request, CancellationToken cancellationToken)
        {
            ExternalDataRequestDupDto dataReq = new ExternalDataRequestDupDto();
            // dataReq.p_locationid = request.p_locationid;
            dataReq.ActionCode = request.ActionCode;
            dataReq.Request_UserId = request.Request_UserId;
            dataReq.datarequest_id = request.datarequest_id;
            if (request.ActionCode == "PV")
            {
                dataReq.ActionCode = "CD";
                var list = await _iExternalDataRequestService.GetExternalDataView(dataReq);
                var rc = new DataRequestCriteria()
                {
                    // p_location = list[0].p_location,
                    slga = list[0].slga,
                    sdistrict = list[0].sdistrict,
                    sward = list[0].sward,
                    stown = list[0].stown,
                    //lga = list[0].lga,
                    //district = list[0].district,
                    //ward = list[0].ward,
                    //town = list[0].town,
                    sex = list[0].sex,
                    maritalstatus = list[0].maritalstatus,
                    MinAge = list[0].MinAge,
                    MaxAge = list[0].MaxAge,
                    iscurrentlyattendingschool = list[0].iscurrentlyattendingschool,
                    haseverattendedschool = list[0].haseverattendedschool,
                    doessufferanychronicillness = list[0].doessufferanychronicillness,
                    dohavediffwalking = list[0].dohavediffwalking,
                    mainjobactivitylastthirtydays = list[0].mainjobactivitylastthirtydays,
                    workingstatus = list[0].workingstatus,
                    occupancystatusofdwelling = list[0].occupancystatusofdwelling,
                    typeoftoiletfacility = list[0].typeoftoiletfacility,
                    min_distance = list[0].min_distance,
                    max_distance = list[0].max_distance,
                    min_distance_dispensary = list[0].min_distance_dispensary,
                    max_distance_dispensary = list[0].max_distance_dispensary,
                    isTVMedium = list[0].isTVMedium,
                    isComputer = list[0].isComputer,
                    mainincomesourceofhh = list[0].mainincomesourceofhh,
                    didhhreceivemonetaryhelp = list[0].didhhreceivemonetaryhelp,
                    doescultivateland = list[0].doescultivateland,
                    ishhaffectedbyevent = list[0].ishhaffectedbyevent,
                    livelyhoodid = list[0].livelyhoodid,
                    livelyhoodcoping = list[0].livelyhoodcoping,
                    foodcoping = list[0].foodcoping,
                    programmecodeid = list[0].programmecodeid,
                    pmtcategory = list[0].pmtcategory,
                    pmtCategoryid = list[0].pmtCategoryid,
                    pmtCategorymaxvalue = list[0].pmtCategorymaxvalue,
                    pmtCategoryminvalue = list[0].pmtCategoryminvalue
                };
                var data = await _iExternalDataRequestService.GetExternalData(rc);
                dataReq.ActionCode = "PV";
                return new ExternalDataRequestDupVM
                {
                    totalHouseholdCount = data.GroupBy(g => g.hhid).Count(),
                    totalMemberCount = data.Count,
                    ExternalDataCriteriaLists = await _iExternalDataRequestService.GetExternalDataCriteriaView(dataReq)
                };
            }
            else if (request.ActionCode == "PWC") // Preview with programme code
            {
                dataReq.ActionCode = "PV";
                var data = await _iExternalDataRequestService.GenerateDataByRequest(request.datarequest_id);
                return new ExternalDataRequestDupVM
                {
                    totalHouseholdCount = data.GroupBy(g => g.hhid).Count(),
                    totalMemberCount = data.Count,
                    ExternalDataCriteriaLists = await _iExternalDataRequestService.GetExternalDataCriteriaView(dataReq)
                };
            }
            else
            {
                return new ExternalDataRequestDupVM
                {
                    Lists = await _iExternalDataRequestService.GetExternalDataView(dataReq)
                };
            }
        }
        #endregion
    }
}
