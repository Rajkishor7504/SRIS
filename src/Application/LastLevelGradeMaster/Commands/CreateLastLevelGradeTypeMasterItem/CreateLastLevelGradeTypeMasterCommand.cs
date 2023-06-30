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

namespace SRIS.Application.LastLevelGradeMaster.Commands.CreateLastLevelGradeTypeMasterItem
{
    public class CreateLastLevelGradeTypeMasterCommand : IRequest<int>
    {
        public int lastlevelid { get; set; }
        public string lastlevelname { get; set; }
    }
    public class CreateLastLevelGradeTypeMasterCommandHandler : IRequestHandler<CreateLastLevelGradeTypeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateLastLevelGradeTypeMasterCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateLastLevelGradeTypeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new LastLevelGradeMasterEntity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_lastlevelgrade.Where(x => x.lastlevelname == request.lastlevelname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.lastlevelid == 0)
                    {
                        int id = _context.m_master_lastlevelgrade.ToListAsync().Result.LastOrDefault().lastlevelid;
                        entity.lastlevelname = request.lastlevelname;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.lastlevelid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.lastlevelname);
                        if (hasSpecialChars == false)
                        {
                            _context.m_master_lastlevelgrade.Add(entity);
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
