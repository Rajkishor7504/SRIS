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

namespace SRIS.Application.AidFreequencyMasters.Commands.CreateAidFreequencyMasterList
{
   public class CreateAidFreequencyMasterCommand : IRequest<int>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
    public class CreateAidFreequencyMasterCommandHandler : IRequestHandler<CreateAidFreequencyMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAidFreequencyMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAidFreequencyMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new AidFreequency();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_aid_freequency.Where(x => x.name == request.name && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id == 0)
                    {
                        entity.name = request.name;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.id = request.id;
                        bool hasSpecialChars = rgx.IsMatch(entity.name);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_aid_freequency.Add(entity);
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

                            _context.m_master_aid_freequency.Add(entity);
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
