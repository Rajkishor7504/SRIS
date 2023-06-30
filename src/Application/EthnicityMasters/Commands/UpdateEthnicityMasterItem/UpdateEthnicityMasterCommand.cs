using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.EthnicityMasters.Commands.UpdateEthnicityMasterItem
{
    public class UpdateEthnicityMasterCommand : IRequest<int>
    {
        public int ethnicityid { get; set; }
        public string ethnicityname { get; set; }
        public string description { get; set; }
    }
    public class UpdateEthnicityMasterCommandHandler : IRequestHandler<UpdateEthnicityMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEthnicityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateEthnicityMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_ethnicity.FindAsync(request.ethnicityid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(EthnicityMaster), request.ethnicityname);
                }
                count = _context.m_master_ethnicity.Where(x => x.ethnicityname == request.ethnicityname && x.ethnicityid != request.ethnicityid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.ethnicityid != 0)
                    {
                        entity.ethnicityname = request.ethnicityname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.ethnicityname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 2;
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
