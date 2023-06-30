using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.RegisterHouseholdSurvey.Queries.GetRegisterHouseholdSurvey
{
    public class GetRegisterHouseholdSurveyQueries: IRequest<RegisterHouseholdSurveyVM>
    {
        public int hhid { get; set; }
    }
    public class GetRegisterHouseholdSurveyQueriesHandler : IRequestHandler<GetRegisterHouseholdSurveyQueries, RegisterHouseholdSurveyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRegisterHouseholdSurveyQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RegisterHouseholdSurveyVM> Handle(GetRegisterHouseholdSurveyQueries request, CancellationToken cancellationToken)
        {
            RegisterHouseholdSurveyVM model = new RegisterHouseholdSurveyVM();
            model.Lists = await _context.t_hhr_registerhousehold
                    .ProjectTo<RegisterHouseholdSurveyDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.hhid)
                    .Where(x=>x.deletedflag== false && x.allapprovedstatus == 1
                    && x.allverifiedstatus == 1 && x.spotcheckerstatus == 0 
                    && x.hhinterviewresult == 1 && x.isagreeforinterview == 1)
                    .ToListAsync(cancellationToken);

            return model;
        }

    }
}