using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;





namespace SRIS.Domain.Common
{
    /// <summary>
    /// Summary description for ExtensionHelper
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Added by Manas Bej
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateAtWord(this string input, int length)
        {
            if (input == null || input.Length < length)
                return input;
            int iNextSpace = input.LastIndexOf(" ", length);
            return string.Format("{0}...", input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }
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
        public static string SerializeToXMLString<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
        public static string Set_Paging(int PageNumber, int PageSize, long TotalRecords, string ClassName, string PageUrl, string DisableClassName)
        {
            StringBuilder ReturnValue = new StringBuilder();

            long TotalPages = Convert.ToInt64(Math.Ceiling((double)TotalRecords / PageSize));
            if (PageNumber > 1)
            {
                if (PageNumber == 2)
                {
                    ReturnValue.Append("<a href='").Append(PageUrl.Trim()).Append("?pn=").Append(Convert.ToString(PageNumber - 1)).Append("' data-toggle='tooltip' title='Previous' class='").Append(ClassName).Append("' ><i class='fa fa-long-arrow-left'></i>Previous</a>   ");
                }
                else
                {
                    ReturnValue.Append("<a href='").Append(PageUrl.Trim());
                    if (PageUrl.Contains("?"))
                        ReturnValue.Append("&");
                    else
                        ReturnValue.Append("?");
                    ReturnValue.Append("pn=").Append(Convert.ToString(PageNumber - 1)).Append("' data-toggle='tooltip' title='Previous' class='").Append(ClassName).Append("' ><i class='fa fa-long-arrow-left'></i>Previous</a>   ");
                }
            }
            else
            {
                ReturnValue.Append("<span data-toggle='tooltip' title='Previous'  class='").Append(DisableClassName).Append("'><i class='fa fa-long-arrow-left'></i>Previous</span>   ");
            }

            if ((PageNumber - 3) > 1)
            {
                ReturnValue.Append("<a href='").Append(PageUrl.Trim()).Append("' class='").Append(ClassName).Append("' >1</a> .....");
            }

            for (int i = PageNumber - 3; i <= PageNumber; i++)
            {
                if (i >= 1)
                {
                    if (PageNumber != i)
                    {
                        ReturnValue.Append("<a href='").Append(PageUrl.Trim());
                        if (PageUrl.Contains("?"))
                            ReturnValue.Append("&");
                        else
                            ReturnValue.Append("?");
                        ReturnValue.Append("pn=").Append(i.ToString()).Append("' class='").Append(ClassName).Append("' >").Append(i.ToString()).Append("</a>");
                    }
                    else
                    {
                        ReturnValue.Append("<span class='page-1'>").Append(i).Append("</span>");
                    }
                }
            }

            for (int i = PageNumber + 1; i <= PageNumber + 3; i++)
            {
                if (i <= TotalPages)
                {
                    if (PageNumber != i)
                    {
                        ReturnValue.Append("<a href='").Append(PageUrl.Trim());
                        if (PageUrl.Contains("?"))
                            ReturnValue.Append("&");
                        else
                            ReturnValue.Append("?");
                        ReturnValue.Append("pn=").Append(i.ToString()).Append("' class='").Append(ClassName).Append("' >").Append(i.ToString()).Append("</a>");
                    }
                    else
                    {
                        ReturnValue.Append("<span class='text-success'>").Append(i).Append("</span>");
                    }
                }
            }

            if ((PageNumber + 3) < TotalPages)
            {
                ReturnValue.Append("..... <a href='").Append(PageUrl.Trim());
                if (PageUrl.Contains("?"))
                    ReturnValue.Append("&");
                else
                    ReturnValue.Append("?");
                ReturnValue.Append("pn=").Append(TotalPages.ToString()).Append("' class='").Append(ClassName).Append("' >").Append(TotalPages.ToString()).Append("</a>");
            }
            if (PageNumber < TotalPages)
            {
                ReturnValue.Append("   <a href='").Append(PageUrl.Trim());
                if (PageUrl.Contains("?"))
                    ReturnValue.Append("&");
                else
                    ReturnValue.Append("?");
                ReturnValue.Append("pn=").Append(Convert.ToString(PageNumber + 1)).Append("' data-toggle='tooltip' title='Next' class='").Append(ClassName).Append("' ><i class='fa fa-long-arrow-right'>Next</i></a>");
            }
            else
            {
                ReturnValue.Append("   <span data-toggle='tooltip' title='Next' class='").Append(DisableClassName).Append("'><i class='fa fa-long-arrow-right'></i>Next</span>");
            }

            return ReturnValue.ToString();
        }
        /// <summary>
        /// Function to check if the file mime type is same as per the extensions allowed in the page
        /// </summary>
        /// <param name="file">The file object that is uploaded by user</param>
        /// <param name="arrAllowedExtension">types of extensions allowed in the page</param>
        /// <returns>Boolean as in true and false</returns>
        public static bool IsFileValid(IFormFile file, string[] arrAllowedExtension)
        {
            string[] arrAllowedMime = new string[arrAllowedExtension.Length];
            for (int cnt = 0; cnt < arrAllowedExtension.Length; cnt++)
            {
                arrAllowedMime[cnt] = GetMimeTypeByFileExtension(arrAllowedExtension[cnt]);
            }
            StringCollection imageTypes = new StringCollection();
            StringCollection imageExtension = new StringCollection();
            imageTypes.AddRange(arrAllowedMime);
            imageExtension.AddRange(arrAllowedExtension);
            string filename = file.FileName;

            //to calculate dots
            int count = filename.Count(f => f == '.');
            string strFiletype = file.ContentType;

            string fileExt = Path.GetExtension(Path.GetExtension(file.FileName).ToLower());// 

            return imageTypes.Contains(strFiletype) && imageExtension.Contains(fileExt) && count == 1;
        }
        /// <summary>
        /// Function to get the mime type of file by extension
        /// </summary>
        /// <param name="strExtension">File extension with .</param>
        /// <returns>mime type with string format</returns>
        public static string GetMimeTypeByFileExtension(string strExtension)
        {
            string strMimeType = string.Empty;
            switch (strExtension.ToUpper())
            {
                case ".PDF":
                    strMimeType = "application/pdf";
                    break;
                case ".PNG":
                    strMimeType = "image/png";
                    break;
                case ".JPG":
                case ".JPEG":
                    strMimeType = "image/jpeg";
                    break;
                case ".ZIP":
                    strMimeType = "application/x-zip-compressed";
                    break;
                case ".RAR":
                    strMimeType = "application/octet-stream"; //"application /x-rar-compressed";
                    break;
                case ".DOC":
                    strMimeType = "application/msword";
                    break;
                case ".DOCX":
                    strMimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".XLSX":
                    strMimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case ".XLS":
                    strMimeType = "application/vnd.ms-excel";
                    break;
                case ".TXT":
                    strMimeType = "text/plain";
                    break;
                case ".GIF":
                    strMimeType = "image/gif";
                    break;
                case ".CSV":
                    strMimeType = "text/csv";
                    break;
                case ".LOG":
                    strMimeType = "text/plain";
                    break;
                case ".TIF":
                case ".TIFF":
                    strMimeType = "image/tiff";
                    break;
                case ".JSON":
                    strMimeType = "text/plain";
                    break;
                case ".GZ":
                    strMimeType = "application/x-gzip";
                    break;
            }
            return strMimeType;
        }


    }

}
