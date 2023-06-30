using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Household.DemographicMember.Queries.GetDemographicMember;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.DemographicMember.Commands
{
    public class CreateDemographicMemberCommand:IRequest<DemographicMemberList>
    {
        public string action { get; set; }
        public int hhid { get; set; }
        public int memberid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int sex { get; set; }
        public int relationshiptohhid { get; set; }
        public string uploadphotopath { get; set; }

        public string uploadphotoname { get; set; }
        public int residencestatusid { get; set; }
        public int dohavebirthcertificate { get; set; }

        public string dateofarrival { get; set; }
        public string uploadbirthcertificate { get; set; }
        public string dateofbirth { get; set; }
        public int ethnicityid { get; set; }
        public string otherethnicgroup { get; set; }
        public int age { get; set; }
        public int maritalstatusid { get; set; }
        public int placeofbirthid { get; set; }
        public int isfatherstillalive { get; set; }
        public int nationalityid { get; set; }

        public string othernationality { get; set; }
        public string identificationdocids { get; set; }
        public int fatherliveinhousehold { get; set; }
        public string recrdlineoffather { get; set; }//Add by Rajkishor Patra(04-Nov-2022)
        public string identificationno { get; set; }
        public int ismotherstillalive { get; set; }

        public string uploadidproof { get; set; }

        public int motherliveinhousehold { get; set; }
        public string recrdlineofmother { get; set; }//Add by Rajkishor Patra(04-Nov-2022)
        public string createdby { get; set; }
    }
    public class CreateDemographicMemberCommandHandler : IRequestHandler<CreateDemographicMemberCommand, DemographicMemberList>
    {
       

        private readonly IHouseholdService _iHouseholdService;

        public CreateDemographicMemberCommandHandler(IHouseholdService iHouseholdService)
        {
            _iHouseholdService = iHouseholdService;
        }

        public async Task<DemographicMemberList> Handle(CreateDemographicMemberCommand request, CancellationToken cancellationToken)
        {
           
            int retval = 0;
            DemographicMemberList objDemoList = new DemographicMemberList();
            try
            {
                if ((request.memberid == 0 && request.action == "U") || string.IsNullOrEmpty(request.firstname) || string.IsNullOrEmpty(request.lastname))
                {
                    objDemoList.status = "401";
                    objDemoList.message = CommonHelper.GetEnumDescription((ResponseStatus)401);
                }
                else
                {
                    var entity = new DemographicMemberDto();
                    entity.action = request.action;
                    entity.hhid = request.hhid;
                    entity.memberid = request.memberid;
                    entity.firstname = request.firstname;
                    entity.lastname = request.lastname;
                    entity.sex = request.sex;
                    entity.relationshiptohhid = request.relationshiptohhid;
                    entity.uploadphotopath = request.uploadphotopath;
                    entity.uploadphotoname = request.uploadphotoname;
                    entity.residencestatusid = request.residencestatusid;
                    entity.dohavebirthcertificate = request.dohavebirthcertificate;
                    entity.dateofarrival = Convert.ToDateTime(request.dateofarrival).ToString("yyyy-MM-dd");
                    entity.uploadbirthcertificate = request.uploadbirthcertificate;
                    entity.dateofbirth = Convert.ToDateTime(request.dateofbirth).ToString("yyyy-MM-dd");
                    entity.ethnicityid = request.ethnicityid;
                    entity.age = request.age;
                    entity.maritalstatusid = request.maritalstatusid;
                    entity.placeofbirthid = request.placeofbirthid;
                    entity.isfatherstillalive = request.isfatherstillalive;
                    entity.nationalityid = request.nationalityid;
                    entity.identificationdocids = request.identificationdocids;
                    entity.fatherliveinhousehold = request.fatherliveinhousehold;
                    entity.recrdlineoffather = Convert.ToString(request.recrdlineoffather);//Add by Rajkishor Patra(04-Nov-2022)
                    entity.identificationno = request.identificationno;
                    entity.ismotherstillalive = request.ismotherstillalive;
                    entity.uploadidproof = request.uploadidproof;
                    entity.motherliveinhousehold = request.motherliveinhousehold;
                    entity.recrdlineofmother = Convert.ToString(request.recrdlineofmother);//Add by Rajkishor Patra(04-Nov-2022)
                    entity.createdby = request.createdby;
                    retval = await _iHouseholdService.AddDemographicMember(entity);
                    objDemoList.status = retval.ToString();
                    objDemoList.message = CommonHelper.GetEnumDescription((ResponseStatus)retval);
                }
            }
            catch (Exception ex)
            {
                objDemoList.status = "500";
                objDemoList.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                objDemoList.errorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return objDemoList;

        }
    }

}
