using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Feedback.Benificiary.Queries
{
   public class GetBenificiaryQuery : IRequest<BenificiaryVM>
    {
        public string action { get; set; }
        public int datarequest_id { get; set; }
        public int userid { get; set; }//giving userid for the filter

    }
    public class GetBenificiaryQueryHandler : IRequestHandler<GetBenificiaryQuery, BenificiaryVM>
    {
        private readonly IFeedbackService _iFeedbackService;
        private readonly IMapper _mapper;

        public GetBenificiaryQueryHandler(IFeedbackService iFeedbackService, IMapper mapper)
        {
            _iFeedbackService = iFeedbackService;
            _mapper = mapper;
        }

        public async Task<BenificiaryVM> Handle(GetBenificiaryQuery request, CancellationToken cancellationToken)
        {
            var entity = new BenificiaryDto();
            entity.action = request.action;
            entity.datarequest_id = request.datarequest_id;
            entity.userid = request.userid;
            return new BenificiaryVM
            {
                Lists = await _iFeedbackService.GetBenificiary(entity)
            };
        }
    }
}
