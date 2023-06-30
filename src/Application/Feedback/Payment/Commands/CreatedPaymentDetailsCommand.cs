using MediatR;
using SRIS.WebUI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Feedback.Payment.Queries;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static SRIS.Application.Feedback.Payment.Queries.UpdateHouseholdBenificiaryVM;
using Microsoft.Extensions.Configuration;
using SRIS.Application.Common.Interfaces.IService;

namespace SRIS.Application.Feedback.Payment.Commands
{
 
    public class CreatedPaymentDetailsCommand : IRequest<UpdateHouseholdBenificiaryVM>
    {
        public string programmcode { get; set; }
        public string username { get; set; }
        public string remark { get; set; }
        public int programdetailsid { get; set; }
        public int paymentid { get; set; }
        public List<UpdateHouseholdDto> updatehousehold { get; set; }

    }
   
    public class CreatedPaymentDetailsCommandHandler : IRequestHandler<CreatedPaymentDetailsCommand, UpdateHouseholdBenificiaryVM>
    {
       
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IDatasharingService _idatasharingService;


        public CreatedPaymentDetailsCommandHandler(IApplicationDbContext context, IDateTime datetime, IHostingEnvironment hostingEnvironment, IDatasharingService idatasharingService)
        {
           
            _context = context;
            _datetime = datetime;
            _hostingEnvironment = hostingEnvironment;
            _idatasharingService = idatasharingService;



        }

        public async Task<UpdateHouseholdBenificiaryVM> Handle(CreatedPaymentDetailsCommand request, CancellationToken cancellationToken)
        {
            string retval =null;
            string value = ConfigurationManager.AppSetting["MySettings:WebFilePathUpload"];
            //var entity = new Paymentprogramdtls();
            var entitydto = new ExternalPaymentDto();
            var dt = request.updatehousehold;
            UpdateHouseholdBenificiaryVM ob = new UpdateHouseholdBenificiaryVM();
            try
            {
                var results = JsonConvert.SerializeObject(dt);
                string webRootPathExp = value + "/UpdateHouseholdBenificiary/ProgrammeCode";
                if (!Directory.Exists(webRootPathExp))
                    Directory.CreateDirectory(webRootPathExp);
                var strFile = request.updatehousehold[0].programmcode + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".json";
                var path = Path.Combine(webRootPathExp.Replace("\\", "/") + "/" + strFile);
                var sourceDirectory = new PhysicalFileProvider(webRootPathExp.Replace("\\", "/")).Root;
                DirectoryInfo sourceinfo = new DirectoryInfo(sourceDirectory);
                foreach (FileInfo fi in sourceinfo.GetFiles())
                {
                    if (fi.Length != 0)
                    {
                        string Extension = Path.GetExtension(fi.Name);
                        string FileName = Path.GetFileNameWithoutExtension(fi.Name);
                        string NewFileName = FileName + "_" + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + Extension;
                    }
                }
                System.IO.File.WriteAllText(path, results);

                if (request.updatehousehold.Count != 0)
                {
                    entitydto.programname = request.updatehousehold[0].programmname;
                    entitydto.programcode = request.programmcode;
                    entitydto.username = request.username;
                    entitydto.createdon = _datetime.Now;
                    entitydto.remark = request.remark;
                    entitydto.filename = strFile;
                    entitydto.documentType = 2;
                    retval=await _idatasharingService.Updatehouseholdbenificiary(entitydto);
                }
                else
                {
                    ob.status = "501";
                    ob.message = CommonHelper.GetEnumDescription((ResponseStatus)501);
                    ob.errorMessage = "";
                }


                ob.status = "600";
                ob.message = CommonHelper.GetEnumDescription((ResponseStatus)600);
                ob.errorMessage = "";

            }
            catch (System.Exception ex)
            {
                ob.status = "500";
                ob.message = ex.Message;
                ob.errorMessage = ex.Message;
            }

            return ob;
        }
      
    }
    static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}

