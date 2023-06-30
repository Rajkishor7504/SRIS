﻿using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.EducationInfo.Queries.GetEducationInfo
{
    public class GetEducationInfoQuery : IRequest<EducationInfoVM>
    {
        public string action { get; set; }
        public int educationinfoid { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
    }
    public class GetEducationInfoQueryHandler : IRequestHandler<GetEducationInfoQuery, EducationInfoVM>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetEducationInfoQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<EducationInfoVM> Handle(GetEducationInfoQuery request, CancellationToken cancellationToken)
        {
            EducationInfoVM objVM = new EducationInfoVM();
            try
            {
                objVM.status = "200";
                objVM.Lists = await _iHouseholdService.GetEducationInfo(request);
                objVM.message =CommonHelper.GetEnumDescription((ResponseStatus)200);


            }

            catch (Exception ex)
            {
                objVM.status = "500";
                objVM.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objVM.errorMessage = ex.Message;
            }
            return objVM;


        }
    }
}
