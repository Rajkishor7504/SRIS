using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PMT.PMTParameterMasterItem.Queries.GetPMTParameterMasterItem;
using SRIS.Domain.Entities.PMT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTParameterMasterItem.Commands.CreatePMTParameterMasterItem
{
   public class Createpmtparametermastercommand:IRequest<int>
    {
        [Key]
        public int parameterid { get; set; }
        public int planid { get; set; }
        public int moduleid { get; set; }
        public int pmtmasterid { get; set; }
        public int yesvalue { get; set; }
        public int novalue { get; set; }
        public int questionnaireid { get; set; }
        public IList<PMTParameterDto> Lists { get; set; }
    }
    public class CreatepmtparametermastercommandHandler : IRequestHandler<Createpmtparametermastercommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        public CreatepmtparametermastercommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }
        public async Task<int> Handle(Createpmtparametermastercommand request, CancellationToken cancellationToken)
        {
            var entity = new PMTParameterMaster();
            int count = 0;
            int retval = 0;
            try
            {
                 if (request.Lists.Count != 0)
                 {
                    foreach (var lst in request.Lists)
                    {
                        count = _context.t_pmt_pmtparameter.Where(x => x.planid == lst.planid && x.moduleid == lst.moduleid && x.questionnaireid == lst.questionnaireid && x.pmtmasterid == lst.pmtmasterid).Count();
                        if (count == 0)
                        {
                            entity.planid = lst.planid;
                            entity.moduleid = lst.moduleid;
                            entity.questionnaireid = lst.questionnaireid;
                            entity.pmtmasterid = lst.pmtmasterid;
                            entity.yesvalue = lst.yesvalue;
                            entity.novalue = lst.novalue;
                            entity.createdby = 1;
                            entity.createdon = _dateTime.Now;
                            entity.deletedflag = false;
                            entity.parameterid = request.parameterid;
                            _context.t_pmt_pmtparameter.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
                        }
                        
                         else
                        {
                            retval = 3;
                        }
                    }
                    //return retval;
                }
               

                }
                catch (System.Exception ex)
            {
                throw ex;
            }

            return retval;
        }

     


    }

}