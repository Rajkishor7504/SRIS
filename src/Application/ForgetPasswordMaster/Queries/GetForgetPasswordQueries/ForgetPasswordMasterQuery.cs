using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ForgetPasswordMaster.Queries.GetForgetPasswordQueries
{
   public class ForgetPasswordMasterQuery : IRequest<ForgetPasswordMasterVM>
    {
        public string Action { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
    }
    public class ForgetPasswordMasterQueryHandler : IRequestHandler<ForgetPasswordMasterQuery, ForgetPasswordMasterVM>
    {
        private readonly IForgetPasswordMasterService _iForgetPasswordMasterService;
        private readonly IMapper _mapper;

        public ForgetPasswordMasterQueryHandler(IForgetPasswordMasterService iForgetPasswordMasterService, IMapper mapper)
        {
            _iForgetPasswordMasterService = iForgetPasswordMasterService;
            _mapper = mapper;
        }


        public async Task<ForgetPasswordMasterVM> Handle(ForgetPasswordMasterQuery request, CancellationToken cancellationToken)
        {
            ForgetPasswordMasterDto entity = new ForgetPasswordMasterDto();
            entity.Action = request.Action;
            entity.roleid = request.roleid;
            entity.userid = request.userid;
            return new ForgetPasswordMasterVM
            {
                Lists = await _iForgetPasswordMasterService.GetDetails(entity),
            };
        }
    }
}
