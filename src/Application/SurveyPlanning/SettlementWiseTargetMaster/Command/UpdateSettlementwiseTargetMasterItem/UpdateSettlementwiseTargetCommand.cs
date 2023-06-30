using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Queries.GetSettlementWiseTargetMasterQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Command.UpdateSettlementwiseTargetMasterItem
{
    public class UpdateSettlementwiseTargetCommand : IRequest<int>
    {
        [Key]
        public int stargetid { get; set; }
        public string eano { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int householdtarget { get; set; }
        public List<SettlementWiseTargetDto> Lists { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
    }
    public class UpdateSettlementwiseTargetCommandHandler : IRequestHandler<UpdateSettlementwiseTargetCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly ISettlementwisetargetservice _isettlementwisetarget;
        public UpdateSettlementwiseTargetCommandHandler(IApplicationDbContext context, IDateTime dateTime, ISettlementwisetargetservice isettlementwisetarget)
        {
            _context = context;
            _dateTime = dateTime;
            _isettlementwisetarget = isettlementwisetarget;
        }

        public async Task<int> Handle(UpdateSettlementwiseTargetCommand request, CancellationToken cancellationToken)
        {
            var entity = new SettlementWiseTargetDto();
            // int count = 0;
            int retval = 0;
            //entity.enumdetailid = request.Lists[0].enumdetailid;
            entity.action = request.action;
            entity.createdby = request.createdby;
            entity.Lists = request.Lists;
            retval = await _isettlementwisetarget.Updatesettlementwisetarget(entity);
            return retval;
        }
    }
}
