using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.shocksSeverityMasters.Commands.CreateshocksSeverityMasterList
{
   public class CreateshocksSeverityMasterCommand : IRequest<int>
    {
        public int severityid { get; set; }
        public string severityname { get; set; }
        public string description { get; set; }
    }
    public class CreateshocksSeverityMasterCommandHandler : IRequestHandler<CreateshocksSeverityMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateshocksSeverityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateshocksSeverityMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new shocksSeverityMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_severity.Where(x => x.severityname == request.severityname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.severityid == 0)
                    {
                        entity.severityname = request.severityname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.severityid = request.severityid;
                        bool hasSpecialChars = rgx.IsMatch(entity.severityname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_severity.Add(entity);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 1;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            _context.m_master_severity.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
                        }
                        else
                        {
                            retval = 403;


                        }
                    }
                }
                else
                {
                    retval = 3;
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
