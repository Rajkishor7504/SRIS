
/*
* File Name : GetCopingStrategiesQuery.cs
* class Name : GetCopingStrategiesQuery, GetCopingStrategiesMasterHandler
* Created Date : 17th June 2021
* Created By : Rajalaxmi behera
* Description : Query to get the Coping Strategies  Master records
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

namespace SRIS.Application.AllMaster.CopingStrategiesHouseholdMasterAPI.Queries.GetCopingStrategies
{
   public class GetCopingStrategiesQuery : IRequest<CopingStrategiesVM>
    {
        public int id { get; set; }
    }
    public class GetCopingStrategiesMasterHandler : IRequestHandler<GetCopingStrategiesQuery, CopingStrategiesVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICopingStrategiesService _copingStrategiesService;

        public GetCopingStrategiesMasterHandler(IApplicationDbContext context, IMapper mapper, ICopingStrategiesService copingStrategiesService)
        {
            _context = context;
            _mapper = mapper;
            _copingStrategiesService = copingStrategiesService;
        }

        #region "To get the Education Master records"

        public async Task<CopingStrategiesVM> Handle(GetCopingStrategiesQuery request, CancellationToken cancellationToken)
        {
            CopingStrategiesVM model = new CopingStrategiesVM();
            model.copingStrategyType = await _copingStrategiesService.GetcopingStrategyData();
            model.restoringType = await _copingStrategiesService.GetrestoringData();
            model.foodrestoringType = await _copingStrategiesService.GetfoodrestoringData();
            return model;
        }
        #endregion
    }
}
