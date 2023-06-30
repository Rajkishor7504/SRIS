/*
* File Name : GetExternalDataRequestQuery.cs
* class Name : GetExternalDataRequestQuery, GetTodosQueryHandler
* Created Date : 13th Jul 2021
* Created By : Spandana Ray
* Description : Query to get the external data
*/

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
    public class GetExternalDataRequestQuery : IRequest<ExternalDataRequestVM>
    {
        public string ActionCode { get; set; }
        public int datarequest_id { get; set; }
        public int Request_UserId { get; set; }
    }
    public class GetExternalDataRequestQueryHandler : IRequestHandler<GetExternalDataRequestQuery, ExternalDataRequestVM>
    {
        private readonly IExternalDataRequestService _iExternalDataRequestService;
        private readonly IMapper _mapper; 
        private readonly IApplicationDbContext _context;

        public GetExternalDataRequestQueryHandler(IApplicationDbContext context, IExternalDataRequestService iExternalDataRequestService, IMapper mapper)
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
        public async Task<ExternalDataRequestVM> Handle(GetExternalDataRequestQuery request, CancellationToken cancellationToken)
        {
            ExternalDataRequestDto dataReq = new ExternalDataRequestDto();
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
                    ap_sex_pi = list[0].ap_sex,
                    ap_relationship_to_hh_pi = list[0].ap_relationship_to_hh,
                    ap_residencestatus_pi = list[0].ap_residencestatus,
                    ap_maritalstatus_pi = list[0].ap_maritalstatus,
                    ap_nationality_pi = list[0].ap_nationality,
                    ap_haseverattendedschool_pi = list[0].ap_haseverattendedschool,
                    ap_whattypeofschoolattended_pi = list[0].ap_whattypeofschoolattended,
                    ap_whichlevelandgradeattended_pi = list[0].ap_whichlevelandgradeattended,
                    ap_iscurrentlyattendingschool_pi = list[0].ap_iscurrentlyattendingschool,
                    ap_whystopschool_pi = list[0].ap_whystopschool,
                    ap_whatlastlevelandgradecompleted_pi = list[0].ap_whatlastlevelandgradecompleted,
                    ap_readandorwriteinanylanguage_pi = list[0].ap_readandorwriteinanylanguage,
                    ap_doessufferanychronicillness_pi = list[0].ap_doessufferanychronicillness,
                    ap_typeofchronicillness_pi = list[0].ap_typeofchronicillness,
                    ap_difficultyseeing_pi = list[0].ap_difficultyseeing,
                    ap_difficultyhearing_pi = list[0].ap_difficultyhearing,
                    ap_dohavediffwalking_pi = list[0].ap_dohavediffwalking,
                    ap_difficultyrememberingorconcentrating_pi = list[0].ap_difficultyrememberingorconcentrating,
                    ap_difficultywithself_caresuchaswashing_pi = list[0].ap_difficultywithself_caresuchaswashing,
                    ap_difficultycommunicating_pi = list[0].ap_difficultycommunicating,
                    ap_mainjobactivitylastthirtydays_pi = list[0].ap_mainjobactivitylastthirtydays,
                    ap_hasbeenworking_pi = list[0].ap_hasbeenworking,
                    ap_memberworkingsector_pi = list[0].ap_memberworkingsector,
                    ap_workingstatus_pi = list[0].ap_workingstatus,
                    ap_mainreasonofnotworking_pi = list[0].ap_mainreasonofnotworking,
                    ap_occupancystatusofdwelling_pi = list[0].ap_occupancystatusofdwelling,
                    ap_mainconstructionmaterialforexterior_pi = list[0].ap_mainconstructionmaterialforexterior,
                    ap_materialforroofing_pi = list[0].ap_materialforroofing,
                    ap_materialforfloor_pi = list[0].ap_materialforfloor,
                    ap_hhsourcelighting_pi = list[0].ap_hhsourcelighting,
                    ap_hhmaincookingfuel_pi = list[0].ap_hhmaincookingfuel,
                    ap_typeoftoiletfacility_pi = list[0].ap_typeoftoiletfacility,
                    ap_mainsourceofdrinkingwater_pi = list[0].ap_mainsourceofdrinkingwater,
                    ap_hhdisposeofrubbish_pi = list[0].ap_hhdisposeofrubbish,
                    //ap_distance_pi = list[0].ap_distance,
                    //ap_assets_pi = list[0].ap_assets,
                    ap_mainincomesourceofhh_pi = list[0].ap_mainincomesourceofhh,
                    ap_hhsecondsourceofincome_pi = list[0].ap_hhsecondsourceofincome,
                    ap_didhhreceivemonetaryhelp_pi = list[0].ap_didhhreceivemonetaryhelp,
                    ap_typeofaidhhreceived_pi = list[0].ap_typeofaidhhreceived,
                    ap_howfrequentlyaidreceived_pi = list[0].ap_howfrequentlyaidreceived,
                    ap_whichtypeoforganizationaidreceived_pi = list[0].ap_whichtypeoforganizationaidreceived,
                    ap_doescultivateland_pi = list[0].ap_doescultivateland,
                    ap_ifowened_bywhom_pi = list[0].ap_ifowened_bywhom,
                    ap_typeofecology_pi = list[0].ap_typeofecology,
                    ap_householdmemberresponsibleforcultivation_pi = list[0].ap_householdmemberresponsibleforcultivation,
                    ap_involveincatchingoffarmingfish_pi = list[0].ap_involveincatchingoffarmingfish,
                    ap_householdownlivestock_pi = list[0].ap_householdownlivestock,
                    ap_ishhaffectedbyevent_pi = list[0].ap_ishhaffectedbyevent,
                    ap_maintypeofshockaffectedhouseholdactivities_pi = list[0].ap_maintypeofshockaffectedhouseholdactivities,
                    ap_lossescausedbytheshock_pi = list[0].ap_lossescausedbytheshock,
                    ap_livelyhoodcoping_pi = list[0].ap_livelyhoodcoping,
                    ap_foodcoping_pi = list[0].ap_foodcoping,
                    ap_pmtcatagory_pi = list[0].ap_pmtcatagory
                };
                var data = await _iExternalDataRequestService.GetExternalData(rc);
                dataReq.ActionCode = "PV";
                return new ExternalDataRequestVM
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
                return new ExternalDataRequestVM
                {
                    totalHouseholdCount = data.GroupBy(g => g.hhid).Count(),
                    totalMemberCount = data.Count,
                    ExternalDataCriteriaLists = await _iExternalDataRequestService.GetExternalDataCriteriaView(dataReq)
                };
            }
            else if (request.ActionCode == "GFD")
            {
                return new ExternalDataRequestVM
                {
                    Lists = await _iExternalDataRequestService.GetDataSharingFeedback(dataReq)
                };
            }
            else if (request.ActionCode == "BFD")
            {
                return new ExternalDataRequestVM
                { 
                    Lists = await _iExternalDataRequestService.GetFeedbackDataView(dataReq)
                };
            }
            else if (request.ActionCode == "PN")
            {
                return new ExternalDataRequestVM
                {
                    Lists = await _iExternalDataRequestService.GetExternalDataViewLatest(dataReq)
                };
            }
            else
            {
                return new ExternalDataRequestVM
                {
                    Lists = await _iExternalDataRequestService.GetExternalDataView(dataReq)
                };
            }
        }
        #endregion
    }
}
