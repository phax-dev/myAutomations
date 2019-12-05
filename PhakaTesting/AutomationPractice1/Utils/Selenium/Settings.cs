
using static  System.Configuration.ConfigurationManager;

namespace AutomationPractice1.Utils.Selenium
{
   public class Settings
    {

        
        public static string BaseUrl = AppSettings["BaseUrl"];
        public static string Wait = AppSettings["implicitWait"];
        public static string PageLoadtimeOut = AppSettings["pageLoadtimeOut"];
        public static string Browser = AppSettings["browser"];
        public static string chrome_binary = AppSettings["chrome_binary"];
        public static string ChromeHeadless = AppSettings["chrome_headless"];
        public static string UserA = AppSettings["UserA"];
        public static string PasswordA = AppSettings["PasswordA"];
        public static string UserB = AppSettings["UserB"];
        public static string UserC = AppSettings["UserC"];

    }
}
