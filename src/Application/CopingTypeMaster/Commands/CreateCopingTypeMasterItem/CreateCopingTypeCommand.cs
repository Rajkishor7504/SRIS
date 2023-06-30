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

namespace SRIS.Application.CopingTypeMaster.Commands.CreateCopingTypeMasterItem
{
    public class CreateCopingTypeCommand : IRequest<int>
    {
        public int copingtypeid { get; set; }
        public string copingtypename { get; set; }
        public string description { get; set; }
    }
    public class CreateSchoolTypeCommandHandler : IRequestHandler<CreateCopingTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateSchoolTypeCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateCopingTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new CopingTypeMasterEntity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_copingtype.Where(x => x.copingtypename == request.copingtypename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.copingtypeid == 0)
                    {
                        int id = _context.m_master_copingtype.ToListAsync().Result.LastOrDefault().copingtypeid;
                        entity.copingtypename = request.copingtypename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.copingtypeid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.copingtypename);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_copingtype.Add(entity);

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

                            _context.m_master_copingtype.Add(entity);

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
