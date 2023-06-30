using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SecondIncomeSourceMaster.Commands.CreateSecondIncomeSourceMasterItem
{
    public class CreateSecondIncomeSourceCommand : IRequest<int>
    {
        public int secondincomesourceid { get; set; }
        public string secondincomesourcename { get; set; }
        public string description { get; set; }
    }
    public class CreateSecondIncomeSourceCommandHandler : IRequestHandler<CreateSecondIncomeSourceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateSecondIncomeSourceCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateSecondIncomeSourceCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new SecondIncomeSourceMasterEntity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_second_incomesource.Where(x => x.secondincomesourcename == request.secondincomesourcename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.secondincomesourceid == 0)
                    {

                        int id = _context.m_master_second_incomesource.ToListAsync().Result.LastOrDefault().secondincomesourceid; 
                        entity.secondincomesourcename = request.secondincomesourcename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.secondincomesourceid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.secondincomesourcename);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_second_incomesource.Add(entity);

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

                            _context.m_master_second_incomesource.Add(entity);

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
