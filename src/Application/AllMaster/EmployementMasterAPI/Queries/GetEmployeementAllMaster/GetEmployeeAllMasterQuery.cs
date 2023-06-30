/*
* File Name : GetEmployeeAllMasterQuery.cs
* class Name : GetEmployeeAllMasterQuery, GetEmployeeAllMasterHandler
* Created Date : 16th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the Employee Related All Master records
*/
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.EmployementMasterAPI.Queries.GetEmployeementAllMaster
{
   public class GetEmployeeAllMasterQuery : IRequest<EmployementMasterVM>
    {
        public int id { get; set; }

    }
    public class GetEmployeeAllMasterHandler : IRequestHandler<GetEmployeeAllMasterQuery, EmployementMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmployementMasterService _employementMasterService;

        public GetEmployeeAllMasterHandler(IApplicationDbContext context, IMapper mapper, IEmployementMasterService employementMasterService)
        {
            _context = context;
            _mapper = mapper;
            _employementMasterService = employementMasterService;
        }

        #region "To get the Employee All Master records"

        public async Task<EmployementMasterVM> Handle(GetEmployeeAllMasterQuery request, CancellationToken cancellationToken)
        {
            EmployementMasterVM model = new EmployementMasterVM();
            model.mainJobActiviy = await _employementMasterService.GetmainJobActiviyData();
            model.workingFrequency = await _employementMasterService.GetworkingFrequencyData();
            model.workingSector = await _employementMasterService.GetworkingSectorData();
            model.workingStatus = await _employementMasterService.GetworkingStatusData();
            model.notWorkingReason = await _employementMasterService.GetnotWorkingReasonData();
            return model;
        }
        #endregion
    }
}
