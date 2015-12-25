using System;
using System.IO;
using Xamarin.Forms;
using EmpApp2.Service;
using EmpApp2.iOS;

[assembly: Dependency(typeof(SQLite_IOS))]
namespace EmpApp2.iOS
{
   public class SQLite_IOS: ISQLite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "Employee.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}
