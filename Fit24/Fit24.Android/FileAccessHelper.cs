using System;
using System.IO;
using Android.App;

namespace Fit24.Droid
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return CopyDatabaseIfNotExists(path, filename);
        }

        private static string CopyDatabaseIfNotExists(string dbDirectory, string filename)
        {
            string dbPath = Path.Combine(dbDirectory, filename);
            //if (!File.Exists(dbPath))
            {
                string[] arrayMyFiles = Directory.GetFiles(dbDirectory);
            }
            return dbPath;
        }
    }
}