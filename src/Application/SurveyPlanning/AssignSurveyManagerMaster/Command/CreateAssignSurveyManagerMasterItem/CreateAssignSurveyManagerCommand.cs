using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Query.GetassignSurveyManagerItem;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Command.CreateAssignSurveyManagerMasterItem
{
    public class CreateAssignSurveyManagerCommand:IRequest<int>
    {[Key]
        public int assignmanagerid { get; set; }
        public int surveyplanid { get; set; }
        public int userid { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public List<AssignSurveyManagerDto> Lists { get; set; }

    }
    public class CreateAssignSurveyManagerCommandHandler : IRequestHandler<CreateAssignSurveyManagerCommand,int>
    {
       
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IAssignSurveyManagerService _iAssignSurveymanagerService;
        public CreateAssignSurveyManagerCommandHandler(IApplicationDbContext context, IDateTime dateTime, IAssignSurveyManagerService iAssignSurveymanagerService)
        {
            _context = context;
            _dateTime = dateTime;
            _iAssignSurveymanagerService = iAssignSurveymanagerService;
        }
        public async Task<int> Handle(CreateAssignSurveyManagerCommand request, CancellationToken cancellationToken)
        {
            try
            {
            int retval = 0;
            var entity = new AssignSurveyManagerDto();
            entity.Lists = request.Lists;
            entity.createdby = request.createdby;
            entity.action = request.action;
            retval = await _iAssignSurveymanagerService.Createsurveymanager(entity);
            return retval;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}