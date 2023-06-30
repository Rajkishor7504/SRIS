using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using SRIS.Domain.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace SRIS.Application.ResidenceMasters.Commands.CreateResidenceMasterList
{
    public class CreateResidenceMasterCommand : IRequest<int>
    {
        public int id { get; set; }
        public string residencename { get; set; }
        public string description { get; set; }
    }
    public class CreatResidenceMasterCommandHandler : IRequestHandler<CreateResidenceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatResidenceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateResidenceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ResidenceMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.M_Master_Residence.Where(x => x.residencename == request.residencename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id == 0)
                    {
                        entity.residencename = request.residencename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.id = request.id;
                        bool hasSpecialChars = rgx.IsMatch(entity.residencename);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.M_Master_Residence.Add(entity);
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

                            _context.M_Master_Residence.Add(entity);
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
