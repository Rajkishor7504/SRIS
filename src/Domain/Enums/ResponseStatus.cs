using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SRIS.Domain.Enums
{
    public enum ResponseStatus
    {
        [Description("success")]
        DataSuccess = 200,
        [Description("failure")]
        DataFailure = 201,
        [Description("This Cluster No is Already Mapped")]
        DataMapped = 300,
        [Description("Some inputs are missing. Please check.")]
        DataInputMissing = 400,

        [Description("Invalid Authentication.")]
        DataInvalidAuth = 401,
        [Description("Dependancy Record Exists!")]
        DependancyRecord = 402,
        [Description("Something went wrong. Please try again later.")]
        DataSomethingWrong = 500,
        [Description("Invalid Input")]
        InvalidData = 501,
        [Description("Request For This Programme Code Is Not Approved")]
        InvalidInputData = 601,
        [Description("Household Benificiary Successfully Updated")]
        ProgrammeCodeSuccess = 600,
        [Description("Duplicate Record")]
        DuplicateRecord = 301,
        [Description("Database Error!!")]
        DatabaseError = 999,
        [Description("Other Disease Name Already Exists!")]
        DuplicateDisease = 302

            

    }
}
