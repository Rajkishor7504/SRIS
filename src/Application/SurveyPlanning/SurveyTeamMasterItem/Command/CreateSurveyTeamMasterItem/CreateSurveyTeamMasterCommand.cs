using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Command.CreateSurveyTeamMasterItem
{
    public class CreateSurveyTeamMasterCommand : IRequest<int>
    {
        [Key]
        public int teamid { get; set; }
        public int surveyplanid { get; set; }
        public string teamname { get; set; }
        public string description { get; set; }
        public int userid { get; set; }
        public int usettypeid { get; set; }
        public int teamdetailid { get; set; }
        public string action { get; set; }
        public List<SurveyTeamMasterDto> Lists { get; set; }
        public int createdby { get; set; }
    }
    public class CreateSurveyTeamMasterCommandHandler : IRequestHandler<CreateSurveyTeamMasterCommand, int>
    {
       
        private readonly ImyusersurveyteamdetailsService _imyustdService;

      
        public CreateSurveyTeamMasterCommandHandler(ImyusersurveyteamdetailsService imyustdService)
        {
           
            _imyustdService = imyustdService;
        }
        public async Task<int> Handle(CreateSurveyTeamMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = new SurveyTeamMasterDto();
            int retval = 0;
            try
            {
                entity.surveyplanid = request.Lists[0].surveyplanid;
                entity.teamname = request.Lists[0].teamname;
                entity.description = request.Lists[0].description;
                entity.createdby = request.createdby;
                entity.Lists = request.Lists;
                bool hasSpecialChars1 = rgx1.IsMatch(entity.teamname);
                if (hasSpecialChars1 == false)
                {
                    retval = await _imyustdService.CreateTeam(entity);
                }
                else
                {
                    retval = 403;
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}

