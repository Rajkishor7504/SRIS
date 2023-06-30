using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Dashboard
{
    public class GetDemographicregisterdashboardQueries:IRequest<DemographicregisterdashboardVM>
    {
        public int hhid { get; set; }
    }
    public class GetDemographicregisterdashboardQueriesHandler : IRequestHandler<GetDemographicregisterdashboardQueries, DemographicregisterdashboardVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _idashboardService;

        public GetDemographicregisterdashboardQueriesHandler(IApplicationDbContext context, IMapper mapper, IDashboardService idashboardService)
        {
            _context = context;
            _mapper = mapper;
            _idashboardService = idashboardService;
        }

        public async Task<DemographicregisterdashboardVM> Handle(GetDemographicregisterdashboardQueries request, CancellationToken cancellationToken)
        {
            var entity = new DemographicregisterdashboardDto();
            return new DemographicregisterdashboardVM
            {
                Lists = await _idashboardService.Getdemographicreg(entity)

            };
        }
    }
}
