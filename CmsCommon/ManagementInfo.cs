using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Management;
namespace Cms.Common
{
    public class ManagementInfo
    {
        /// <summary>
        /// 获取CPU
        /// </summary>
        /// <returns></returns>
        public static string GetCpuID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                string strCpuID = null;
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                return strCpuID;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取网卡mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMac()
        {
            try
            {
                ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection queryCollection = query.Get();
                foreach (ManagementObject mo in queryCollection)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        return mo["MacAddress"].ToString();
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string getip;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                getip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else
            {
                getip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return getip;
        }
        /// <summary>
        /// 获取当前日期
        /// </summary>
        /// <returns></returns>
        public static string GetTime()
        {
            string times = DateTime.Now.ToString();
            return times;
        }
    }
}
