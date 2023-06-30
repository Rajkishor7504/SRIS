using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumeratorProfile.Queries
{
   public class GetEnumeratorQuery : IRequest<EnumeratorProfileVM>
    {
        public string action { get; set; }
    }

    public class GetEnumeratorQueryHandler : IRequestHandler<GetEnumeratorQuery, EnumeratorProfileVM>
    {
        private readonly IEnumeratorProfileService _iEnumeratorProfileService;
        private readonly IMapper _mapper;

        public GetEnumeratorQueryHandler(IEnumeratorProfileService iEnumeratorProfileService, IMapper mapper)
        {
            _iEnumeratorProfileService = iEnumeratorProfileService;
            _mapper = mapper;
        }

        public async Task<EnumeratorProfileVM> Handle(GetEnumeratorQuery request, CancellationToken cancellationToken)
        {
            var entity = new EnumeratorProfileDto();
            entity.action = request.action;
            return new EnumeratorProfileVM
            {
                Lists = await _iEnumeratorProfileService.GetEnumerator(entity)
            };
        }
    }
}
