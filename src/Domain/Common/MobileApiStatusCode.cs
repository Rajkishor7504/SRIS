using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Common
{
   public class MobileApiStatusCode
    {
        public static string OK = "200";
        public static string Created = "201";
        public static string Accepted = "202";
        public static string Badrequest = "400";
        public static string Authenticationfailure = "401";
        public static string Forbidden = "403";
        public static string Resourcenotfound = "404";
        public static string MethodNotAllowed = "405";
        public static string Conflict = "409";
        public static string PreconditionFailed = "412";
    }
}
