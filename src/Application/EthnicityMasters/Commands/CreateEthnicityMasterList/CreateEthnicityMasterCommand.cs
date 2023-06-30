using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.EthnicityMasters.Commands.CreateEthnicityMasterList
{
    public class CreateEthnicityMasterCommand : IRequest<int>
    {
        public int ethnicityid { get; set; }
        public string ethnicityname { get; set; }
        public string description { get; set; }
    }
    public class CreateEthnicityMasterCommandHandler : IRequestHandler<CreateEthnicityMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateEthnicityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateEthnicityMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new EthnicityMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_ethnicity.Where(x => x.ethnicityname == request.ethnicityname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.ethnicityid == 0)
                    {
                        entity.ethnicityname = request.ethnicityname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.ethnicityid = request.ethnicityid;
                        bool hasSpecialChars = rgx.IsMatch(entity.ethnicityname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_ethnicity.Add(entity);
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

                            _context.m_master_ethnicity.Add(entity);
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
