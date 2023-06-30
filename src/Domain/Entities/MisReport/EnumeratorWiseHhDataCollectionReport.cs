﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Entities.MisReport
{
   public class EnumeratorWiseHhDataCollectionReport
    {
        public int regionid { get; set; }
        public string region { get; set; }
        public int districtid { get; set; }
        public int parentid { get; set; }
        public string district { get; set; }
        public string action { get; set; }
        public int createdby { get; set; }
        public int p_id { get; set; }
        public int wardid { get; set; }
        public string ward { get; set; }
        public int p_planid { get; set; }
        public int settlementid { get; set; }
        public string settlement { get; set; }
        public bool deletedflag { get; set; }
        public string slno { get; set; }
        public int levelid { get; set; }
        public string levelname { get; set; }

        public int pageno { get; set; }
        public int pagesize { get; set; }
        public int totalrecords { get; set; }

        public int leveldetailid { get; set; }
        public int id { get; set; }

        public int planid { get; set; }
        public string surveyname { get; set; }
        public string userfullname { get; set; }
        public string enumerator { get; set; }
        public int pendingforapproval { get; set; }
        public int approved { get; set; }
        public int approvalrejected { get; set; }
        public int eaid { get; set; }
        public int assigneaid { get; set; }
        public int userid { get; set; }
        public int usettypeid { get; set; }
        public int totalhhsurvey { get; set; }
        public int hhpendingforsurvey { get; set; }
        public int noofsettelment { get; set; }
        public int statusid { get; set; }
    }
}
