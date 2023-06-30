using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Domain.Extensions
{
    public static class MobileApiStatus
    {
        public static String SuccessCode { get { return "200"; } }
        public static String SuccessMessage { get { return "Success"; } }
        public static String FailureCode { get { return "201"; } }
        public static String FailureMessage { get { return "Failed"; } }
        public static string DuplicateMessage { get { return "Duplicate record exists!!"; } }

    }
}
