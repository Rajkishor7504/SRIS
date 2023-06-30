using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Report
{
    public class GetHouseholdcatagoryQueries : IRequest<HouseholdcatagoryVM>
    {
        public int hhid { get; set; }
    }
    public class GetHouseholdcatagoryQueriesHandler : IRequestHandler<GetHouseholdcatagoryQueries, HouseholdcatagoryVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IReporthhidService _ireportService;

        public GetHouseholdcatagoryQueriesHandler(IApplicationDbContext context, IMapper mapper, IReporthhidService ireportService)
        {
            _context = context;
            _mapper = mapper;
            _ireportService = ireportService;
        }

        public async Task<HouseholdcatagoryVM> Handle(GetHouseholdcatagoryQueries request, CancellationToken cancellationToken)
        {
            var entity = new HouseholdcatagoryDto();
            return new HouseholdcatagoryVM
            {
                Lists = await _ireportService.Gethhcatagory(entity)

            };
        }
    }
}