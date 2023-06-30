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

namespace SRIS.Application.DiseaseMasters.Commands.CreateDiseaseMasterItem
{
    public class CreateDiseaseCommand:IRequest<int>
    {
        public int diseaseid { get; set; }
        public string diseasename { get; set; }
        public string description { get; set; }

    }
    public class CreateDiseaseCommandHandler : IRequestHandler<CreateDiseaseCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateDiseaseCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateDiseaseCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new Disease();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_disease.Where(x => x.diseasename == request.diseasename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.diseaseid == 0)
                    {
                        int id = _context.m_master_disease.ToListAsync().Result.LastOrDefault().diseaseid;
                        entity.diseasename = request.diseasename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        entity.diseaseid = id+1;
                        bool hasSpecialChars = rgx.IsMatch(entity.diseasename);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_disease.Add(entity);

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

                            _context.m_master_disease.Add(entity);

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
