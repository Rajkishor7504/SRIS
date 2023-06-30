using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.WorkingSectors.Commands.CreateWorkingSectorMaster
{
    public class CreateWorkingSectorCommand:IRequest<int>
    {
        [Key]
        public int sectorid { get; set; }
        public string sectorname { get; set; }
        public string description { get; set; }
    }
    public class CreateWorkingSectorCommandHandler : IRequestHandler<CreateWorkingSectorCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateWorkingSectorCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateWorkingSectorCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new WorkingSector();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_workingsector.Where(x => x.sectorname == request.sectorname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.sectorid == 0)
                    {
                        int id = _context.m_master_workingsector.ToListAsync().Result.LastOrDefault().sectorid;
                        entity.sectorname = request.sectorname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.sectorid =id+1;
                        bool hasSpecialChars = rgx.IsMatch(entity.sectorname);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_workingsector.Add(entity);

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

                            _context.m_master_workingsector.Add(entity);

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
