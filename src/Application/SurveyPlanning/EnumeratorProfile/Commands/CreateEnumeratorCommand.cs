using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.EnumeratorProfile.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.EnumeratorProfile.Commands
{
   public class CreateEnumeratorCommand : IRequest<int>
    {
        public string action { get; set; }
        public int createdby { get; set; }
        public List<EnumeratorProfileDto> Lists { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string userfullname { get; set; }
        public string email { get; set; }
        public string usermobile { get; set; }
        public int userroleid { get; set; }
        public string Secretkey { get; set; }
        public DateTime enumeratorstartdate { get; set; }
        public DateTime enumeratorenddate { get; set; }
        public int? gender { get; set; }
        public int? assignedstatus { get; set; }
        public int spotchecker { get; set; }
        public int usertype { get; set; }
    }
    public class CreateEnumeratorCommandHandler : IRequestHandler<CreateEnumeratorCommand, int>
    {
        private readonly IEnumeratorProfileService _iEnumeratorProfileService;

        public CreateEnumeratorCommandHandler(IEnumeratorProfileService iEnumeratorProfileService)
        {
            _iEnumeratorProfileService = iEnumeratorProfileService;
        }

        public async Task<int> Handle(CreateEnumeratorCommand request, CancellationToken cancellationToken)
        {
            var entity = new EnumeratorProfileDto();
            int retval = 0;
            try
            {
                Regex rgx = new Regex("[^a-zA-Z ]");
                Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
                entity.action = request.action;
                entity.createdby = request.createdby;
                entity.Lists = request.Lists;
                entity.id = request.id;
                entity.username = request.username;
                entity.password = request.password;
                entity.userfullname = request.userfullname;
                entity.email = request.email;
                entity.usermobile = request.usermobile;
                entity.userroleid = request.userroleid;
                entity.Secretkey = request.Secretkey;
                entity.enumeratorstartdate = request.enumeratorstartdate;
                entity.enumeratorenddate = request.enumeratorenddate;
                entity.gender = request.gender;
                entity.assignedstatus = request.assignedstatus;
                entity.spotchecker = request.spotchecker;
                entity.usertype = request.usertype;
                if (entity.userfullname != null && entity.username != null && entity.Lists.Count == 0)
                {
                    bool hasSpecialChars = rgx.IsMatch(entity.userfullname);
                    bool hasSpecialChars1 = rgx1.IsMatch(entity.username);
                    if (hasSpecialChars == false && hasSpecialChars1 == false)
                    {
                        retval = await _iEnumeratorProfileService.AddEnumerator(entity);
                    }
                    else
                    {
                        retval = 403;
                    }
                }
                else
                {
                    retval = await _iEnumeratorProfileService.AddEnumerator(entity);
                    
                }
                return retval;
            }

            catch (Exception ex)
            {
                throw ex;
            }

           

        }
    }
}
