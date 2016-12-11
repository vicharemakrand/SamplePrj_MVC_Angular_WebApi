using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Sample.Utility
{
    public class AppProperties
    {
        public static SmtpSection SmtpMailSettings
        {
            get
            {
                if (AppMethods.GetCache<SmtpSection>(AppConstants.SmtpMailSettings) == null)
                {
                    AppMethods.AddCache(AppConstants.SmtpMailSettings, ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection);
                }

                return AppMethods.GetCache<SmtpSection>(AppConstants.SmtpMailSettings) as SmtpSection;
            }
        }

        public static string BasePhysicalPath
        {
            get
            {
                return AppMethods.GetCache<string>(AppConstants.BasePhysicalPath).ToString();
            }
            set
            {
                AppMethods.AddCache(AppConstants.BasePhysicalPath, value);
            }
        }

    }
}
