using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.DemographicMember.Queries.GetDemographicMember;
using SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using SRIS.Application.Common.Interfaces.IService;

namespace SRIS.Application.Household.DemographicMember.CommandsMobile
{
  public  class RejectDemographicandIdentification : IRequest<DemographicVM>
    {
        public string action { get; set; }
        public string hhNo { get; set; }
        public string deviceId { get; set; }
        public string createdby { get; set; }
        public string hhid { get; set; }
        public string imageUploadUrl { get; set; }
        public identificationdto identification { get; set; }
        public List<DemographicModel> demographic { get; set; }
    }
    public class RejectDemographicandIdentificationHandler : IRequestHandler<RejectDemographicandIdentification, DemographicVM>
    {


        private readonly IHouseholdService _iHouseholdService;
        private readonly IHouseholdServiceMobile _iHouseholdServiceMobile;
        private readonly IWebHostEnvironment _iHostingEnvironment;


        public RejectDemographicandIdentificationHandler(IHouseholdService iHouseholdService,IHouseholdServiceMobile iHouseholdServiceMobile, IWebHostEnvironment iHostingEnvironment)
        {
            _iHouseholdService = iHouseholdService;
            _iHouseholdServiceMobile = iHouseholdServiceMobile;
            _iHostingEnvironment = iHostingEnvironment;
        }

