using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Feedback.UpdateBenificiaryExit.Queries;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Feedback.UpdateBenificiaryExit.Command
{
    public class CreateExitBenificiaryCommand : IRequest<ExitBenificiaryVM>
    {
        public string programmecode { get; set; }
        public string benificiarynumber { get; set; }
        public string exittype { get; set; }
        public string exiteddate { get; set; }
       

    }

    public class CreateExitBenificiaryMemberCommandHandler : IRequestHandler<CreateExitBenificiaryCommand, ExitBenificiaryVM>
    {
        private readonly IDatasharingService _idatasharingService;


        public CreateExitBenificiaryMemberCommandHandler(IApplicationDbContext context, IDatasharingService idatasharingService)
        {
            _idatasharingService = idatasharingService;
        }

        public async Task<ExitBenificiaryVM> Handle(CreateExitBenificiaryCommand request, CancellationToken cancellationToken)
        {
            var entity = new ExitBenificiaryDto();
           
            ExitBenificiaryVM ob = new ExitBenificiaryVM();
            try
            {

                if (request.programmecode != null || request.programmecode != "" || request.benificiarynumber!=null || request.benificiarynumber != "" && request.exittype!=null || request.exittype != "" && request.exiteddate!=null || request.exiteddate != "")
                {
                    entity.programmecode = request.programmecode;
                    entity.benificiarynumber = request.benificiarynumber;
                    entity.exittype = request.exittype;
                    entity.exiteddate = Convert.ToDateTime(request.exiteddate);
                   await _idatasharingService.addexitbenificiarymember(entity);
                }
                else
                {
                    ob.status = "501";
                    ob.message = CommonHelper.GetEnumDescription((ResponseStatus)501);
                    ob.errorMessage = "";
                }


                ob.status = "200";
                ob.message = CommonHelper.GetEnumDescription((ResponseStatus)200);
                ob.errorMessage = "";

            }
            catch (System.Exception ex)
            {
                ob.status = "500";
                ob.message = ex.Message;
                ob.errorMessage = ex.Message;
            }

            return ob;
        }

    }
    
}
