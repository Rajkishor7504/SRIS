using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.DistanceInfo.Queries.GetDistanceInfoQuery;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.DistanceInfo.Commands
{
    public class CreateDistanceInfoCommand : IRequest<DistanceInfoList>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int createdby { get; set; }
        public string DistanceXML { get; set; }
        public int apptypeid { get; set; }
        public List<HouseholdDistance> hhDistance { get; set; }
    }
    public class CreateDistanceInfoCommandHandler : IRequestHandler<CreateDistanceInfoCommand, DistanceInfoList>
    {


        private readonly IHouseholdService _iHouseholdService;

        public CreateDistanceInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<DistanceInfoList> Handle(CreateDistanceInfoCommand request, CancellationToken cancellationToken)
        {

            int retval = 0;
            DistanceInfoList objEmpList = new DistanceInfoList();
            int validationcount = 0;
            try
            {
                if (request.hhDistance != null)
                {
                    foreach (HouseholdDistance hhd in request.hhDistance)
                    {
                        if (hhd.distanceinkm == 0 || hhd.timeinmin == 0 || hhd.transportationmodeid == 0 || (hhd.transportationmodeid == 100001 && hhd.othertransportation == ""))
                        {
                            validationcount += 1;
                        }
                    }
                }
                //if ((request.hhid == 0) || (validationcount > 0))
                //{
                //    objEmpList.status = "400";
                //    objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)400);
                //}
                //else
                //{
                var entity = new DistanceInfoDto();
                entity.action = request.action;
                entity.hhid = request.hhid;
                entity.hhDistance = request.hhDistance;

                entity.createdby = request.createdby;
                entity.apptypeid = request.apptypeid;
                retval = await _iHouseholdService.AddDistanceInfo(entity);
                objEmpList.status = retval.ToString();
                objEmpList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                //}
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
