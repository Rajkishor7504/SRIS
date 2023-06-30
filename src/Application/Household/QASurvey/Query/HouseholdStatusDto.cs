using SRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.Household.QASurvey.Query
{
    public class HouseholdStatusVM : CommonMobileApiStatus
    {
        public IList<HouseholdStatusDto> Lists { get; set; }

    }

        public class HouseholdStatusDto
    {
        public int hhid { get; set; }
        public int registerverify { get; set; }
        public int demoverify { get; set; }
        public int educationverify { get; set; }
        public int healthverify { get; set; }
        public int empverify { get; set; }
        public int housingverify { get; set; }
        public int distanceverify { get; set; }
        public int assetverify { get; set; }
        public int incomeverify { get; set; }     
        public int impactverify { get; set; }      
        public int agriverify { get; set; }
        public int copingverify { get; set; }

        //Remark
        public string registerverifyr { get; set; }
        public string demoverifyr { get; set; }    
        public string educationverifyr { get; set; }
        public string healthverifyr { get; set; }      
        public string empverifyr { get; set; }      
        public string housingverifyr { get; set; }       
        public string distanceverifyr { get; set; }      
        public string assetverifyr { get; set; }       
        public string incomeverifyr { get; set; }     
        public string impactverifyr { get; set; }       
        public string agriverifyr { get; set; }      
        public string copingverifyr { get; set; }


        //Approve Status
        public int registerapprove { get; set; }
        public int demoapprove { get; set; }
        public int educationapprove { get; set; }
        public int healthapprove { get; set; }
        public int empapprove { get; set; }
        public int housingapprove { get; set; }
        public int distanceapprove { get; set; }
        public int assetapprove { get; set; }
        public int incomeapprove { get; set; }
        public int impactapprove { get; set; }
        public int agriapprove { get; set; }
        public int copingapprove { get; set; }
        //Approve Remark
        public string registerapprover { get; set; }
        public string demoapprover { get; set; }
        public string educationapprover { get; set; }
        public string healthapprover { get; set; }
        public string empapprover { get; set; }
        public string housingapprover { get; set; }
        public string distanceapprover { get; set; }
        public string assetapprover { get; set; }
        public string incomeapprover { get; set; }
        public string impactapprover { get; set; }
        public string agriapprover { get; set; }
        public string copingapprover { get; set; }

    }

   
}
