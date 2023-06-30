using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Feedback.Payment.Queries
{
   public class GetPaymentQuery : IRequest<PaymentVM>
    {
        public string action { get; set; }
        public int datarequest_id { get; set; }
        public int userid { get; set; }//giving userid for the filter

    }
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaymentVM>
    {
        private readonly IPaymentService _iPaymentService;
        private readonly IMapper _mapper;

        public GetPaymentQueryHandler(IPaymentService iPaymentService, IMapper mapper)
        {
            _iPaymentService = iPaymentService;
            _mapper = mapper;
        }

        public async Task<PaymentVM> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var entity = new PaymentDto();
            entity.action = request.action;
            entity.userid = request.userid;
            return new PaymentVM
            {
                Lists = await _iPaymentService.GetPaymentDetails(entity)
            };
        }
    }

}
