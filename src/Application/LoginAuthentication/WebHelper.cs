using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRIS.Application.LoginAuthentication
{
    public class WebHelper
    {
        #region SessionOperation 
        /// <summary>
        /// Write Session
        /// </summary>
        /// <typeparam name="T">Session key type</typeparam>
        /// <param name="key">Session key name</param>
        /// <param name="value">Session key value</param>
        public static void WriteSession<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
                return;
            CoreContextProvider.HttpContext.Session.SetString(key, value.ToString());
        }

        /// <summary>
        /// Write Session
        /// </summary>
        /// <param name="key"Session key name></param>
        /// <param name="value">Session key value</param>
        public static void WriteSession(string key, string value)
        {
            WriteSession<string>(key, value);
        }

        /// <summary>
        /// Read the value of the Session
        /// </summary>
        /// <param name="key">Session key name</param>        
        public static string GetSession(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            return CoreContextProvider.HttpContext.Session.GetString(key);
        }
        /// <summary>
        /// Delete Session specified
        /// </summary>
        /// <param name="key">Session key name</param>
        public static void RemoveSession(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;
            CoreContextProvider.HttpContext.Session.Remove(key);
        }

        #endregion
    }
}
