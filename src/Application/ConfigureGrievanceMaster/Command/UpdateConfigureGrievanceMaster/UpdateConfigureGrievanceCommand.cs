using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ConfigureGrievanceMaster.Command.UpdateConfigureGrievanceMaster
{
    public class UpdateConfigureGrievanceCommand:IRequest<int>
    {
        public int grievanceconfigid { get; set; }
        public string grievancename { get; set; }
        public string description { get; set; }
        public bool isForward { get; set; }
    }
    public class UpdateConfigureGrievanceCommandHandler : IRequestHandler<UpdateConfigureGrievanceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateConfigureGrievanceCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateConfigureGrievanceCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            var entity = await _context.m_grievance_configuregrievance.FindAsync(request.grievanceconfigid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ConfigureGrievance), request.grievancename);
                }
                count = _context.m_grievance_configuregrievance.Where(x => x.grievancename == request.grievancename && x.grievanceconfigid != request.grievanceconfigid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.grievanceconfigid != 0)
                    {
                        entity.grievancename = request.grievancename;
                        entity.description = request.description;
                        entity.isForward = request.isForward;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;
                        bool hasSpecialChars = rgx.IsMatch(entity.grievancename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx1.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 2;
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