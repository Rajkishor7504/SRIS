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

namespace SRIS.Application.ReadWriteAnyLanguageMaster.Commands.CreateReadWriteAnyLangugeMasterItem
{
    public class CreateReadWriteAnyLangugeCommand : IRequest<int>
    {
        public int readwriteid { get; set; }
        public string typeofreadwrite { get; set; }
        public string description { get; set; }
    }
    public class CreateReadWriteAnyLangugeCommandHandler : IRequestHandler<CreateReadWriteAnyLangugeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateReadWriteAnyLangugeCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateReadWriteAnyLangugeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ReadWriteAnyLanguageMasterEntity();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_readwriteanylanguage.Where(x => x.typeofreadwrite == request.typeofreadwrite && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.readwriteid == 0)
                    {
                        int id = _context.m_master_readwriteanylanguage.ToListAsync().Result.LastOrDefault().readwriteid;
                        entity.typeofreadwrite = request.typeofreadwrite;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.readwriteid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.typeofreadwrite);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_readwriteanylanguage.Add(entity);

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

                            _context.m_master_readwriteanylanguage.Add(entity);

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
