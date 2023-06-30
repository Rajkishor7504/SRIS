using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignSurvey.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignSurvey.Commands 
{
  public class CreateAssignSurveyCommand : IRequest<int>
    {
        public int assignsupid { get; set; }
        public int assignmentid { get; set; }
        public int userid { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
        public int assignenumid { get; set; }
        public List<AssignSurveyDto> Lists { get; set; }
        public string actiontype { get; set; }
        public int assigndeviceid { get; set; }
        public int deviceid { get; set; }
    }
    public class CreateAssignSurveyCommandHandler : IRequestHandler<CreateAssignSurveyCommand, int>
    {
        private readonly IAssignSurveyService _iAssignSurveyService;

        public CreateAssignSurveyCommandHandler(IAssignSurveyService iAssignSurveyService)
        {
            _iAssignSurveyService = iAssignSurveyService;
        }

        public async Task<int> Handle(CreateAssignSurveyCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = new AssignSurveyDto();

           
            //if (request.actiontype == "l")
            //{
            //    retval = await _iAssignSurveyService.AddAssignSurveyList(request.Lists);
            //}
            //else
            //{
                entity.action = request.action;
                entity.assignsupid = request.assignsupid;
                entity.assignenumid = request.assignenumid;
                entity.userid = request.userid;
                entity.createdby = request.createdby;
                entity.assigndeviceid = request.assigndeviceid;
                entity.deviceid = request.deviceid;
                entity.Lists = request.Lists;
                retval = await _iAssignSurveyService.AddAssignSurvey(entity);
           // }
            return retval;

        }
    }
}
