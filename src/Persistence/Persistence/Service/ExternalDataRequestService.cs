using Dapper;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.ExternalDataRequest.Queries.GetExternalDataRequest;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.Service
{
    public class ExternalDataRequestService : BaseRepository, IExternalDataRequestService
    {
        private readonly IConnectionFactory _connectionFactory;
        public ExternalDataRequestService(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddExternalDataRequest(ExternalDataRequestDto datarequest)
        {
            try
            {
                datarequest.livelyhoodid = "0";
                //string teamdetailsxml = CommonHelper.SerializeToXMLString(datarequest.p_Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "A");
                //objParam.Add("p_xml", teamdetailsxml);
                objParam.Add("p_userId", datarequest.Request_UserId);
                objParam.Add("p_requestStatus", RequestStatus.Pending);
                objParam.Add("p_requestPurpose", datarequest.Request_Purpose);
                objParam.Add("p_programName", datarequest.Program_Name);
                objParam.Add("p_programCode", datarequest.Program_Code);
                objParam.Add("p_country", datarequest.Country);
                objParam.Add("p_requiredService", datarequest.Required_Service);
                objParam.Add("p_otherService", datarequest.Other_Service_Request);
                objParam.Add("p_modeofSharing", datarequest.ModeOfSharing);
                objParam.Add("p_totalRegistered", datarequest.Total_HH_Registered);
                objParam.Add("p_createdBy", datarequest.createdby);
                objParam.Add("p_createdBy", datarequest.updatedby);
                objParam.Add("p_requestid_linked", datarequest.datarequest_id_linked);
                objParam.Add("p_createdBy", datarequest.Request_UserId);
                //objParam.Add("p_lga", datarequest.RequestCriteria.slga);
                //objParam.Add("p_district", datarequest.RequestCriteria.sdistrict);
                //objParam.Add("p_ward", datarequest.RequestCriteria.sward);
                //objParam.Add("p_town", datarequest.RequestCriteria.stown);
                objParam.Add("p_lga", datarequest.RequestCriteria.lga);
                objParam.Add("p_district", datarequest.RequestCriteria.district);
                objParam.Add("p_ward", datarequest.RequestCriteria.ward);
                objParam.Add("p_town", datarequest.RequestCriteria.town);
                objParam.Add("p_sex", datarequest.RequestCriteria.sex);
                objParam.Add("p_maritalstatus", datarequest.RequestCriteria.maritalstatus);
                objParam.Add("p_MinAge", datarequest.RequestCriteria.MinAge);
                objParam.Add("p_MaxAge", datarequest.RequestCriteria.MaxAge);
                objParam.Add("p_iscurrentlyattendingschool", datarequest.RequestCriteria.iscurrentlyattendingschool);
                objParam.Add("p_haseverattendedschool", datarequest.RequestCriteria.haseverattendedschool);
                objParam.Add("p_doessufferanychronicillness", datarequest.RequestCriteria.doessufferanychronicillness);
                objParam.Add("p_dohavediffwalking", datarequest.RequestCriteria.dohavediffwalking);
                objParam.Add("p_mainjobactivitylastthirtydays", datarequest.RequestCriteria.mainjobactivitylastthirtydays);
                objParam.Add("p_workingstatus", datarequest.RequestCriteria.workingstatus);
                objParam.Add("p_occupancystatusofdwelling", datarequest.RequestCriteria.occupancystatusofdwelling);
                objParam.Add("p_typeoftoiletfacility", datarequest.RequestCriteria.typeoftoiletfacility);
                objParam.Add("p_distance_serviceid", datarequest.RequestCriteria.distance_serviceid);
                objParam.Add("p_min_distance", datarequest.RequestCriteria.min_distance);
                objParam.Add("p_max_distance", datarequest.RequestCriteria.max_distance);
                objParam.Add("p_min_distance_dispensary", datarequest.RequestCriteria.min_distance_dispensary);
                objParam.Add("p_max_distance_dispensary", datarequest.RequestCriteria.max_distance_dispensary);
                objParam.Add("p_isTVMedium", datarequest.RequestCriteria.isTVMedium);
                objParam.Add("p_isComputer", datarequest.RequestCriteria.isComputer);
                objParam.Add("p_mainincomesourceofhh", datarequest.RequestCriteria.mainincomesourceofhh);
                objParam.Add("p_didhhreceivemonetaryhelp", datarequest.RequestCriteria.didhhreceivemonetaryhelp);
                objParam.Add("p_doescultivateland", datarequest.RequestCriteria.doescultivateland);
                objParam.Add("p_ishhaffectedbyevent", datarequest.RequestCriteria.ishhaffectedbyevent);
                objParam.Add("p_livelyhoodid", string.IsNullOrEmpty(datarequest.RequestCriteria.livelyhoodid) ? "" : datarequest.RequestCriteria.livelyhoodid.TrimStart(','));
                objParam.Add("p_livelyhoodcoping", datarequest.RequestCriteria.livelyhoodcoping);
                objParam.Add("p_foodcoping", datarequest.RequestCriteria.foodcoping);
                objParam.Add("p_pmtCategoryid", datarequest.RequestCriteria.pmtCategoryid);
                objParam.Add("p_min_pmtscore", datarequest.RequestCriteria.pmtCategoryminvalue);
                objParam.Add("p_max_pmtscore", datarequest.RequestCriteria.pmtCategorymaxvalue);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync("usp_ExternalUserDataRequest" /*"usp_multipledatasharing"*/, objParam, null, null, CommandType.StoredProcedure);
                    return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
        }
        public async Task<int> DataRequestNotification(ExternalDataRequestDto datarequest)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "N");
            objParam.Add("p_userId", datarequest.Request_UserId);
            objParam.Add("p_requestStatus", RequestStatus.Pending);
            objParam.Add("p_requestPurpose", datarequest.Request_Purpose);
            objParam.Add("p_programName", datarequest.Program_Name);
            objParam.Add("p_programCode", datarequest.Program_Code);
            objParam.Add("p_country", datarequest.Country);
            objParam.Add("p_requiredService", datarequest.Required_Service);
            objParam.Add("p_otherService", datarequest.Other_Service_Request);
            objParam.Add("p_modeofSharing", datarequest.ModeOfSharing);
            objParam.Add("p_totalRegistered", datarequest.Total_HH_Registered);
            objParam.Add("p_createdBy", datarequest.createdby);
            objParam.Add("p_lga", datarequest.RequestCriteria.lga);
            objParam.Add("p_district", datarequest.RequestCriteria.district);
            objParam.Add("p_ward", datarequest.RequestCriteria.ward);
            objParam.Add("p_town", datarequest.RequestCriteria.town);
            objParam.Add("p_sex", datarequest.RequestCriteria.sex);
            objParam.Add("p_maritalstatus", datarequest.RequestCriteria.maritalstatus);
            objParam.Add("p_MinAge", datarequest.RequestCriteria.MinAge);
            objParam.Add("p_MaxAge", datarequest.RequestCriteria.MaxAge);
            objParam.Add("p_iscurrentlyattendingschool", datarequest.RequestCriteria.iscurrentlyattendingschool);
            objParam.Add("p_haseverattendedschool", datarequest.RequestCriteria.haseverattendedschool);
            objParam.Add("p_doessufferanychronicillness", datarequest.RequestCriteria.doessufferanychronicillness);
            objParam.Add("p_dohavediffwalking", datarequest.RequestCriteria.dohavediffwalking);
            objParam.Add("p_mainjobactivitylastthirtydays", datarequest.RequestCriteria.mainjobactivitylastthirtydays);
            objParam.Add("p_workingstatus", datarequest.RequestCriteria.workingstatus);
            objParam.Add("p_occupancystatusofdwelling", datarequest.RequestCriteria.occupancystatusofdwelling);
            objParam.Add("p_typeoftoiletfacility", datarequest.RequestCriteria.typeoftoiletfacility);
            objParam.Add("p_distance_serviceid", datarequest.RequestCriteria.distance_serviceid);
            objParam.Add("p_min_distance", datarequest.RequestCriteria.min_distance);
            objParam.Add("p_max_distance", datarequest.RequestCriteria.max_distance);
            objParam.Add("p_min_distance_dispensary", datarequest.RequestCriteria.min_distance_dispensary);
            objParam.Add("p_max_distance_dispensary", datarequest.RequestCriteria.max_distance_dispensary);
            objParam.Add("p_isTVMedium", datarequest.RequestCriteria.isTVMedium);
            objParam.Add("p_isComputer", datarequest.RequestCriteria.isComputer);
            objParam.Add("p_mainincomesourceofhh", datarequest.RequestCriteria.mainincomesourceofhh);
            objParam.Add("p_didhhreceivemonetaryhelp", datarequest.RequestCriteria.didhhreceivemonetaryhelp);
            objParam.Add("p_doescultivateland", datarequest.RequestCriteria.doescultivateland);
            objParam.Add("p_ishhaffectedbyevent", datarequest.RequestCriteria.ishhaffectedbyevent);
            objParam.Add("p_livelyhoodid", string.IsNullOrEmpty(datarequest.RequestCriteria.livelyhoodid) ? "" : datarequest.RequestCriteria.livelyhoodid.TrimStart(','));
            objParam.Add("p_livelyhoodcoping", datarequest.RequestCriteria.livelyhoodcoping);
            objParam.Add("p_foodcoping", datarequest.RequestCriteria.foodcoping);
            objParam.Add("p_pmtCategoryid", datarequest.RequestCriteria.pmtCategoryid);
            objParam.Add("p_min_pmtscore", datarequest.RequestCriteria.pmtCategoryminvalue);
            objParam.Add("p_max_pmtscore", datarequest.RequestCriteria.pmtCategorymaxvalue);
            objParam.Add("p_requestid_linked", datarequest.datarequest_id_linked);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            //var result = Connection.ExecuteAsync("usp_ExternalUserDataRequest", objParam, null, null, CommandType.StoredProcedure);
            //return await result;

            await Connection.ExecuteAsync("usp_ExternalUserDataRequest", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }

        public async Task<int> ExternalDataRequestApproveReject(ExternalDataRequestDto datarequest)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_status", datarequest.Request_Status);
            objParam.Add("p_requestId", datarequest.datarequest_id);
            objParam.Add("p_remarks", datarequest.remarks);
            objParam.Add("p_otherdatafile", datarequest.otherdatafile);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            //var result = Connection.ExecuteAsync("usp_ExternalData_AR", objParam, null, null, CommandType.StoredProcedure);
            //return await result;
            await Connection.ExecuteAsync("usp_ExternalData_AR", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }

        public async Task<List<ExternalData>> GenerateDataByRequest(int requestId)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "GD");
                objParam.Add("p_userId", 0);
                objParam.Add("p_requestId", requestId);
                var result = await Connection.QueryAsync<ExternalData>("usp_ExternalData_View", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public async Task<List<ExternalData>> GenerateDataByDownloadExcel(int requestId)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "FFD");
                objParam.Add("p_userId", 0);
                objParam.Add("p_requestId", requestId);
                var result = await Connection.QueryAsync<ExternalData>("usp_ExternalData_View", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public async Task<List<ExternalDataRequestDto>> GetExternalData(DataRequestCriteria datarequest)
        {
            try
            {
                if (datarequest.livelyhoodid == "")
                {
                    datarequest.livelyhoodid = "0";
                }
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "A");
                objParam.Add("p_lga", datarequest.slga);
                objParam.Add("p_district", datarequest.sdistrict);
                objParam.Add("p_ward", datarequest.sward);
                objParam.Add("p_town", datarequest.stown);
                objParam.Add("p_sex", datarequest.ap_sex_pi);
                objParam.Add("p_relationshiptohh", datarequest.ap_relationship_to_hh_pi);
                objParam.Add("p_maritalstatus", datarequest.ap_maritalstatus_pi);
                objParam.Add("p_residence", datarequest.ap_residencestatus_pi);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_nationality", datarequest.ap_nationality_pi);//Add Rajkishor Patra(19-oct-2022)

                objParam.Add("p_haseverattendedschool", datarequest.ap_haseverattendedschool_pi);
                objParam.Add("p_typeofschool", datarequest.ap_whattypeofschoolattended_pi);
                objParam.Add("p_levelandgradeatn", datarequest.ap_whichlevelandgradeattended_pi);
                objParam.Add("p_iscurrentlyattendingschool", datarequest.ap_iscurrentlyattendingschool_pi);
                objParam.Add("p_hasstoppedgoingtoschool", datarequest.ap_whystopschool_pi);
                objParam.Add("p_wasthelastlevelandgradethatnamecompleted", datarequest.ap_whatlastlevelandgradecompleted_pi);
                objParam.Add("p_read_writelanguage", datarequest.ap_readandorwriteinanylanguage_pi); //Add Rajkishor Patra(19-oct-2022)

                objParam.Add("p_doessufferanychronicillness", datarequest.ap_doessufferanychronicillness_pi);
                objParam.Add("p_typeofchronicillness", datarequest.ap_typeofchronicillness_pi);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultyseeing", datarequest.ap_difficultyseeing_pi);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultyhearing", datarequest.ap_difficultyhearing_pi);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_dohavediffwalking", datarequest.ap_dohavediffwalking_pi);
                objParam.Add("p_difficultyrememberingorconcentrating", datarequest.ap_difficultyrememberingorconcentrating_pi);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultywithself_caresuchaswashing", datarequest.ap_difficultywithself_caresuchaswashing_pi);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultycommunicating", datarequest.ap_difficultycommunicating_pi);//Add Rajkishor Patra(19-oct-2022)


                objParam.Add("p_mainjobactivitylastthirtydays", datarequest.ap_mainjobactivitylastthirtydays_pi);
                objParam.Add("p_howfrequently", datarequest.ap_hasbeenworking_pi);
                objParam.Add("p_workingsector", datarequest.ap_memberworkingsector_pi);
                objParam.Add("p_workingstatus", datarequest.ap_workingstatus_pi);
                objParam.Add("p_reasonfornotworking", datarequest.ap_mainreasonofnotworking_pi);


                objParam.Add("p_occupancystatusofdwelling", datarequest.ap_occupancystatusofdwelling_pi);
                objParam.Add("p_constructionmaterial", datarequest.ap_mainconstructionmaterialforexterior_pi);
                objParam.Add("p_materialusedforroofing", datarequest.ap_materialforroofing_pi);
                objParam.Add("p_materialusedforflooring", datarequest.ap_materialforfloor_pi);
                objParam.Add("p_sourceoflighting", datarequest.ap_hhsourcelighting_pi);
                objParam.Add("p_cookingfuel", datarequest.ap_hhmaincookingfuel_pi);
                objParam.Add("p_typeoftoiletfacility", datarequest.ap_typeoftoiletfacility_pi);
                objParam.Add("p_sourceofdrinkingwater", datarequest.ap_mainsourceofdrinkingwater_pi);
                objParam.Add("p_disposerubbish", datarequest.ap_hhdisposeofrubbish_pi);
                //objParam.Add("p_distance_serviceid", datarequest.distance_serviceid);

                objParam.Add("p_mainincomesourceofhh", datarequest.ap_mainincomesourceofhh_pi);
                objParam.Add("p_secondmainsourceofincome", datarequest.ap_hhsecondsourceofincome_pi);
                objParam.Add("p_didhhreceivemonetaryhelp", datarequest.ap_didhhreceivemonetaryhelp_pi);
                objParam.Add("p_typeofaid", datarequest.ap_typeofaidhhreceived_pi);
                objParam.Add("p_howfrequentlyincome", datarequest.ap_howfrequentlyaidreceived_pi);
                objParam.Add("p_typeoforganisation", datarequest.ap_whichtypeoforganizationaidreceived_pi);

                objParam.Add("p_doescultivateland", datarequest.ap_doescultivateland_pi);
                objParam.Add("p_ownedbywhom", datarequest.ap_ifowened_bywhom_pi);
                objParam.Add("p_typeofecology", datarequest.ap_typeofecology_pi);
                objParam.Add("p_responsibleforcultivation", datarequest.ap_householdmemberresponsibleforcultivation_pi);
                objParam.Add("p_catchingoffarmingfish", datarequest.ap_involveincatchingoffarmingfish_pi);
                objParam.Add("p_ownlivestock", datarequest.ap_householdownlivestock_pi);
                objParam.Add("p_ishhaffectedbyevent", datarequest.ap_ishhaffectedbyevent_pi);
                objParam.Add("p_typeofsock", datarequest.ap_maintypeofshockaffectedhouseholdactivities_pi);
                objParam.Add("p_lossesbysock", datarequest.ap_lossescausedbytheshock_pi);
                objParam.Add("p_livelyhoodcoping", datarequest.ap_livelyhoodcoping_pi);
                objParam.Add("p_foodcoping", datarequest.ap_foodcoping_pi);
                objParam.Add("p_pmtcatagory", datarequest.ap_pmtcatagory_pi);
                var result = await Connection.QueryAsync<ExternalDataRequestDto>(datarequest.programmecodeid == 0 ? "usp_datarequest_fetch_multiple" /*"usp_datarequest_fetch"*/ : "usp_datarequest_fetch_withPC", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }
        public async Task<List<ExternalDataRequestDto>> GetExternalDataView(ExternalDataRequestDto request)
        {
            if(request.datarequest_id == 0 && request.ActionCode == "V")
            {
                try
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", request.ActionCode);
                    objParam.Add("p_userId", request.Request_UserId);
                    objParam.Add("p_requestId", request.datarequest_id);
                    //objParam.Add("p_locationid", request.p_locationid);
                    var result = await Connection.QueryAsync<ExternalDataRequestDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_View_dup", objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            else if(request.datarequest_id != 0 && request.ActionCode == "V")
            {
                try
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", "VD");
                    objParam.Add("p_userId", request.Request_UserId);
                    objParam.Add("p_requestId", request.datarequest_id);
                    //objParam.Add("p_locationid", request.p_locationid);
                    var result = await Connection.QueryAsync<ExternalDataRequestDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_View_dup", objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            else
            {
                try
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", request.ActionCode);
                    objParam.Add("p_userId", request.Request_UserId);
                    objParam.Add("p_requestId", request.datarequest_id);
                    //objParam.Add("p_locationid", request.p_locationid);
                    var result = await Connection.QueryAsync<ExternalDataRequestDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_View_dup", objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
           
           

        }
        public async Task<List<ExternalDataRequestDto>> GetExternalDataViewLatest(ExternalDataRequestDto request)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                //objParam.Add("p_action", request.ActionCode);
                //objParam.Add("p_userId", request.Request_UserId);
                objParam.Add("p_requestId", request.datarequest_id);
                //objParam.Add("p_locationid", request.p_locationid);
                var result = await Connection.QueryAsync<ExternalDataRequestDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_view_Dup_Latest", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
            public async Task<List<ExternalDataRequestDto>> GetFeedbackDataView(ExternalDataRequestDto request)
            {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_requestId", request.datarequest_id);
                var result = await Connection.QueryAsync<ExternalDataRequestDto>("usp_GetFeedbackDataView", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }
        public async Task<List<ExternalDataCriteriaDisplay>> GetExternalDataCriteriaView(ExternalDataRequestDto request)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", request.ActionCode);
                objParam.Add("p_userId", request.Request_UserId);
                objParam.Add("p_requestId", request.datarequest_id);
                var result = await Connection.QueryAsync<ExternalDataCriteriaDisplay>("usp_ExternalData_View", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<int> UpdateDataSharingFeedback(ExternalDataRequestDto datarequest)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_requestId", datarequest.datarequest_id);
            objParam.Add("p_requeststatus", datarequest.Request_Status);
            objParam.Add("p_remarks", datarequest.Feedback);
            objParam.Add("p_userid", datarequest.Request_UserId);
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_datasharing_feedback", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }
       

        public async Task<List<ExternalDataRequestDto>> GetDataSharingFeedback(ExternalDataRequestDto feedbackrequest)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_feedbackstatus", feedbackrequest.FeedbackStatus);
            var result = await Connection.QueryAsync<ExternalDataRequestDto>("usp_getdatasharing_feedback", objParam, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
