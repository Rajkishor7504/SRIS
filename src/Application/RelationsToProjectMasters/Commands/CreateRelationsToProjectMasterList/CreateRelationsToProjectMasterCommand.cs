using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.RelationsToProjectMasters.Commands.CreateRelationsToProjectMasterList
{
    public class CreateRelationsToProjectMasterCommand : IRequest<int>
    {
        public int relationid { get; set; }
        public string relationname { get; set; }
        public string description { get; set; }
    }
    public class CreateshocksSeverityMasterCommandHandler : IRequestHandler<CreateRelationsToProjectMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateshocksSeverityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateRelationsToProjectMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new RelationsToProjectMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_relationofproject.Where(x => x.relationname == request.relationname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.relationid == 0)
                    {
                        entity.relationname = request.relationname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.relationid = request.relationid;
                        bool hasSpecialChars = rgx.IsMatch(entity.relationname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_relationofproject.Add(entity);
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

                            _context.m_master_relationofproject.Add(entity);
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
