using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace SRIS.Application.Common
{
    public class Common
    {
        static string str = string.Empty;

        public static string check(string Ctrltxt, string strMand, string ctlname, int intSize, string allowchar = "")
        {

            string strMessage = "pass";
            try
            {
                if (strMand == "M")
                {
                    if (Ctrltxt == "")
                    {
                        strMessage = ctlname + " can not be left blank";
                        return strMessage;
                    }
                }
                if (Ctrltxt != "")
                {
                    string FirststChar = Ctrltxt.Substring(0, 1);
                    if (FirststChar == " ")
                    {
                        strMessage = ctlname + " does not allow White Space(s) in first place";
                        return strMessage;
                    }

                    else if (FirststChar == "=" || FirststChar == "," || FirststChar == "-" || FirststChar == "." || FirststChar == "\\" || FirststChar == "(" || FirststChar == ")" || FirststChar == "/" || FirststChar == " " || FirststChar == "_" || FirststChar == ":")
                    {
                        strMessage = ctlname + " does not allow " + FirststChar + " in first place";
                        return strMessage;
                    }
                    else if (Ctrltxt.Substring(Ctrltxt.Length - 1, 1) == " ")
                    {
                        strMessage = ctlname + " " + "does not allow White Space(s) in last place";
                        return strMessage;
                    }
                    else if (allowchar != "")
                    {

                        string spcialchar = "!@#$%^&*()_+=-{}[]';:|\\?/>.<,~`|";
                        char[] allowcharecter = allowchar.ToCharArray();
                        foreach (char c in allowcharecter)
                        {
                            int index = spcialchar.IndexOf(c);
                            if (index != -1)
                            {
                                spcialchar = spcialchar.Remove(index, 1);
                            }

                        }
                        char[] specialchararray = spcialchar.ToCharArray();
                        foreach (char c in specialchararray)
                        {
                            if (Ctrltxt.Contains(c.ToString()))
                            {
                                strMessage = ctlname + " does not allow " + c.ToString() + "";
                                return strMessage;
                            }
                        }

                    }
                    else if (allowchar == "")
                    {

                        string spcialchar = "!@#$%^&*()_+=-{}[]';:|\\?/>.<,~`|";
                        char[] specialchararray = spcialchar.ToCharArray();
                        foreach (char c in specialchararray)
                        {
                            if (Ctrltxt.Contains(c.ToString()))
                            {
                                strMessage = ctlname + " does not allow " + c.ToString() + "";
                                return strMessage;
                            }
                        }
                    }
                    else if (Ctrltxt.Length > intSize)
                    {
                        strMessage = ctlname + " does not allow more than " + intSize + " characters";
                        return strMessage;
                    }
                }

            }
            catch
            {
                strMessage = "Fail";
            }
            return strMessage;

        }

        /// <summary>
        /// Automatically generate Number  201008251145409865
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //Generate Number 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;//Shaped like
            return code;
        }
        /// <summary>
        /// Created By Spandana Ray on 04-Jun-2021
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Common Message Description</returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
