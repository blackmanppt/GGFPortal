using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class SystemFunction
    {
        SysLog Log = new SysLog();
        public void SendMail(string strMailTo, string strSubject, string strBody)
        {
            var reader = new AppSettingsReader();
            var SendServer = reader.GetValue("SendMailServer", typeof(string));
            var SendMailAccount = reader.GetValue("SendMailAccount", typeof(string));
            
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    //寄件人
                    message.From = new MailAddress(SendMailAccount.ToString());
                    //收件人
                    message.To.Add(new MailAddress(strMailTo));
                    message.Bcc.Add(new MailAddress(SendMailAccount.ToString()));
                    //主旨
                    message.Subject = strSubject;
                    //MAIL的內容
                    message.Body = strBody;
                    message.IsBodyHtml = true;

                    SmtpClient client = new SmtpClient();
                    client.Host = SendServer.ToString();
                    //client.Host = LibGlobal.SEND_MAIL_HOST;
                    //client.Credentials = new System.Net.NetworkCredential(mail_account"phil.chung@gcc.com.tw", "pwd");

                    //SmtpServer.Port = 587;
                    client.UseDefaultCredentials = true;

                    client.Send(message);
                    //strMsg = "ok";
                    //blnResult = true;
                }
            }
            catch (FormatException ex) //check mail format
            {
                //strMsg = ex.Message;
                //EventLog.WriteEntry(strMsg, EventLogEntryType.Error);
                Log.ErrorLog(ex, "SendMail", "SendMail");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //strMsg = ex.Message;
                //EventLog.WriteEntry(strMsg, EventLogEntryType.Error);
                Log.ErrorLog(ex, "SendMail2", "SendMail2");
            }
            //return blnResult;
        }
    }
}