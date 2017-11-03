using System;
using System.IO;
using Xamarin.Forms;
using xapps.DatabaseHelper.Interface;
using xapps.iOS.DatabaseHelper;

[assembly: Dependency(typeof(DBFilePath))]
namespace xapps.iOS.DatabaseHelper
{
    /**
     * DB 물리파일 위치 반환 iOS
     * by 한수현.
     */
    public class DBFilePath : IDBFilePath
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}