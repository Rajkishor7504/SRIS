/*
* File Name : GetIncomeSourceQuery.cs
* class Name : GetIncomeSourceQuery, GetIncomeSourceMasterHandler
* Created Date : 18th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the IncomeSource Related All Master records
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

namespace SRIS.Application.AllMaster.IncomeSourceAPI.Queries.GetIncomeSourceAllMaster
{
   public class GetIncomeSourceQuery : IRequest<IncomeSourceApiVM>
    {
        public int id { get; set; }

    }
    public class GetIncomeSourceMasterHandler : IRequestHandler<GetIncomeSourceQuery, IncomeSourceApiVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIncomeSourcesMasterService _incomeSourcesMasterService;

        public GetIncomeSourceMasterHandler(IApplicationDbContext context, IMapper mapper, IIncomeSourcesMasterService incomeSourcesMasterService)
        {
            _context = context;
            _mapper = mapper;
            _incomeSourcesMasterService = incomeSourcesMasterService;
        }

        #region "To get the Employee All Master records"

        public async Task<IncomeSourceApiVM> Handle(GetIncomeSourceQuery request, CancellationToken cancellationToken)
        {
            IncomeSourceApiVM model = new IncomeSourceApiVM();           
            model.mainIncomeSource = await _incomeSourcesMasterService.GetmainIncomeSourceData();
            model.secondIncomeSource = await _incomeSourcesMasterService.GetsecondIncomeSourceData();
            model.aidType = await _incomeSourcesMasterService.GetaidTypeData();
            model.aidFrequency = await _incomeSourcesMasterService.GetaidFrequencyData();
            model.orgType = await _incomeSourcesMasterService.GetorgTypeData();          
            return model;
        }
        #endregion
    }
}
