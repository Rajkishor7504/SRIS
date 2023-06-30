using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.IncomeSourceMasters.Commands.UpdateIncomeSourceMasterItem
{
    public class UpdateIncomeSourceMasterCommand : IRequest<int>
    {
        public int incomesourceid { get; set; }
        public string incomesourcename { get; set; }
        public string description { get; set; }
    }
    public class UpdateIncomeSourceMasterCommandHandler : IRequestHandler<UpdateIncomeSourceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateIncomeSourceMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _context = context;
        }
        public async Task<int> Handle(UpdateIncomeSourceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_incomesource.FindAsync(request.incomesourceid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(MainIncomeSource), request.incomesourcename);
                }
                count = _context.m_master_incomesource.Where(x => x.incomesourcename == request.incomesourcename && x.incomesourceid != request.incomesourceid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.incomesourceid != 0)
                    {
                        entity.updatedon = _dateTime.Now;
                        entity.updatedby = 1;
                        entity.incomesourcename = request.incomesourcename;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.incomesourcename);
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
