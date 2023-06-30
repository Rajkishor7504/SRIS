using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.AssetInfo.Commands
{
    public class DeleteAssetInfoCommand:IRequest<AssetInfoList>
    {
        public int hhid { get; set; }
        public int createdby { get; set; }
        public int apptypeid { get; set; }
        public int assetid { get; set; }
    }
    public class DeleteAssetInfoCommandHandler : IRequestHandler<DeleteAssetInfoCommand, AssetInfoList>
    {
        private readonly IHouseholdService _iHouseholdService;

        public DeleteAssetInfoCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<AssetInfoList> Handle(DeleteAssetInfoCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            AssetInfoList obj = new AssetInfoList();

            try
            {

                retval = await _iHouseholdService.DeleteAssetInfo(request.assetid, request.createdby, request.apptypeid);
                obj.status = Convert.ToString(retval);
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);

            }
            catch (Exception ex)
            {
                obj.status = "500";
                obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                obj.errorMessage = ex.Message;
            }
            return obj;
        }
    }
}
