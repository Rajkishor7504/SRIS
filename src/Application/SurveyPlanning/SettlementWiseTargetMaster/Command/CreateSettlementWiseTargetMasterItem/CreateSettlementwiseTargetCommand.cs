using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Queries.GetSettlementWiseTargetMasterQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Command.CreateSettlementWiseTargetMasterItem
{
    public class CreateSettlementwiseTargetCommand : IRequest<int>
    {
        [Key]
        public int stargetid { get; set; }
        public string eano { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int householdtarget { get; set; }
        public List<SettlementWiseTargetDto> Lists { get; set; }
        public int createdby { get; set; }
        public string action { get; set; }
    }
    public class CreateSettlementwiseTargetCommandHandler : IRequestHandler<CreateSettlementwiseTargetCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly ISettlementwisetargetservice _isettlementwisetarget;
        public CreateSettlementwiseTargetCommandHandler(IApplicationDbContext context, IDateTime dateTime,ISettlementwisetargetservice isettlementwisetarget)
        {
            _context = context;
            _dateTime = dateTime;
            _isettlementwisetarget = isettlementwisetarget;
        }

        public async Task<int> Handle(CreateSettlementwiseTargetCommand request, CancellationToken cancellationToken)
        {
            var entity = new SettlementWiseTargetDto();
            // int count = 0;
            int retval = 0;
            entity.action = request.action;
            entity.createdby = request.createdby;
            entity.Lists = request.Lists;
            retval = await _isettlementwisetarget.Createsettlementwisetarget(entity);
            return retval;
        }
    }
}
