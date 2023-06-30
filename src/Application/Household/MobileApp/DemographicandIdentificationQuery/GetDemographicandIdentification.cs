using MediatR;
using Microsoft.Extensions.Options;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.MobileApp.DemographicandIdentificationQuery
{
   public class GetDemographicandIdentification : IRequest<DemographicandIdentificationVM>
    {
        public string userId { get; set; }
        public string householdNo { get; set; }
        public string hhid { get; set; }
        public string imageUploadUrl { get; set; }
    }
    public class GetDemographicandIdentificationHandler : IRequestHandler<GetDemographicandIdentification, DemographicandIdentificationVM>
    {


        private readonly IHouseholdServiceMobile _iHouseholdService;
   

        public GetDemographicandIdentificationHandler(IHouseholdServiceMobile iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<DemographicandIdentificationVM> Handle(GetDemographicandIdentification request, CancellationToken cancellationToken)
        {
            DemographicandIdentificationVM objVM = new DemographicandIdentificationVM();
            try
            {
                var profileimage = "";
                var birthimage = "";
                var idimage = "";
                var webRootPath = request.imageUploadUrl;
               
                
                objVM.identification = await _iHouseholdService.GetIdentification(request);
                var demolist =  _iHouseholdService.GetDemographicList(request).Result; 
                var list = demolist.Select(x =>
                {
                    #region--------convert profile image to base 64 string-----------------------
                    var profileimage = webRootPath + x.profileImgPath;
                    if (System.IO.File.Exists(profileimage))
                    {

                        byte[] bytesprofile = System.IO.File.ReadAllBytes(profileimage);
                        string imgprofileBase64Data = Convert.ToBase64String(bytesprofile);
                        x.profileImgPath = x.profileImgPath != null ? imgprofileBase64Data : "";
                    }
                    else
                    {
                        x.profileImgPath = "";
                    }

                    #endregion

                    #region--------convert birth image to base 64 string-----------------------
                    var birthimage = webRootPath + x.birthCertfFile;
                    if (System.IO.File.Exists(birthimage))
                    {

                        byte[] bytesbirth = System.IO.File.ReadAllBytes(birthimage);
                        string imgbirthBase64Data = Convert.ToBase64String(bytesbirth);
                        x.birthCertfFile = x.birthCertfFile != null ? imgbirthBase64Data : "";
                    }
                    else
                    {
                        x.birthCertfFile = "";
                    }

                    #endregion


                    #region--------convert id image to base 64 string-----------------------
                    var idproofimage = webRootPath + x.identDocFile;
                    if (System.IO.File.Exists(idproofimage))
                    {

                        byte[] bytesidproof = System.IO.File.ReadAllBytes(idproofimage);
                        string imgidproofBase64Data = Convert.ToBase64String(bytesidproof);
                        x.identDocFile = x.identDocFile != null ? imgidproofBase64Data : "";
                    }
                    else
                    {
                        x.identDocFile = "";
                    }

                    #endregion

                    return x;
                }).ToList();
               objVM.demographic = list;


                //objVM.demographic = await _iHouseholdService.GetDemographicList(request);
                objVM.status = "200";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                objVM.errorMessage = "";
            }

            catch (Exception ex)
            {
                objVM.identification = null;
                objVM.demographic = null;
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;

        }
    }
}
