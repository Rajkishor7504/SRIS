using MediatR;
using SRIS.Application.Common.Exceptions;
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

namespace SRIS.Application.PMT.PMTConfigurationMasterItem.Command.UpdatePMTConfigurationCoefficientMaster
{
    public class UpdatePMTConfigurationCoefficientCommand: IRequest<int>
    {
        [Key]
        public int pmtconfigureid { get; set; }
        public string formulaname { get; set; }
        public string formulacode { get; set; }
        public string formuladescription { get; set; }
        public decimal formulaconstant { get; set; }
        public int planid { get; set; }
        public decimal coefficient { get; set; }
        public decimal constant { get; set; }
        public IList<PMTConfigurationDto> Lists { get; set; }
        // public string coficentname { get; set; }
    }
    public class UpdatePMTConfigurationCoefficientCommandHandler : IRequestHandler<UpdatePMTConfigurationCoefficientCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        public UpdatePMTConfigurationCoefficientCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdatePMTConfigurationCoefficientCommand request, CancellationToken cancellationToken)
        {
            Regex rgx1 = new Regex("[^A-Za-z0-9 ]");
            Regex rgx = new Regex("[^0-9/. ]");
            //var entity = await _context.t_pmt_configuration.FindAsync(request.pmtconfigureid);
            //var entity1 = await _context.t_pmt_config_coefficient.FindAsync(request.pmtconfigureid);
            int count = 0;
            int retval = 0;
            try
            {
                if (request.Lists == null)
                {
                    throw new NotFoundException(nameof(PMTConfigurationMaster), request.formulaname);
                }
                foreach (var list in request.Lists) {
                    count = _context.t_pmt_configuration.Where(x => x.planid == list.planid && x.pmtconfigureid != list.pmtconfigureid && x.formulaname == list.formulaname).Count();

                    if (count == 0)
                    {
                        var entity = await _context.t_pmt_configuration.FindAsync(list.pmtconfigureid);
                        entity.formulaname = list.formulaname;
                        entity.formulacode = list.formulacode;
                        entity.formuladescription = list.formuladescription;
                        entity.planid = list.planid;
                        entity.formulaconstant = list.formulaconstant;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.pmtconfigureid = list.pmtconfigureid;
                        bool hasNumeric = rgx.IsMatch(entity.formulaconstant.ToString());
                        bool hasSpecialChars = rgx1.IsMatch(entity.formulaname);
                        bool hasSpecialChars1 = rgx1.IsMatch(entity.formulacode);
                        bool hasSpecialChars2 = rgx1.IsMatch(entity.formuladescription);
                        if (hasSpecialChars == false && hasSpecialChars1 == false && hasSpecialChars2 == false)
                        {
                            if (hasNumeric == false)
                            {
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
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
                if (retval == 2) { 
                    foreach (var lst in request.Lists)
                    { 
                        var entity1 = await _context.t_pmt_config_coefficient.FindAsync(lst.coefficientid);
                        entity1.moduleid = lst.moduleid;
                        entity1.parameterid = lst.parameterid;
                        entity1.yesvalue = lst.yesvalue;
                        entity1.novalue = lst.novalue;
                        entity1.coefficient = lst.coefficient;
                        entity1.constant = lst.constant;
                        entity1.updatedby = 1;
                        entity1.updatedon = _dateTime.Now;
                        entity1.deletedflag = false;
                        entity1.pmtconfigureid = lst.pmtconfigureid;
                        entity1.coefficientid = lst.coefficientid;
                         await _context.SaveChangesAsync(cancellationToken);
                        retval = 2;
                    }
                    
                   retval = 2;


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


            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }
    }
}