        public async Task<DemographicVM> Handle(RejectDemographicandIdentification request, CancellationToken cancellationToken)
        {

            int retval = 0;
            int demoretval = 0;
            DemographicVM objDemoList = new DemographicVM();
            try
            {
                string webrootpath = (request.imageUploadUrl != null && request.imageUploadUrl != "") ? request.imageUploadUrl : _iHostingEnvironment.WebRootPath;
                if (request.hhid != null && request.hhid != "")
                {               
                    var hhentity = new RegisterHouseholdDto();
                    hhentity.hhid= (request.hhid != null && request.hhid !="") ? Convert.ToInt32(request.hhid):0;
                    hhentity.createdby = request.createdby.ToString();
                    hhentity.action = request.action;
                    hhentity.teamId = Convert.ToInt32(request.identification.teamId);
                    hhentity.clusterno = Convert.ToInt32(request.identification.clusterno);
                    hhentity.lgaid = Convert.ToInt32(request.identification.lga);
                    hhentity.telephoneno = request.identification.telephoneNo;
                    hhentity.wardid = Convert.ToInt32(request.identification.ward);
                    hhentity.areaid = Convert.ToInt32(request.identification.area);
                    hhentity.settlementid = Convert.ToInt32(request.identification.settlementId);
                    hhentity.districtid = Convert.ToInt32(request.identification.district);
                    hhentity.dateofinterview = request.identification.dateOfInterView.ToString();
                    hhentity.interviewer = request.identification.interviewer;
                    hhentity.supervisor = request.identification.supervisor;
                    hhentity.longitude = request.identification.longitude;
                    hhentity.latitude = request.identification.latitude;
                    hhentity.hhno = request.hhNo.ToString() != "" ? request.hhNo.ToString() : "0";
                    hhentity.eano = request.identification.eaNo;
                    hhentity.isaggreed = Convert.ToInt32(request.identification.agreeOfInterview);
                    hhentity.compoundno = request.identification.compoundNo.ToString();
                    hhentity.address = request.identification.address;
                    hhentity.respondantname = request.identification.respondentName;
                    hhentity.householdheadname = request.identification.headHhName;
                    hhentity.resultofhhinterview = request.identification.interviewResult.ToString();
                    hhentity.observation = request.identification.observation;
                    hhentity.createdby = request.createdby.ToString();              
                    hhentity.hhcode = request.identification.hhCode != null ? request.identification.hhCode : "";
                    hhentity.spotchecker = Convert.ToInt32(request.identification.spotchecker);
                    hhentity.surveyplanid = Convert.ToInt32(request.identification.surveyId);
                    hhentity.supervisor = request.identification.supervisorName != null ? request.identification.supervisorName : "";
                    retval = await _iHouseholdService.AddRegisterHousehold(hhentity);
                }
                if (retval == 200 || retval==201)
                {
                   
                    int demoindex = 0;
                    foreach (var demographic in request.demographic)
                    {
                        demoretval = demoretval + 1;
                        if ((demographic.firstname != null) || (demographic.lastname != null))
                        {

                            var entity = new DemographicMemberDto();
                            string bpath = "";
                            string ppath = "";
                            string ipath = "";

                            #region---------image part-----------------------

                            GetDemographicMemberQuery objdemorow = new GetDemographicMemberQuery();
                            objdemorow.action = "M";
                            int index = _iHouseholdService.GetDemographicMember(objdemorow).Result.FirstOrDefault().memberid;// get last member id
                            //int getmemberid = await _iHouseholdService.ApproveRejectDemographicMember(0, 0, 0, "A", demographic.memberSlNo, 0); // check member id by passing membercode

                            if (Convert.ToInt32(demographic.demoId) > 0)//get member id passing throuht api
                            {
                                index = demographic.demoId != null && demographic.demoId != "" ? Convert.ToInt32(demographic.demoId) : 0; 
                            }
                            else
                            {
                                index = index + 1;
                            }



                            GetRegisterHouseholdQuery objset = new GetRegisterHouseholdQuery();
                            objset.action = "MS";
                            objset.locationid = Convert.ToInt32(request.identification.settlementId);
                            var settlementcode = _iHouseholdService.GetRegisterHousehold(objset).Result.FirstOrDefault().settlementcode != null ? _iHouseholdService.GetRegisterHousehold(objset).Result.FirstOrDefault().settlementcode : "No";
                            //Birth Image
                            string BaseDemoFolder = Path.Combine(webrootpath, "Demographic");
                            if (demographic.birthCertfFile != "" && demographic.birthCertfFile != null && demographic.birthImgStr != null && demographic.birthImgStr != "" && settlementcode != null)
                            {
                                var bytesbirth = Convert.FromBase64String(demographic.birthCertfFile);


                                string birthfiledir = Path.Combine(BaseDemoFolder, settlementcode); //"Demographic" + @"\" + settlementcode 
                                string ProcDocbirthPath = Path.Combine(webrootpath, birthfiledir);
                                if (!Directory.Exists(ProcDocbirthPath))
                                    Directory.CreateDirectory(ProcDocbirthPath);

                                string BirthFolder = Path.Combine(birthfiledir, "BirthCertificate");
                                string ProcDocSubbirthPath = Path.Combine(webrootpath, BirthFolder); // "Demographic" + @"\" + settlementcode + @"\" + "BirthCertificate";
                                if (!Directory.Exists(ProcDocSubbirthPath))
                                    Directory.CreateDirectory(ProcDocSubbirthPath);

                                bpath = index + "_BirthCertificate." + demographic.birthImgStr.Split(".")[1]; ///file extension ex-jpg
                                string birthcerfile = Path.Combine(ProcDocSubbirthPath, bpath);
                                if (bytesbirth.Length > 0)
                                {
                                    using (var stream2 = new FileStream(birthcerfile, FileMode.Create))
                                    {
                                        stream2.Write(bytesbirth, 0, bytesbirth.Length);
                                        stream2.Flush();

                                    }
                                }
                            }
                            //Profile Image
                            if (demographic.profileImgPath != "" && demographic.profileImgPath != null && demographic.profileImgStr != null && demographic.profileImgStr != "" && settlementcode != null)
                            {
                                string filedir = Path.Combine(BaseDemoFolder, settlementcode); //"Demographic" + @"\" + settlementcode                               
                                string ProcDocPath = Path.Combine(webrootpath, filedir);
                                if (!Directory.Exists(ProcDocPath))
                                    Directory.CreateDirectory(ProcDocPath);

                                string filesubdir = Path.Combine(filedir, "ProfilePhoto"); //"Demographic" + @"\" + settlementcode + @"\" + "ProfilePhoto";
                                string ProcDocSubPath = Path.Combine(webrootpath, filesubdir);

                                if (!Directory.Exists(ProcDocSubPath))
                                    Directory.CreateDirectory(ProcDocSubPath);

                                var bytes = Convert.FromBase64String(demographic.profileImgPath);
                                ppath = index + "_ProfilePhoto." + demographic.profileImgStr.Split(".")[1];



                                string profilefile = Path.Combine(ProcDocSubPath, ppath);
                                if (bytes.Length > 0)
                                {
                                    using (var stream1 = new FileStream(profilefile, FileMode.Create))
                                    {
                                        stream1.Write(bytes, 0, bytes.Length);
                                        stream1.Flush();

                                    }
                                }
                            }

                            //Identity Image
                            if (demographic.identDocFile != "" && demographic.identDocFile != null && demographic.identImgPStr != null && demographic.identImgPStr != "" && settlementcode != null)
                            {
                                var bytesidentity = Convert.FromBase64String(demographic.identDocFile);

                                string identityfiledir = Path.Combine(BaseDemoFolder, settlementcode);
                                string ProcDocidPath = Path.Combine(webrootpath, identityfiledir);
                                if (!Directory.Exists(ProcDocidPath))
                                    Directory.CreateDirectory(ProcDocidPath);

                                string identityfilesubdir = Path.Combine(identityfiledir, "IDProof");// "Demographic" + @"\" + settlementcode + @"\" + "IDProof";
                                string ProcDocSubidPath = Path.Combine(webrootpath, identityfilesubdir);

                                if (!Directory.Exists(identityfilesubdir))
                                    Directory.CreateDirectory(ProcDocSubidPath);

                                ipath = index + "_IDProof." + demographic.identImgPStr.Split(".")[1];
                                string identitycerfile = Path.Combine(ProcDocSubidPath, ipath);
                                if (bytesidentity.Length > 0)
                                {
                                    using (var stream3 = new FileStream(identitycerfile, FileMode.Create))
                                    {
                                        stream3.Write(bytesidentity, 0, bytesidentity.Length);
                                        stream3.Flush();

                                    }

                                }
                            }

                            #endregion

                            entity.hhid = Convert.ToInt32(request.hhid);
                            entity.memberid = demographic.demoId!=null && demographic.demoId != "" ? Convert.ToInt32(demographic.demoId):0;
                            entity.uploadphotopath = ppath;
                            entity.uploadbirthcertificate = bpath;//birth certificate
                            entity.uploadidproof = ipath;//identity certificate
                            entity.action = request.action;
                           
                            entity.firstname = demographic.firstname;
                            entity.lastname = demographic.lastname;
                            entity.sex = Convert.ToInt32(demographic.sexId);
                            entity.relationshiptohhid = Convert.ToInt32(demographic.relationToHhId);                           
                            entity.residencestatusid = Convert.ToInt32(demographic.residentStatusId);
                            entity.dohavebirthcertificate = demographic.hvBirthCertfId != "" ? Convert.ToInt32(demographic.hvBirthCertfId) : 0;
                            entity.dateofarrival = Convert.ToDateTime(demographic.dateOfArival).ToString("yyyy-MM-dd");
                            entity.dateofbirth = Convert.ToDateTime(demographic.dateOfBirth).ToString("yyyy-MM-dd");
                            entity.ethnicityid = demographic.ethinicityId != "" ? Convert.ToInt32(demographic.ethinicityId) : 0;
                            entity.age = Convert.ToInt32(demographic.age);
                            entity.maritalstatusid = demographic.maritalStatusId != "" ? Convert.ToInt32(demographic.maritalStatusId) : 0;
                            entity.placeofbirthid = demographic.placeOfBirthId != "" ? Convert.ToInt32(demographic.placeOfBirthId) : 0;
                            entity.isfatherstillalive = demographic.fatherIsAliveId != "" ? Convert.ToInt32(demographic.fatherIsAliveId) : 0;
                            entity.nationalityid = demographic.nationalityId != "" ? Convert.ToInt32(demographic.nationalityId) : 0;
                            entity.identificationdocids = demographic.identificationDocId;
                            entity.fatherliveinhousehold = demographic.fatherLiveInHhId != "" ? Convert.ToInt32(demographic.fatherLiveInHhId) : 0;
                            entity.identificationno = demographic.identificationNo;
                            entity.ismotherstillalive = demographic.motherIsAliveId != "" ? Convert.ToInt32(demographic.motherIsAliveId) : 0;
                            entity.motherliveinhousehold = demographic.motherLiveInHhId != "" ? Convert.ToInt32(demographic.motherLiveInHhId) : 0;
                            entity.recrdlineoffather = demographic.recrdlineoffather != "" ? demographic.recrdlineoffather : "NA"; //Add by Rajkishor Patra(04-Nov-2022)
                            entity.recrdlineofmother = demographic.recrdlineofmother != "" ? demographic.recrdlineofmother : "NA"; //Add by Rajkishor Patra(04-Nov-2022)
                            entity.createdby = request.createdby.ToString();
                            entity.membercode = demographic.memberSlNo != null ? demographic.memberSlNo : "";
                            demoretval = await _iHouseholdService.AddDemographicMember(entity);
                            if (demoretval == 200 || demoretval == 201)
                            {
                                demoindex = demoindex + 1;
                            }
                        }
                        else
                        {
                            demoindex = demoindex + 1;
                        }
                    }
                    if (request.demographic.Count == demoindex && retval == 200 || retval==201)
                    {
                        int statuscnt = await _iHouseholdServiceMobile.CheckStatusOfHousehold("A", (request.hhid != null && request.hhid != "") ? Convert.ToInt32(request.hhid) : 0, Convert.ToInt32(request.createdby));
                        GetDemographicMemberQuery objdemo = new GetDemographicMemberQuery();
                        objdemo.action = "VM";
                        objdemo.hhid = Convert.ToInt32(request.hhid);
                        var demographiclist = _iHouseholdService.GetDemographicMember(objdemo).Result;
                        var list = (from a in demographiclist
                                    select new DemoResponsemodel
                                    {
                                        id = a.memberid,
                                        memeberName = a.membername
                                    }).ToList();
                        objDemoList.demographicMemeber = list;
                        objDemoList.hhid = Convert.ToInt32(request.hhid).ToString();
                        objDemoList.errorMessage = "";
                        objDemoList.status = MobileApiStatusCode.OK;
                        objDemoList.message = "Success";
                    }
                    else
                    {
                        objDemoList.errorMessage = "";
                        objDemoList.status = "201";
                        objDemoList.message = CommonHelper.GetEnumDescription((ResponseStatus)201);
                    }

                }
            }
            catch (Exception ex)
            {
                objDemoList.status = "500";
                objDemoList.message = ex.Message;
                objDemoList.errorMessage = ex.Message;
            }
            return objDemoList;

        }
    }
}
