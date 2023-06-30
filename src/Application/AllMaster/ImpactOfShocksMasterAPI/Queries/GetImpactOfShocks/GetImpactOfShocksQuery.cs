/*
* File Name : GetImpactOfShocksQuery.cs
* class Name : GetImpactOfShocksQuery, GetImpactOfShocksQuerysMasterHandler
* Created Date : 18th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the ImpactOfShocks  Master records
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

namespace SRIS.Application.AllMaster.ImpactOfShocksMasterAPI.Queries.GetImpactOfShocks
{
   public class GetImpactOfShocksQuery : IRequest<ImpactOfShocksVM>
    {
        public int id { get; set; }
    }

    public class GetImpactOfShocksQuerysMasterHandler : IRequestHandler<GetImpactOfShocksQuery, ImpactOfShocksVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImpactOfShocksService _impactOfShocksService;

        public GetImpactOfShocksQuerysMasterHandler(IApplicationDbContext context, IMapper mapper, IImpactOfShocksService impactOfShocksService)
        {
            _context = context;
            _mapper = mapper;
            _impactOfShocksService = impactOfShocksService;
        }

        #region "To get the Education Master records"

        public async Task<ImpactOfShocksVM> Handle(GetImpactOfShocksQuery request, CancellationToken cancellationToken)
        {
            ImpactOfShocksVM model = new ImpactOfShocksVM();
            model.livelihoodType = await _impactOfShocksService.GetlivelihoodData();
           model.shocksSeverityType = await _impactOfShocksService.GetSeverityTypeData();
            model.affectedShocksType = await _impactOfShocksService.GetShocksData();
            return model;
        }
        #endregion
    }
}
