/*
* File Name : UpdatePMTResultCommand.cs
* class Name : UpdatePMTResultCommand, UpdatePMTResultCommandHandler
* Created Date : 05 Oct 2021
* Created By : Spandana Ray
* Description : command class to update the PMT result
*/
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTExecution.Command.UpdatePMTResultCommand
{
    public class UpdatePMTResultCommand : IRequest<int>
    {
        public string resultIds { get; set; }
        public int hhstatus { get; set; }
        public string remarks { get; set; }
    }
    public class UpdatePMTResultCommandHandler : IRequestHandler<UpdatePMTResultCommand, int>
    {
        private readonly IApplicationDbContext _context;        

        public UpdatePMTResultCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;            
        }
        public async Task<int> Handle(UpdatePMTResultCommand request, CancellationToken cancellationToken)
        {            
            int retval = 0;
            try
            {
                foreach (var id in request.resultIds.Split(','))
                {
                    _context.t_pmt_pmtresult.Where(x => x.resultid== Convert.ToInt32(id)).ToList().ForEach(c => { c.hhstatus = request.hhstatus; c.remarks = request.remarks; });
                    var hhid = _context.t_pmt_pmtresult.Where(x => x.resultid == Convert.ToInt32(id)).FirstOrDefault().hhid;
                    //------Update PMTStatus for the Household table as 1-Approved, 2-Rejected, Else Pending
                    _context.t_hhr_registerhousehold.Where(x => x.hhid == hhid).FirstOrDefault().pmtstatus = request.hhstatus;
                }
                await _context.SaveChangesAsync(cancellationToken);
                retval = 1;
            }
            catch (System.Exception ex)
            {                
            }
            return retval;
        }
    }
}
