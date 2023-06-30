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

namespace SRIS.Application.ResortLivelihoodCopingMaster.Commands.CreateResortLivelihoodCopingMasterItem
{
    public class CreateResortLivelihoodCopingCommand : IRequest<int>
    {
        public int resortlivelyhoodcopingid { get; set; }
        public string resortlivelyhoodcoping { get; set; }
        public string description { get; set; }
    }
    public class CreateResortLivelihoodCopingCommandHandler : IRequestHandler<CreateResortLivelihoodCopingCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateResortLivelihoodCopingCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateResortLivelihoodCopingCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ResortLivelihoodCopingMasterEnity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_resortLivelhoodCoping.Where(x => x.resortlivelyhoodcoping == request.resortlivelyhoodcoping && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.resortlivelyhoodcopingid == 0)
                    {
                        int id = _context.m_master_resortLivelhoodCoping.ToListAsync().Result.LastOrDefault().resortlivelyhoodcopingid;
                        entity.resortlivelyhoodcoping = request.resortlivelyhoodcoping;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.resortlivelyhoodcopingid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.resortlivelyhoodcoping);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_resortLivelhoodCoping.Add(entity);

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

                            _context.m_master_resortLivelhoodCoping.Add(entity);

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
