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

namespace SRIS.Application.liveLiHoodMasters.Commands.CreateliveLiHoodMasterList
{
    public class CreateliveLiHoodMasterCommand : IRequest<int>
    {
        public int livelihoodid { get; set; }
        public string livelihoodname { get; set; }
        public string description { get; set; }
    }
    public class CreateliveLiHoodMasterCommandHandler : IRequestHandler<CreateliveLiHoodMasterCommand, int>
    {
        private readonly IDateTime _dateTime;

        private readonly IApplicationDbContext _context;
        public CreateliveLiHoodMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;

        }
        public async Task<int> Handle(CreateliveLiHoodMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new LiveliHood();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_livelihood.Where(x => x.livelihoodname == request.livelihoodname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.livelihoodid == 0)
                    {
                        int id = _context.m_master_livelihood.ToListAsync().Result.LastOrDefault().livelihoodid;
                        entity.livelihoodname = request.livelihoodname;
                        entity.description = request.description;
                        
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.createdon = _dateTime.Now;
                        entity.livelihoodid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.livelihoodname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_livelihood.Add(entity);
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

                            _context.m_master_livelihood.Add(entity);
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