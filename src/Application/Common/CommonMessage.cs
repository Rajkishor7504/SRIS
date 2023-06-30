/*
* File Name : CommonMessage.cs
* class Name : CommonMessage
* Created Date : 04 Jun 2021
* Created By : Spandana Ray
* Description : description for CommonMessage
*/
using System.ComponentModel;

namespace SRIS.Application.Common
{
    public enum CommonMessage
    {
        [Description("Invalid email id/UserName. Please enter your registered email id/Username.")]
        InvalidEmailId = 112,

        [Description("OTP has been sent to the Email Id")]
        OTPSuccess = 113,

        [Description("A new password has been sent to your e-mail address.")]
        NewPasswordSuccess = 114,
        [Description("OTP Submitted Successfully.")]
        OtpSuccess = 200,
        [Description("Password Updated Successfully.")]
        NewCreatePasswordSuccess = 400,
        [Description("Your OTP has expired. Click on the “Resend OTP” button to generated new one.")]
        OTPExpired = 115,

        [Description("Invalid OTP. Please enter a valid OTP.")]
        InvalidOTP = 116,

        [Description("Password has been changed successfully")]
        ChangePasswordSuccess = 204,

        [Description("Name should be unique for this commitee")]
        DuplicateName = 301,

        [Description("Mobile/Contact number should be unique")]
        DuplicateMobile = 302,

        [Description("Email address should be unique")]
        DuplicateEmail = 303,

    }
}