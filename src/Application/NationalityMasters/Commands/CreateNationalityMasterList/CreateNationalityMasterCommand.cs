using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.NationalityMasters.Commands.CreateNationalityMasterList
{
    public class CreateNationalityMasterCommand : IRequest<int>
    {
        public int nationalityid { get; set; }
        public string nationality { get; set; }
        public string description { get; set; }

    }
    public class CreateNationalityMasterCommandHandler : IRequestHandler<CreateNationalityMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateNationalityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateNationalityMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new NationalityMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_nationalitytbl.Where(x => x.nationality == request.nationality && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.nationalityid == 0)
                    {
                        entity.nationality = request.nationality;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.nationalityid= request.nationalityid;
                        bool hasSpecialChars = rgx.IsMatch(entity.nationality);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_nationalitytbl.Add(entity);
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

                            _context.m_master_nationalitytbl.Add(entity);
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
