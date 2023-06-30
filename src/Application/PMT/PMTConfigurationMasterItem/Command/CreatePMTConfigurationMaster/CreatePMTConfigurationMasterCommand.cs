using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.PMT.PMTConfigurationMasterItem.Queries.GetPMTConfigurationMaster;
using SRIS.Domain.Entities.PMT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTConfigurationMasterItem.Command.CreatePMTConfigurationMaster
{
    public class CreatePMTConfigurationMasterCommand:IRequest<int>
    {[Key]
        public int pmtconfigureid { get; set; }
        public string formulaname { get; set; }
        public string formulacode { get; set; }
        public string formuladescription { get; set; }
        public int planid { get; set; }
        public int coefficientid { get; set; }
        public decimal formulaconstant { get; set; }
        public decimal constant { get; set; }
        public IList<PMTConfigurationDto> Lists { get; set; }
        // public string coficentname { get; set; }
    }
    public class CreatePMTConfigurationMasterCommandHandler : IRequestHandler<CreatePMTConfigurationMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        public CreatePMTConfigurationMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreatePMTConfigurationMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            Regex rgx = new Regex("[^0-9/. ]");
            var entity = new PMTConfigurationMaster();
            var entity1 = new PMTConfigCoefficient();
            int retval = 0;
            //int count = 0;
            try
            {
                
                if (request.Lists.Count != 0)
                {
                   
                    foreach (var list in request.Lists)
                    {
                        var  count = _context.t_pmt_configuration.Where(x => x.planid == list.planid && x.formulaname == list.formulaname).Count();
                        if (count==0)
                        {
                            entity.formulaname = list.formulaname;
                            entity.formulacode = list.formulacode;
                            entity.formuladescription = list.formuladescription;
                            entity.planid = list.planid;
                            entity.formulaconstant = list.formulaconstant;
                            entity.createdby = 1;
                            entity.createdon = _dateTime.Now;
                            entity.deletedflag = false;
                            entity.pmtconfigureid = request.pmtconfigureid;
                            bool hasNumeric = rgx.IsMatch(entity.formulaconstant.ToString());
                            bool hasSpecialChars = rgx1.IsMatch(entity.formulaname);
                            bool hasSpecialChars1 = rgx1.IsMatch(entity.formulacode);
                            bool hasSpecialChars2 = rgx1.IsMatch(entity.formuladescription);

                            if (hasSpecialChars == false && hasSpecialChars1 == false && hasSpecialChars2 == false)
                            {
                                if (hasNumeric == false)
                                {
                                    _context.t_pmt_configuration.Add(entity);
                                    await _context.SaveChangesAsync(cancellationToken);
                                    retval = 1;
                                }
                                else
                                {
                                    retval = 402;
                                    break;
                                }

                            }
                            else
                            {
                                retval = 403;
                                break;
                            }
                        }
                        
                  }

                    await _context.SaveChangesAsync(cancellationToken);
                    if (retval==1)
                    {
                        foreach (var lst in request.Lists)
                        {
                            entity1.moduleid = lst.moduleid;
                            entity1.parameterid = lst.parameterid;
                            entity1.yesvalue = lst.yesvalue;
                            entity1.novalue = lst.novalue;
                            entity1.coefficient = lst.coefficient;
                            entity1.constant = lst.constant;
                            entity1.createdby = 1;
                            entity1.createdon = _dateTime.Now;
                            entity1.deletedflag = false;
                            entity1.pmtconfigureid = entity.pmtconfigureid;
                            entity1.coefficientid = request.coefficientid;
                            _context.t_pmt_config_coefficient.Add(entity1);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
                        }
                    }
                    else if (retval == 403)
                    {
                        retval = 403;
                    }
                    else if (retval == 402)
                    {
                        retval = 402;
                    }
                    else
                    {
                        retval = 3;
                    }

                    //return retval;
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
