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

namespace SRIS.Application.ConfigureGrievanceMaster.Command.CreateConfigureGrievanceMaster
{
    public class CreateConfigureGrievanceCommand : IRequest<int>
    {
        [Key]
        public int grievanceconfigid { get; set; }
        public string grievancename { get; set; }
        public string description { get; set; }
        public bool isForward { get; set; }
    }
    public class CreateConfigureGrievanceCommandHandler : IRequestHandler<CreateConfigureGrievanceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateConfigureGrievanceCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }
        public async Task<int> Handle(CreateConfigureGrievanceCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = new ConfigureGrievance();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_grievance_configuregrievance.Where(x => x.grievancename == request.grievancename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.grievanceconfigid == 0)
                    {
                        int id = _context.m_grievance_configuregrievance.ToListAsync().Result.LastOrDefault().grievanceconfigid;
                        entity.grievancename = request.grievancename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.isForward = request.isForward;
                        entity.grievanceconfigid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.grievancename);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx1.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_grievance_configuregrievance.Add(entity);

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

                            _context.m_grievance_configuregrievance.Add(entity);

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