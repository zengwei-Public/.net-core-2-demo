using System;
using log4net;
using System.Net;

namespace NetCoreUtil
{
    public class MailSmtpAppender //: log4net.SmtpAppender
    {
        //private bool isDecrypted;

        //private static string localIp = string.Empty;
        //private bool hasInitSubject;
        //private bool isFromDecrypted;
        //private bool isUserNameDecrypted;
        //private bool isSmtpHostDecrypted;
        //private static string GetLocalIP()
        //{
        //    if (string.IsNullOrEmpty(localIp))
        //    {
        //        try
        //        {
        //            string hostNm = Dns.GetHostName();
        //            IPAddress[] ips = Dns.GetHostEntry("").AddressList;
        //            foreach (IPAddress ipAddress in ips)
        //            {
        //                if (!ipAddress.IsIPv6LinkLocal && !ipAddress.IsIPv6Multicast && !ipAddress.IsIPv6SiteLocal)
        //                {
        //                    localIp = ipAddress.ToString();
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            localIp = string.Empty;
        //        }
        //    }
        //    return localIp;
        //}
        //protected override void SendEmail(string messageBody)
        //{
        //    if (!string.IsNullOrEmpty(Password) && !isDecrypted)
        //    {
        //        Password = Decryption.Decrypt(Password);
        //        isDecrypted = true;
        //    }
        //    //发件人邮箱

        //    if (!string.IsNullOrEmpty(From) && !isFromDecrypted)
        //    {
        //        From = Decryption.Decrypt(From);
        //        isFromDecrypted = true;
        //    }
        //    //邮箱用户名
        //    if (!string.IsNullOrEmpty(Username) && !isUserNameDecrypted)
        //    {
        //        Username = Decryption.Decrypt(Username);
        //        isUserNameDecrypted = true;
        //    }
        //    //邮箱服务器
        //    if (!string.IsNullOrEmpty(SmtpHost) && !isSmtpHostDecrypted)
        //    {
        //        SmtpHost = Decryption.Decrypt(SmtpHost);
        //        isSmtpHostDecrypted = true;
        //    }
        //    if (!hasInitSubject)
        //    {
        //        Subject = "运行IP：" + GetLocalIP() + " " + Subject;
        //        hasInitSubject = true;
        //    }

        //    //#if !DEBUG
        //    base.SendEmail(messageBody);
        //    //#endif
        //}
    }
}
