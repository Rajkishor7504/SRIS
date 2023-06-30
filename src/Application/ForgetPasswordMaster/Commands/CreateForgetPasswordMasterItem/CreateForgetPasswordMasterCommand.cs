using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.ForgetPasswordMaster.Queries.GetForgetPasswordQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ForgetPasswordMaster.Commands.CreateForgetPasswordMasterItem
{
   public class CreateForgetPasswordMasterCommand : IRequest<int>
    {
        public string Action { get; set; }
        public int userid { get; set; }
        public string newpassword { get; set; }
        public int createdby { get; set; }
        public string secretkey { get; set; }
    }
    public class CreateForgetPasswordMasterCommandHandler : IRequestHandler<CreateForgetPasswordMasterCommand, int>
    {
        private readonly IForgetPasswordMasterService _iForgetPasswordMasterService;

        public CreateForgetPasswordMasterCommandHandler(IForgetPasswordMasterService iForgetPasswordMasterService)
        {
            _iForgetPasswordMasterService = iForgetPasswordMasterService;
        }

        public async Task<int> Handle(CreateForgetPasswordMasterCommand request, CancellationToken cancellationToken)
        {
                int retval = 0;
                try
                {
                    var entity = new ForgetPasswordMasterDto();

                    entity.Action = request.Action;
                    entity.userid = request.userid;
                    entity.newpassword = request.newpassword;
                    entity.secretkey = request.secretkey;
                    entity.createdby = request.createdby;

                    retval = await _iForgetPasswordMasterService.AddForgetMaster(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            return retval;
        }
    }
}
