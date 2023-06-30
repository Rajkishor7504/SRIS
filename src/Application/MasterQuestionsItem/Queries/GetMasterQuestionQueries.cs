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

namespace SRIS.Application.MasterQuestionsItem.Queries
{
    public class GetMasterQuestionQueries: IRequest<MasterQuestionVM>
    {
        public int questionnaireid { get; set; }
    }
    public class GetMasterQuestionQueriesHandler : IRequestHandler<GetMasterQuestionQueries, MasterQuestionVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMasterQuestionQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MasterQuestionVM> Handle(GetMasterQuestionQueries request, CancellationToken cancellationToken)
        {
            return new MasterQuestionVM
            {
                Lists = await _context.M_Master_Questionnaire
                    .ProjectTo<MasterQuestionDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.questionnaireid)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}