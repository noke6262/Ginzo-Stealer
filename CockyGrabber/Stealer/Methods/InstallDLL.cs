using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Ginzo
{
    internal class Installing
    {
        public static string pathtoexe = Assembly.GetExecutingAssembly().Location;
        public static string installpath = pathtoexe.Substring(0, pathtoexe.LastIndexOf("\\"));
        public static void Library()
        {
            // Downloading all DLLs and other additionals
            WebClient Installing = new WebClient();

            try
            {
                Installing.DownloadFile(Program.DLLFolder + "DotNetZip.dll", installpath + "\\DotNetZip.dll");
                System.IO.File.SetAttributes(installpath + "\\DotNetZip.dll", System.IO.FileAttributes.Hidden);
            }
            catch { Console.WriteLine("Problems with DotNetZip.dll"); }

            try
            {
                Installing.DownloadFile(Program.DLLFolder + "System.Data.SQLite.dll", installpath + "\\System.Data.SQLite.dll");
                System.IO.File.SetAttributes(installpath + "\\System.Data.SQLite.dll", System.IO.FileAttributes.Hidden);
            }
            catch { Console.WriteLine("Problems with System.Data.SQLite.dll"); }

            try
            {
                Installing.DownloadFile(Program.DLLFolder + "Newtonsoft.Json.dll", installpath + "\\Newtonsoft.Json.dll");
                System.IO.File.SetAttributes(installpath + "\\Newtonsoft.Json.dll", System.IO.FileAttributes.Hidden);
            }
            catch { Console.WriteLine("Problems with Newtonsoft.Json.dll"); }

            try
            {
                Installing.DownloadFile(Program.DLLFolder + "BouncyCastle.Crypto.dll", installpath + "\\BouncyCastle.Crypto.dll");
                System.IO.File.SetAttributes(installpath + "\\BouncyCastle.Crypto.dll", System.IO.FileAttributes.Hidden);
            }
            catch { Console.WriteLine("Problems with BouncyCastle.Crypto.dll"); }

            try
            {
                var x86 = new DirectoryInfo(installpath + "\\x86");
                x86.Create();
                x86.Attributes |= FileAttributes.Hidden;
                Installing.DownloadFile(Program.DLLFolder + "/x86/SQLite.Interop.dll", installpath + "\\x86\\SQLite.Interop.dll");
            }
            catch { Console.WriteLine("Problems with x86 DLLs!"); }

            try
            {
                var x64 = new DirectoryInfo(installpath + "\\x64");
                x64.Create();
                x64.Attributes |= FileAttributes.Hidden;
                Installing.DownloadFile(Program.DLLFolder + "/x64/SQLite.Interop.dll", installpath + "\\x64\\SQLite.Interop.dll");
            }
            catch { Console.WriteLine("Problems with x64 DLLs!"); }
        }
    }
}
