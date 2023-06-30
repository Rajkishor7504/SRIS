using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Report.DataSharingReport
{
    public class DataSharingReportVM
    {
        public IList<DataSharingReportDto> Lists { get; set; }
        public int totalorganisationname { get; set; }
        public int totalnoofprogrammcode { get; set; }
        public int totalnoofdatarequest { get; set; }
        public int totalnoofpending { get; set; }
        public int totalnoofapproved { get; set; }
        public int totalnoofrejected { get; set; }
        public string action { get; set; }
        public string fid { get; set; }
        public string tid { get; set; }
        public int catagory { get; set; }
        public string organisationname { get; set; }
        public int organisationid { get; set; }
        public int organisationcategoryid { get; set; }
        public int orgname { get; set; }
        public string Program_Name { get; set; }
        public string pdate { get; set; }
        public string Program_Code { get; set; }
        public string filetype { get; set; }
        public int userid { get; set; }
        public int totalnoofprocessed { get; set; }
        public string downloaddate { get; set; }


    }
}
