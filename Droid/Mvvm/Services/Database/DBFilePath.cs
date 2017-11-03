using System;
using System.IO;
using Xamarin.Forms;
using xapps.Droid;

[assembly: Dependency(typeof(DBFilePath))]
namespace xapps.Droid
{
    /**
     * DB 물리파일 위치 반환 Android
     * by 한수현.
     */
    public class DBFilePath : IDBFilePath
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}