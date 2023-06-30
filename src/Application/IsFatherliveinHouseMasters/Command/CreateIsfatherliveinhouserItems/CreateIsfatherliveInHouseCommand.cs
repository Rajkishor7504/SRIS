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

namespace SRIS.Application.IsFatherliveinHouseMasters.Command.CreateIsfatherliveinhouserItems
{
    public class CreateIsfatherliveInHouseCommand : IRequest<int>
    {
        public int id { get; set; }
        public string isfatherliveinhouse { get; set; }
        public string description { get; set; }
    }
    public class CreateIsfatherliveInHouseCommandHandler : IRequestHandler<CreateIsfatherliveInHouseCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _datetime;

        public CreateIsfatherliveInHouseCommandHandler(IApplicationDbContext context, IDateTime datetime)
        {
            _context = context;
            _datetime = datetime;
        }

        public async Task<int> Handle(CreateIsfatherliveInHouseCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new Isfatherliveinhouse();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_Isfatherliveinhouse.Where(x => x.isfatherliveinhouse == request.isfatherliveinhouse && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id == 0)
                    {
                        // int id = _context.m_master_gender.ToListAsync().Result.LastOrDefault().genderid;
                        entity.isfatherliveinhouse = request.isfatherliveinhouse;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.createdon = _datetime.Now;
                        entity.deletedflag = false;
                        bool hasSpecialChars = rgx.IsMatch(entity.isfatherliveinhouse);
                        if (entity.description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_Isfatherliveinhouse.Add(entity);

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

                            _context.m_master_Isfatherliveinhouse.Add(entity);

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
