/*
* File Name : OrganizationVM.cs
* class Name : OrganizationVM
* Created Date : 10 Jun 2021
* Created By : Spandana Ray
* Description : Organization View Model
*/

using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.OrganizationResistration.Queries.GetOrganization
{
    public class OrganizationVM
    {
        public IList<OrganizationDto> Lists { get; set; }
        public int organisationid { get; set; }
        public string organisationname { get; set; }
        public int organisationcategoryid { get; set; }
        public string physicallocation { get; set; }
        public string address { get; set; }
        public string mobileno { get; set; }
        public string telephoneno { get; set; }
        public string officialemail { get; set; }
        public string contactname { get; set; }
        public int contacttype { get; set; }
        public int registrationpurpose { get; set; }
        public string phoneno { get; set; }
        public RegistrationStatus status { get; set; }
        public string State { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Secretkey { get; set; }
        public string code { get; set; }
    }
}
