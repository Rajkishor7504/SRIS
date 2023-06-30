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

namespace SRIS.Application.IncomeSourceMasters.Commands.CreateIncomeSourceMasterList
{
    public class CreateIncomeSourceMasterCommand : IRequest<int>
    {
        public int incomesourceid { get; set; }
        public string incomesourcename { get; set; }
        public string description { get; set; }
    }
    public class CreateIncomeSourceMasterCommandHandler : IRequestHandler<CreateIncomeSourceMasterCommand, int>
    {
        private readonly IDateTime _dateTime;

        private readonly IApplicationDbContext _context;
        public CreateIncomeSourceMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;

        }
        public async Task<int> Handle(CreateIncomeSourceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new MainIncomeSource();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_incomesource.Where(x => x.incomesourcename == request.incomesourcename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.incomesourceid == 0)
                    {
                        int id = _context.m_master_incomesource.ToListAsync().Result.LastOrDefault().incomesourceid;
                        entity.incomesourcename = request.incomesourcename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.createdon = _dateTime.Now;
                        entity.incomesourceid =id+1;
                        bool hasSpecialChars = rgx.IsMatch(entity.incomesourcename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_incomesource.Add(entity);
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

                            _context.m_master_incomesource.Add(entity);
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