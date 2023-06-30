using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignEA.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignEA.Commands
{
   public class CreateAssignEACommand : IRequest<int>
    {
        public string action { get; set; }
        public int planid { get; set; }
        public string eanumber { get; set; }
        public int createdby { get; set; }
        public int userid { get; set; }
        public int assigneaid { get; set; }
        public string actiontype { get; set; }
        public List<AssignEADto> Lists { get; set; }
        public int supervisorlocationid { get; set; }
        public int ealocationid { get; set; }

    }
    public class CreateAssignEACommandHandler : IRequestHandler<CreateAssignEACommand, int>
    {
        private readonly IAssignEAService _iAssignEAService;

        public CreateAssignEACommandHandler(IAssignEAService iAssignEAService)
        {
            _iAssignEAService = iAssignEAService;
        }

        public async Task<int> Handle(CreateAssignEACommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = new AssignEADto();

            //if (request.actiontype == "l")
            //{
            //    retval = await _iAssignEAService.AddEaList(request.Lists);
            //}
            //else
            //{
                entity.action = request.action;
                entity.planid = request.planid;
                entity.eanumber = request.eanumber;
                entity.createdby = request.createdby;
                entity.userid = request.userid;
                entity.assigneaid = request.assigneaid;
                entity.supervisorlocationid = request.supervisorlocationid;
                entity.ealocationid = request.ealocationid;
                entity.Lists = request.Lists;
            retval = await _iAssignEAService.AssignEA(entity);
           // }
            return retval;

        }
    }
}
