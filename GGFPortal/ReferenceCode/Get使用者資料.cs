using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class Get使用者資料
    {
        /// <summary>
        /// 取得電腦名稱
        /// </summary>
        /// <returns>Server name</returns>
        public string 取得電腦名稱()
        {
            return Environment.MachineName;

            // Or can use
            // return System.Net.Dns.GetHostName();
            // return System.Windows.Forms.SystemInformation.ComputerName;
            // return System.Environment.GetEnvironmentVariable("COMPUTERNAME"); 
        }

        /// <summary>
        /// Gets the login account.
        /// </summary>
        /// <returns>Login account</returns>
        public string 取得使用者名稱()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// Gets the ip addresses.
        /// </summary>
        /// <returns>ip addresses</returns>
        public  string[] GetIpAddresses()
        {
            string hostName = 取得電腦名稱();

            return System.Net.Dns.GetHostAddresses(hostName).Select(i => i.ToString()).ToArray();
        }
    }
}