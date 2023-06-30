using MediatR;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Application.SurveyPlanning.EnumerationArea.Query;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumerationArea.Command
{
   public class CreateEanoAreaCommand : IRequest<CommonMobileApiStatus> 
    {
        public int eaid { get; set; }
        public int createdby { get; set; }
        public int surveyplanid { get; set; }
        public string eano { get; set; }
        public string action { get; set; }
        public int clusterno { get; set; }
        public int regionid { get; set; }
        public int distid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int id { get; set; }
        public List<EanoAreaDto> locationdata { get; set; }
    }
    public class CreateEanoAreaCommandHandler : IRequestHandler<CreateEanoAreaCommand, CommonMobileApiStatus>
    {


        private readonly ISurveyPlanService _iSurveyPlanService;

        public CreateEanoAreaCommandHandler(ISurveyPlanService iSurveyPlanService)
        {
            _iSurveyPlanService = iSurveyPlanService;
        }

        public async Task<CommonMobileApiStatus> Handle(CreateEanoAreaCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            CommonMobileApiStatus objEmpList = new CommonMobileApiStatus();
            int validationcountl = 0;
            int validationcountf = 0;
            try
            {
               if(request.action=="A")
                {
                    int chk = await _iSurveyPlanService.CheckEano("A", request.eano != null ? request.eano : "",0);
                    //if (chk == 1)
                    //{
                    //    objEmpList.status = "401";
                    //    objEmpList.message = "Eano iis Avilable";
                    //}
                    //else
                    //{


                        if (request.locationdata != null)
                        {
                            foreach (var lc in request.locationdata)
                            {
                                if (lc.regionid == 0)
                                {
                                    validationcountl += 1;
                                }
                            }
                        }

                        if ((request.eano == null && request.action == "U") || (validationcountl > 0) || validationcountf > 0)
                        {
                            objEmpList.status = "400";
                            objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                        }
                        else
                        {
                            var entity = new EanoAreaindoDto();
                            entity.action = request.action;
                            entity.surveyplanid = request.surveyplanid;
                            entity.clusterno = request.clusterno;
                            entity.regionid = request.regionid;
                            entity.distid = request.distid;
                            entity.wardid = request.wardid;
                            entity.settlementid = request.settlementid;
                            entity.eano = request.eano;
                            entity.createdby = request.createdby;
                            //entity.locationdata = request.locationdata;
                            retval = await _iSurveyPlanService.AddEnumerationArea(entity);
                            objEmpList.status = retval.ToString();
                            objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                        }
                    //}

                }
               //if(request.action=="U")
                    if (request.action == "EU")
                    {
                    int chkedit = await _iSurveyPlanService.CheckEano("B", request.eano != null ? request.eano : "",request.eaid);
                    //if (chkedit == 1)
                    //{
                    //    objEmpList.status = "401";
                    //    objEmpList.message = "Eano iis Avilable";
                    //}
                    //else
                    //{
                        var entity = new EanoAreaindoDto();
                        entity.action = request.action;
                    entity.eaid = request.eaid;
                    entity.enumdetlid = request.id;
                    entity.clusterno = request.clusterno;
                    entity.regionid = request.regionid;
                    entity.distid = request.distid;
                    entity.wardid = request.wardid;
                    entity.settlementid = request.settlementid;
                    entity.surveyplanid = request.surveyplanid;
                        entity.eano = request.eano;
                        entity.createdby = request.createdby;
                       // entity.locationdata = request.locationdata;
                        retval = await _iSurveyPlanService.AddEnumerationArea(entity);
                        objEmpList.status = retval.ToString();
                        objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                    //}
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
