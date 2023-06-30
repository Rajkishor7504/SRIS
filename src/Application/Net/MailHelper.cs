/*
* File Name :    MailHelper.cs
* class Name :   MailHelper
* Created Date : 03 Jun 2021
* Created By :   Spandana Ray
* Description :  For mail Sent
*/
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SRIS.Application
{
    public class MailHelper
    {
        /// <summary>
        /// Mail Server Address 
        /// </summary>
        public string MailServer { get; set; }
        /// <summary>
        /// username
        /// </summary>
        public string MailUserName { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string MailName { get; set; }

        public int MailPort { get; set; }

        /// <summary>
        /// Send mail synchronously
        /// </summary>
        /// <param name="to">Recipient Mailbox Address </param>
        /// <param name="subject">theme</param>
        /// <param name="body">content</param>
        /// <param name="encoding">coding</param>
        /// <param name="isBodyHtml">Yes.No.Html</param>
        /// <param name="enableSsl">Yes.No.SSL encryption Connect</param>
        /// <returns>Yes.No.success</returns>
        public bool Send(string to, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                MailMessage message = new MailMessage();
                // Receiver Mailbox Address 
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(MailServer, MailPort);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                //SSLConnect
                smtpclient.EnableSsl = enableSsl;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //for check mail test(1-Nov-2022)
        public bool Sendmailtest(string frommail, string to, string cc, string subject, string content, string servername, int port, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                MailMessage message = new MailMessage();
                // Receiver Mailbox Address 
                message.To.Add(new MailAddress(to));
                message.To.Add(new MailAddress(cc));
                message.From = new MailAddress(frommail);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = content;
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(servername, port);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(frommail, "Deepak@1998");
                //SSLConnect
                smtpclient.EnableSsl = enableSsl;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SendFeedbackmail(string to, string cc, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                MailMessage message = new MailMessage();
                // Receiver Mailbox Address 
                message.To.Add(new MailAddress(to));
                message.To.Add(new MailAddress(cc));
                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(MailServer, MailPort);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                //SSLConnect
                smtpclient.EnableSsl = enableSsl;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Sendpartner(string to, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                MailMessage message = new MailMessage();
                // Receiver Mailbox Address 
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(MailServer, MailPort);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                //SSLConnect
                smtpclient.EnableSsl = enableSsl;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Sendgrievance(string to,string cc, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                
                MailMessage message = new MailMessage();
                // Receiver Mailbox Address 
                message.To.Add(new MailAddress(to));
                message.CC.Add(new MailAddress(cc));
                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;    
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(MailServer, MailPort);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                //SSLConnect
                smtpclient.EnableSsl = enableSsl;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Sending mail asynchronously
        /// </summary>
        /// <param name="to">Mail recipient</param>
        /// <param name="title">mail title</param>
        /// <param name="body">content of email</param>
        /// <param name="port">port No.</param>
        /// <returns></returns>
        public void SendByThread(string to, string title, string body, int port = 25)
        {
            new Thread(new ThreadStart(delegate ()
            {
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    //Mailbox smtp Address 
                    smtp.Host = MailServer;
                    //port No.
                    smtp.Port = port;
                    //Constructing the identity credential class of the sender
                    smtp.Credentials = new NetworkCredential(MailUserName, MailPassword);
                    //Constructing a message class
                    MailMessage objMailMessage = new MailMessage();
                    //Set priority
                    objMailMessage.Priority = MailPriority.High;
                    //Message sender
                    objMailMessage.From = new MailAddress(MailUserName, MailName, System.Text.Encoding.UTF8);
                    //Recipient
                    objMailMessage.To.Add(to);
                    //title
                    objMailMessage.Subject = title.Trim();
                    //Title character encoding
                    objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                    //text
                    objMailMessage.Body = body.Trim();
                    objMailMessage.IsBodyHtml = true;
                    //Content character encoding
                    objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    //send
                    smtp.Send(objMailMessage);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            })).Start();
        }
    }
}
