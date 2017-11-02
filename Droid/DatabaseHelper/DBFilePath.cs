using System;
using System.IO;
using Xamarin.Forms;
using xapps.DatabaseHelper.Interface;
using xapps.Droid.DatabaseHelper;

[assembly: Dependency(typeof(DBFilePath))]
namespace xapps.Droid.DatabaseHelper
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