using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using Codenutz.XFLabs.Basics.iOS;
using Codenutz.XFLabs.Basics.Interface;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace Codenutz.XFLabs.Basics.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        { }

        #region ISQLite implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "ReserveTable.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
        #endregion
    }
}
