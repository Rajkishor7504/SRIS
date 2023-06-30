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

namespace SRIS.Application.SecondIncomeSourceMaster.Commands.UpdateSecondIncomeSourceMasterItem
{
    public class UpdateSecondIncomeSourceCommand : IRequest<int>
    {
        public int secondincomesourceid { get; set; }
        public string secondincomesourcename { get; set; }
        public string description { get; set; }
    }
    public class UpdateSecondIncomeSourceCommandHandler : IRequestHandler<UpdateSecondIncomeSourceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateSecondIncomeSourceCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateSecondIncomeSourceCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_second_incomesource.FindAsync(request.secondincomesourceid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(SecondIncomeSourceMasterEntity), request.secondincomesourcename);
                }
                count = _context.m_master_second_incomesource.Where(x => x.secondincomesourcename == request.secondincomesourcename && x.secondincomesourceid != request.secondincomesourceid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.secondincomesourceid != 0)
                    {
                        entity.secondincomesourcename = request.secondincomesourcename;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;
                        bool hasSpecialChars = rgx.IsMatch(entity.secondincomesourcename);
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
