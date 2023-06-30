using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Feedback.Benificiary.Queries;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Feedback.Benificiary.Commands
{
    public class CreateBenificiaryCommand : IRequest<int>
    {
        public List<BenificiaryDto> Lists { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public string programname { get; set; }
        public string programcode { get; set; }
        public int programid { get; set; }
        public string filename { get; set; }
        public int programdetailsid { get; set; }
        public string remark { get; set; }

    }
    public class CreateBenificiaryCommandHandler : IRequestHandler<CreateBenificiaryCommand, int>
    {
        private readonly IFeedbackService _iFeedbackService;
        private readonly IApplicationDbContext _context;

        public CreateBenificiaryCommandHandler(IFeedbackService iFeedbackService, IApplicationDbContext context)
        {
            _iFeedbackService = iFeedbackService;
            _context = context;
        }

        public async Task<int> Handle(CreateBenificiaryCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            int retval = 0;
            if (request.Lists.Count > 0)
            {
                //int retval = 0;
                //  var entity = new BenificiaryDto();

                //entity.action = request.action;
                //entity.createdby = request.createdby;
                //entity.Lists = request.Lists;
                //entity.programname = request.programname;
                //entity.programcode = request.programcode;
                //entity.programid = request.programid;
                //entity.filename = request.filename;
                //entity.programdetailsid = request.programdetailsid;
                //entity.remark = request.remark;
                //retval = await _iFeedbackService.AddBenificiaryDetails(entity);
                //return retval;
                var createdon = DateTime.Now;
                var entity = new ProgramDetails();
                entity.createdby = request.createdby;
                entity.createdon = createdon;
                entity.programname = request.programname;
                entity.programcode = request.programcode;
                entity.programid = request.programid;
                entity.filename = request.filename;
                var program = _context.t_feedback_programdtls.OrderByDescending(p => p.programdetailsid).FirstOrDefault();
                entity.programdetailsid = program == null ? 0 : program.programdetailsid + 1;
                entity.remark = request.remark;

                //_context.t_feedback_programdtls.Add(entity);
                //await _context.SaveChangesAsync(cancellationToken);

                var entityBeneficiary = new List<BeneficiaryDetail>();
                request.Lists.ForEach(pd => entityBeneficiary.Add(new BeneficiaryDetail()
                {
                    householdno = _context.t_hhr_registerhousehold.FirstOrDefault(a => a.hhcode == pd.householdno).hhcode,
                    programdtlsid = entity.programdetailsid == 0 ? 1 : entity.programdetailsid,
                    benificiaryname = pd.benificiaryname,
                    //householdno = pd.householdno,
                    location = pd.location,
                    idnumber = pd.idnumber,
                    householdhead = pd.householdhead,
                    gender = pd.gender,
                    enrollmentstatus = pd.enrollmentstatus,
                    regdate = pd.regdate,
                    createdby = request.createdby,
                    createdon = createdon,
                    hhid = _context.t_hhr_registerhousehold.FirstOrDefault(a => a.hhcode == pd.householdno).hhid,
                }));
                try
                {
                   bool hasSpecialChars1 = rgx1.IsMatch(entity.remark);
                   if (hasSpecialChars1 == false)
                   {

                        _context.t_feedback_programdtls.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);

                       _context.t_feedback_benificiarydetail.AddRange(entityBeneficiary);
                
                   

                       await _context.SaveChangesAsync(cancellationToken);
                    //return 200;
                        retval = 200;
                    if (retval == 200)
                    {
                        NotificationMasterDto entity1 = new NotificationMasterDto();
                        entity1.NotificationStatus = 0;
                        entity1.Information = "Beneficiary Request Pending At NSPS For Approval";
                        entity1.DestinationURL = "/Feedback/BenificiaryDetails/ViewPendingBenificiary";
                        entity1.CreatedBy = request.createdby;
                        await _iFeedbackService.AddBeneficiaryNotification(entity1);
                    }
                   }
                    else
                    {
                        retval = 403;
                    }
                }
                catch (Exception ex)
                {
                    //return 0;
                    throw ex;
                }
            }
            return retval;
        }

    }
}
