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

namespace SRIS.Application.shocksMasters.Commands.CreateshocksMasterList
{
    public class CreateshocksMasterCommand : IRequest<int>
    {
        public int shockid { get; set; }
        public string shockname { get; set; }
        public string description { get; set; }
    }
    public class CreateshocksMasterCommandHandler : IRequestHandler<CreateshocksMasterCommand, int>
    {
        private readonly IDateTime _dateTime;

        private readonly IApplicationDbContext _context;
        public CreateshocksMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;

        }
        public async Task<int> Handle(CreateshocksMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new Shocks();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_shocks.Where(x => x.shockname == request.shockname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.shockid == 0)
                    {
                        int id = _context.m_master_shocks.ToListAsync().Result.LastOrDefault().shockid;
                        entity.shockname = request.shockname;
                        entity.description = request.description;
                        // entity.createdby = 1;
                        //// entity.updatedby = 1;
                        // entity.deletedflag = false;
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.createdon = _dateTime.Now;
                        entity.shockid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.shockname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_shocks.Add(entity);
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

                            _context.m_master_shocks.Add(entity);
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