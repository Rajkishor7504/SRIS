using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PMT.PMTExecution.Queries.GetParameterItem;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTExecution.Command.CreatePMTExecutionCommand
{
    public class CreatePMTExecutionCommand : IRequest<int>
    {
        //public int hhid { get; set; }
        public int pmtconfigureid { get; set; }
        //public string hhids { get; set; }
        public int locationid { get; set; }
        //public int surveyId { get; set; }
    }
    public class CreatePMTExecutionCommandHandler : IRequestHandler<CreatePMTExecutionCommand, int>
    {
        
        private readonly IPMTService _iPMTService;
        private readonly IApplicationDbContext _context;

        public CreatePMTExecutionCommandHandler(IApplicationDbContext context, IPMTService iPMTService)
        {
            _context = context;
            _iPMTService = iPMTService;
        }

        #region "To execute PMT"
        ///<summary>
        /// Created By Spandana Ray on 22/09/2021
        /// </summary>
        /// <parameter>Request Object of CreatePMTExecutionCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To execute PMT</remarks>
        public async Task<int> Handle(CreatePMTExecutionCommand request, CancellationToken cancellationToken)
        {
            var entity = new ParameterDto();
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                //entity.hhid = request.hhid;
                //entity.hhids = request.hhids;
                entity.pmtconfigureid = request.pmtconfigureid;
                entity.locationid = request.locationid;
                //entity.surveyId = request.surveyId;
                return await _iPMTService.PMTExecution(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
