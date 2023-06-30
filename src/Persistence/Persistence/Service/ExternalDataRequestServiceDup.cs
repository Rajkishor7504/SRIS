using Dapper;
using SRIS.Application.Common.Interfaces;
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
    public class ExternalDataRequestServiceDup : BaseRepository, IExternalDataRequestServiceDup
    {
        private readonly IConnectionFactory _connectionFactory;

        public ExternalDataRequestServiceDup(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        string teamdetailsxml = "";
        public async Task<int> AddExternalDataRequestLatest(ExternalDataRequestDupDto datarequest)
        {
            try
            {
                datarequest.livelyhoodid = "0";
                teamdetailsxml = CommonHelper.SerializeToXMLString(datarequest.p_Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "A");
                objParam.Add("p_xml", teamdetailsxml);
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
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync(/*"usp_ExternalUserDataRequest"*/ "usp_multipledatasharingLatest", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public async Task<int> AddExternalDataRequest(ExternalDataRequestDupDto datarequest)
        {
            try
            {
                datarequest.livelyhoodid = "0";
                teamdetailsxml = CommonHelper.SerializeToXMLString(datarequest.p_Lists);
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "A");
                objParam.Add("p_xml", teamdetailsxml);
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
                //objParam.Add("p_createdBy", datarequest.Request_UserId);
                //objParam.Add("p_lga", datarequest.RequestCriteria.slga);
                //objParam.Add("p_lga", datarequest.RequestCriteria.slga);
                //objParam.Add("p_district", datarequest.RequestCriteria.sdistrict);
                //objParam.Add("p_ward", datarequest.RequestCriteria.sward);
                //objParam.Add("p_town", datarequest.RequestCriteria.stown);
                ////objParam.Add("p_lga", datarequest.RequestCriteria.lga);
                ////objParam.Add("p_district", datarequest.RequestCriteria.district);
                ////objParam.Add("p_ward", datarequest.RequestCriteria.ward);
                ////objParam.Add("p_town", datarequest.RequestCriteria.town);
                //objParam.Add("p_sex", datarequest.RequestCriteria.sex);
                //objParam.Add("p_maritalstatus", datarequest.RequestCriteria.maritalstatus);
                //objParam.Add("p_MinAge", datarequest.RequestCriteria.MinAge);
                //objParam.Add("p_MaxAge", datarequest.RequestCriteria.MaxAge);
                //objParam.Add("p_iscurrentlyattendingschool", datarequest.RequestCriteria.iscurrentlyattendingschool);
                //objParam.Add("p_haseverattendedschool", datarequest.RequestCriteria.haseverattendedschool);
                //objParam.Add("p_doessufferanychronicillness", datarequest.RequestCriteria.doessufferanychronicillness);
                //objParam.Add("p_dohavediffwalking", datarequest.RequestCriteria.dohavediffwalking);
                //objParam.Add("p_mainjobactivitylastthirtydays", datarequest.RequestCriteria.mainjobactivitylastthirtydays);
                //objParam.Add("p_workingstatus", datarequest.RequestCriteria.workingstatus);
                //objParam.Add("p_occupancystatusofdwelling", datarequest.RequestCriteria.occupancystatusofdwelling);
                //objParam.Add("p_typeoftoiletfacility", datarequest.RequestCriteria.typeoftoiletfacility);
                //objParam.Add("p_distance_serviceid", datarequest.RequestCriteria.distance_serviceid);
                //objParam.Add("p_min_distance", datarequest.RequestCriteria.min_distance);
                //objParam.Add("p_max_distance", datarequest.RequestCriteria.max_distance);
                //objParam.Add("p_min_distance_dispensary", datarequest.RequestCriteria.min_distance_dispensary);
                //objParam.Add("p_max_distance_dispensary", datarequest.RequestCriteria.max_distance_dispensary);
                //objParam.Add("p_isTVMedium", datarequest.RequestCriteria.isTVMedium);
                //objParam.Add("p_isComputer", datarequest.RequestCriteria.isComputer);
                //objParam.Add("p_mainincomesourceofhh", datarequest.RequestCriteria.mainincomesourceofhh);
                //objParam.Add("p_didhhreceivemonetaryhelp", datarequest.RequestCriteria.didhhreceivemonetaryhelp);
                //objParam.Add("p_doescultivateland", datarequest.RequestCriteria.doescultivateland);
                //objParam.Add("p_ishhaffectedbyevent", datarequest.RequestCriteria.ishhaffectedbyevent);
                //objParam.Add("p_livelyhoodid", string.IsNullOrEmpty(datarequest.RequestCriteria.livelyhoodid) ? "" : datarequest.RequestCriteria.livelyhoodid.TrimStart(','));
                //objParam.Add("p_livelyhoodcoping", datarequest.RequestCriteria.livelyhoodcoping);
                //objParam.Add("p_foodcoping", datarequest.RequestCriteria.foodcoping);
                //objParam.Add("p_pmtCategoryid", datarequest.RequestCriteria.pmtCategoryid);
                //objParam.Add("p_min_pmtscore", datarequest.RequestCriteria.pmtCategoryminvalue);
                //objParam.Add("p_max_pmtscore", datarequest.RequestCriteria.pmtCategorymaxvalue);
                objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
                await Connection.ExecuteAsync(/*"usp_ExternalUserDataRequest"*/ "usp_multipledatasharing", objParam, null, null, CommandType.StoredProcedure);
                return objParam.Get<int>("p_out");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public async Task<int> ExternalDataRequestApproveReject(ExternalDataRequestDupDto datarequest)
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
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "GD");
            objParam.Add("p_userId", 0);
            objParam.Add("p_requestId", requestId);
            var result = await Connection.QueryAsync<ExternalData>("usp_ExternalData_View", objParam, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<ExternalDataRequestDupDto>> GetExternalData(DataRequestCriteria datarequest)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "A");
                objParam.Add("p_lga", datarequest.slga);
                objParam.Add("p_district", datarequest.sdistrict);
                objParam.Add("p_ward", datarequest.sward);
                objParam.Add("p_town", datarequest.stown);
                //objParam.Add("p_lga", datarequest.lga);
                //objParam.Add("p_district", datarequest.district);
                //objParam.Add("p_ward", datarequest.ward);
                //objParam.Add("p_town", datarequest.town);
                //objParam.Add("p_location", datarequest.p_location);
                objParam.Add("p_sex", datarequest.sex);
                objParam.Add("p_maritalstatus", datarequest.maritalstatus);
                objParam.Add("p_MinAge", datarequest.MinAge);
                objParam.Add("p_MaxAge", datarequest.MaxAge);
                objParam.Add("p_iscurrentlyattendingschool", datarequest.iscurrentlyattendingschool);
                objParam.Add("p_haseverattendedschool", datarequest.haseverattendedschool);
                objParam.Add("p_doessufferanychronicillness", datarequest.doessufferanychronicillness);
                objParam.Add("p_dohavediffwalking", datarequest.dohavediffwalking);
                objParam.Add("p_mainjobactivitylastthirtydays", datarequest.mainjobactivitylastthirtydays);
                objParam.Add("p_workingstatus", datarequest.workingstatus);
                objParam.Add("p_occupancystatusofdwelling", datarequest.occupancystatusofdwelling);
                objParam.Add("p_typeoftoiletfacility", datarequest.typeoftoiletfacility);
                objParam.Add("p_distance_serviceid", datarequest.distance_serviceid);
                objParam.Add("p_min_distance", datarequest.min_distance);
                objParam.Add("p_max_distance", datarequest.max_distance);
                objParam.Add("p_min_distance_dispensary", datarequest.min_distance_dispensary);
                objParam.Add("p_max_distance_dispensary", datarequest.max_distance_dispensary);
                objParam.Add("p_isTVMedium", datarequest.isTVMedium);
                objParam.Add("p_isComputer", datarequest.isComputer);
                objParam.Add("p_mainincomesourceofhh", datarequest.mainincomesourceofhh);
                objParam.Add("p_didhhreceivemonetaryhelp", datarequest.didhhreceivemonetaryhelp);
                objParam.Add("p_doescultivateland", datarequest.doescultivateland);
                objParam.Add("p_ishhaffectedbyevent", datarequest.ishhaffectedbyevent);
                objParam.Add("p_livelyhoodid", datarequest.livelyhoodid.TrimStart(','));
                objParam.Add("p_livelyhoodcoping", datarequest.livelyhoodcoping);
                objParam.Add("p_foodcoping", datarequest.foodcoping);
                objParam.Add("p_programmecode_reqId", datarequest.programmecodeid);
                objParam.Add("p_pmtCategoryid", datarequest.pmtCategoryid);
                objParam.Add("p_min_pmtscore", datarequest.pmtCategoryminvalue);
                objParam.Add("p_max_pmtscore", datarequest.pmtCategorymaxvalue);

                var result = await Connection.QueryAsync<ExternalDataRequestDupDto>(datarequest.programmecodeid == 0 ? "usp_datarequest_fetch_multiple" /*"usp_datarequest_fetch"*/ : "usp_datarequest_fetch_withPC", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }
        public async Task<List<ExternalDataRequestDupDto>> GetExternalDataView(ExternalDataRequestDupDto request)
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
                    var result = await Connection.QueryAsync<ExternalDataRequestDupDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_View_dup", objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            else if(request.datarequest_id != 0  && request.ActionCode == "V")
            {
                try
                {
                    DynamicParameters objParam = new DynamicParameters();
                    objParam.Add("p_action", "VD");
                    objParam.Add("p_userId", request.Request_UserId);
                    objParam.Add("p_requestId", request.datarequest_id);
                    //objParam.Add("p_locationid", request.p_locationid);
                    var result = await Connection.QueryAsync<ExternalDataRequestDupDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_View_dup", objParam, commandType: CommandType.StoredProcedure);
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
                    var result = await Connection.QueryAsync<ExternalDataRequestDupDto>(/*"usp_ExternalData_View"*/"usp_ExternalData_View_dup", objParam, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
           


        }
        public async Task<List<ExternalDataCriteriaDisplayDup>> GetExternalDataCriteriaView(ExternalDataRequestDupDto request)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", request.ActionCode);
                objParam.Add("p_userId", request.Request_UserId);
                objParam.Add("p_requestId", request.datarequest_id);
                var result = await Connection.QueryAsync<ExternalDataCriteriaDisplayDup>("usp_ExternalData_View", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            

        }
        public async Task<int> DataRequestNotification(ExternalDataRequestDupDto datarequest)
        {
            DynamicParameters objParam = new DynamicParameters();
            objParam.Add("p_action", "N");
            objParam.Add("p_xml", "");
            objParam.Add("p_userId", 0);
            objParam.Add("p_requestStatus", 0);
            objParam.Add("p_requestPurpose", datarequest.Request_Purpose);
            objParam.Add("p_programName", "");
            objParam.Add("p_programCode", "");
            objParam.Add("p_country", "");
            objParam.Add("p_requiredService", 0);
            objParam.Add("p_otherService", datarequest.Other_Service_Request);
            objParam.Add("p_modeofSharing", "");
            objParam.Add("p_totalRegistered", 0);
            objParam.Add("p_createdBy", datarequest.createdby);
            objParam.Add("p_requestid_linked", "");
            objParam.Add("p_out", "", DbType.Int32, ParameterDirection.Output, 8);
            await Connection.ExecuteAsync("usp_multipledatasharing", objParam, null, null, CommandType.StoredProcedure);
            return objParam.Get<int>("p_out");
        }
        //Add By Rajkishor Patra(20-Oct-2022)
        public async Task<List<ExternalDataRequestDupDto>> GetExternalDataLatest(DataRequestCriteria datarequest)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                objParam.Add("p_action", "A");
                objParam.Add("p_lga", datarequest.slga);
                objParam.Add("p_district", datarequest.sdistrict);
                objParam.Add("p_ward", datarequest.sward);
                objParam.Add("p_town", datarequest.stown);
                objParam.Add("p_sex", datarequest.sexstringselect);
                objParam.Add("p_relationshiptohh", datarequest.relationshipofhouseholdselect);
                objParam.Add("p_maritalstatus", datarequest.maritalstatusselect);
                objParam.Add("p_residence", datarequest.residencestatusselect);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_nationality", datarequest.nationalityselect);//Add Rajkishor Patra(19-oct-2022)
               
                objParam.Add("p_haseverattendedschool", datarequest.haseverattendedschoolselect);
                objParam.Add("p_typeofschool", datarequest.whattypeofatnschoolselect);
                objParam.Add("p_levelandgradeatn", datarequest.whichlevelgradeatnselect);
                objParam.Add("p_iscurrentlyattendingschool", datarequest.iscurrentlyattendingschoolselect);
                objParam.Add("p_hasstoppedgoingtoschool", datarequest.stopgoingtoscholselect);
                objParam.Add("p_wasthelastlevelandgradethatnamecompleted", datarequest.lastlevelgradeselect);
                objParam.Add("p_read_writelanguage", datarequest.readandorwriteinanylanguageselect); //Add Rajkishor Patra(19-oct-2022)
               
                objParam.Add("p_doessufferanychronicillness", datarequest.doessufferanychronicillnessselect);
                objParam.Add("p_typeofchronicillness", datarequest.typeofchronicillnessselect);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultyseeing", datarequest.difficultyseeingselect);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultyhearing", datarequest.difficultyhearingselect);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_dohavediffwalking", datarequest.dohavediffwalkingselect);
                objParam.Add("p_difficultyrememberingorconcentrating", datarequest.difficultyrememberingorconcentratingselect);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultywithself_caresuchaswashing", datarequest.difficultywithself_caresuchaswashingselect);//Add Rajkishor Patra(19-oct-2022)
                objParam.Add("p_difficultycommunicating", datarequest.difficultycommunicatingselect);//Add Rajkishor Patra(19-oct-2022)


                objParam.Add("p_mainjobactivitylastthirtydays", datarequest.mainjobactivitylastthirtydaysselect);
                objParam.Add("p_howfrequently", datarequest.workingfrequentlyselect);
                objParam.Add("p_workingsector", datarequest.memberworkingsctrselect);
                objParam.Add("p_workingstatus", datarequest.memberworkingstatusselect);
                objParam.Add("p_reasonfornotworking", datarequest.reasonfornotworkingselect);


                objParam.Add("p_occupancystatusofdwelling", datarequest.occupancystatusofdwellingselect);
                objParam.Add("p_constructionmaterial", datarequest.mainconstructionselect);
                objParam.Add("p_materialusedforroofing", datarequest.materialusedforroofselect);
                objParam.Add("p_materialusedforflooring", datarequest.materialusedforfloorselect);
                objParam.Add("p_sourceoflighting", datarequest.sourceoflightingselect);
                objParam.Add("p_cookingfuel", datarequest.cookingfuelselect);
                objParam.Add("p_typeoftoiletfacility", datarequest.typeoftoiletfacilityselect);
                objParam.Add("p_sourceofdrinkingwater", datarequest.sourcedrinkingwaterselect);
                objParam.Add("p_disposerubbish", datarequest.disposerubbishselect);
                objParam.Add("p_distance_serviceid", datarequest.distance_serviceid);

                objParam.Add("p_mainincomesourceofhh", datarequest.mainincomesourceofhhselect);
                objParam.Add("p_secondmainsourceofincome", datarequest.secondmainsourceselect);
                objParam.Add("p_didhhreceivemonetaryhelp", datarequest.didhhreceivemonetaryhelpselect);
                objParam.Add("p_typeofaid", datarequest.typeofaidhouseselect);
                objParam.Add("p_howfrequentlyincome", datarequest.howfrequentlyselect);
                objParam.Add("p_typeoforganisation", datarequest.typeoforganisationselect);
                
                objParam.Add("p_doescultivateland", datarequest.doescultivatelandselect);
                objParam.Add("p_ownedbywhom", datarequest.ownedbywhomselect);
                objParam.Add("p_typeofecology", datarequest.typeofecologyselect);
                objParam.Add("p_responsibleforcultivation", datarequest.responsibleforcultivationselect);
                objParam.Add("p_catchingoffarmingfish", datarequest.involveincatchingselect);
                objParam.Add("p_ownlivestock", datarequest.householdownlivestockselect);
                objParam.Add("p_ishhaffectedbyevent", datarequest.ishhaffectedbyeventselect);
                objParam.Add("p_typeofsock", datarequest.shockswhichaffectedhouseholdselect);
                objParam.Add("p_lossesbysock", datarequest.lossesscausedbylossesselect);
                objParam.Add("p_livelyhoodcoping", datarequest.livelyhoodcopingselect);
                objParam.Add("p_foodcoping", datarequest.foodcopingselect);
                objParam.Add("p_pmtcatagory", datarequest.PMTcatagoryselect);
                
                var result = await Connection.QueryAsync<ExternalDataRequestDupDto>(datarequest.programmecodeid == 0 ? "usp_data_request_fetching_multipledata" /*"usp_datarequest_fetch"*/ : "usp_datarequest_fetch_withPC", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }
        public async Task<List<DataSharingExcelSecond>> GenerateDataByDownloadExcelSecond(int requestId)
        {
            try
            {
                DynamicParameters objParam = new DynamicParameters();
                // objParam.Add("p_action", "FFD");
                objParam.Add("p_userId", 0);
                objParam.Add("p_requestId", requestId);
                var result = await Connection.QueryAsync<DataSharingExcelSecond>("usp_datasharing_excel_second", objParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        //public async Task<ExternalDataRequestDto> GetRequestCriteria(ExternalDataRequestDto request)
        //{
        //    DynamicParameters objParam = new DynamicParameters();
        //    objParam.Add("p_action", request.ActionCode);
        //    objParam.Add("p_userId", request.Request_UserId);
        //    objParam.Add("p_requestId", request.datarequest_id);
        //    var result = await Connection.QueryAsync<ExternalDataRequestDto>("usp_ExternalData_View", objParam, commandType: CommandType.StoredProcedure);
        //    return result.FirstOrDefault();
        //}
    }
}
