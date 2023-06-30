using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using SRIS.Domain.Entities.MasterEntities;
using System.Linq;
using System.Text.RegularExpressions;

namespace SRIS.Application.AidTypeMasters.Commands.CreateAidTypeMasterList
{
    public class CreateAidTypeMasterCommand:IRequest<int>
    {
        public int aidid { get; set; }
        public string aidname { get; set; }
        public string description { get; set; }
    }
    public class CreateAidTypeMasterCommandHandler:IRequestHandler<CreateAidTypeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateAidTypeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAidTypeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new AidType();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_hhr_aid.Where(x => x.aidname == request.aidname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.aidid == 0)
                    {
                        entity.aidname = request.aidname;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.aidid = request.aidid;
                        bool hasSpecialChars = rgx.IsMatch(entity.aidname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_hhr_aid.Add(entity);
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

                            _context.m_hhr_aid.Add(entity);
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
