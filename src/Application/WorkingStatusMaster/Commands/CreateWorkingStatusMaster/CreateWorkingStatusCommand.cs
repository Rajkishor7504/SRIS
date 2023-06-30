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

namespace SRIS.Application.WorkingStatusMaster.Commands.CreateWorkingStatusMaster
{
    public class CreateWorkingStatusCommand:IRequest<int>
    {
        public int statusid { get; set; }
        public string statusname { get; set; }
        public string description { get; set; }
    }
    public class CreateWorkingStatusCommandHandler : IRequestHandler<CreateWorkingStatusCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateWorkingStatusCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateWorkingStatusCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new WorkingStatus();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_workingstatus.Where(x => x.statusname == request.statusname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.statusid == 0)
                    {
                        int id = _context.m_master_workingstatus.ToListAsync().Result.LastOrDefault().statusid;
                        entity.statusname = request.statusname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.statusid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.statusname);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_workingstatus.Add(entity);

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

                            _context.m_master_workingstatus.Add(entity);

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
