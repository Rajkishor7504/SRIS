using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Masters.Queries.GetMaster;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Masters.Commands.CreateMasterList
{
    public class CreateDemographyMasterCommand : IRequest<int>
    {
        public string action { get; set; }
        public string levelname { get; set; }
        public int levelid { get; set; }
        public int parentid { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public int leveldetailid { get; set; }
    }
    public class CreateDemographyMasterCommandHandler : IRequestHandler<CreateDemographyMasterCommand, int>
    {
        private readonly IMasterService _iMasterService;

        public CreateDemographyMasterCommandHandler(IMasterService iMasterService)
        {
            _iMasterService = iMasterService;
        }

        public async Task<int> Handle(CreateDemographyMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            MasterList obj = new MasterList();
            int retval = 0;
            try
            {
                //if (request.levelid == 0 ||  string.IsNullOrEmpty(request.levelname) || string.IsNullOrEmpty(request.description))
                //{
                //    obj.status = "400";
                //    obj.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                //}
                //else
                //{
                var entity = new MasterDto();

                entity.action = request.action;
                entity.levelname = request.levelname;
                entity.levelid = request.levelid;
                entity.parentid = request.parentid;
                entity.description = request.description;
                entity.code = Convert.ToString(request.code);
                entity.leveldetailid = request.leveldetailid;

                bool hasSpecialChars = rgx.IsMatch(entity.levelname);
                if (entity.description != null)
                {
                    bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                    if (hasSpecialChars == false && hasSpecialChars1 == false)
                    {
                        retval = await _iMasterService.AddDemographyMaster(entity);
                    }
                    else
                    {
                        retval = 403;


                    }
                }

                else if (hasSpecialChars == false)
                {
                    retval = await _iMasterService.AddDemographyMaster(entity);
                }
                else
                {
                    retval = 403;


                }
                obj.status = retval.ToString();
                // obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                // }
            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
            }
            return retval;
        }
    }
}
