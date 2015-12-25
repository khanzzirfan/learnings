using System;
using System.IO;
using Xamarin.Forms;
using Android.OS;
using EmpApp2.Service;
using EmpApp2.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace EmpApp2.Droid
{
    public class SQLite_Android: ISQLite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "Employee.db3";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}